using System;
using System.Windows.Forms;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Amazon.S3.IO;
using System.Text.RegularExpressions;

namespace S3_Scout
{
    public partial class frmView : Form
    {
        public static bool isBucketInputValid;
        frmAddFolder bucketForm;
        bool bAccountError;
        int intPage = 0;
        int intBucketCount = 0;
        const int constMaxKeys = 1000;
        int intTotalObjects = 0;
        int intTotalPages = 0;
        int intUploadCount;
        public string strAccessKey = "";
        public string strSecretKey = "";
        public string strPrefix = "";
        string strTopLevelBucket = "";
        string strCurrentPrefix = "";
        string strDownloadFileName;
        string[] strUploadFileName;
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        List<cMyS3Object> lstS3Objects = new List<cMyS3Object>();
        
        //Used for folder shortening e.g. bucket1/bucket2.../...object
        [DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool PathCompactPathEx(System.Text.StringBuilder pszOut, 
            string pszSrc, Int32 cchMax, Int32 dwFlags);

        //Shortents a long bucket URL to 260 chars
        static string PathShortener(string Path, int DesiredLength)
        {
            StringBuilder sb = new StringBuilder(260);
            if (PathCompactPathEx(sb, Path, DesiredLength + 1, 0))
            {
                return sb.ToString();
            }
            else
            {
                return Path;
            }
        }

        //Class for an S3 object
        private class cMyS3Object
        {
            public string Key { get; set; }
            public DateTime LastModified { get; set; }
            public long Size { get; set; }
            public bool Folder { get; set; }
            public string StorageClass { get; set; }
        }

        //Logs things at the bottom of the form
        private void LogEntry(FontStyle fontStyle, string strText)
        {
            DateTime saveNow = DateTime.Now;
            rbLogs.SelectionFont = new Font(rbLogs.Font, FontStyle.Regular);
            rbLogs.AppendText(saveNow.ToString() + " ");
            rbLogs.SelectionFont = new Font(rbLogs.Font, fontStyle);
            rbLogs.AppendText(strText + "\n");
            rbLogs.ScrollToCaret();
        }

        public frmView()
        {
            InitializeComponent();
        }

        //Gets the region for the bucket
        private string GetBucketLocation(string strPrefix)
        {
            AmazonS3Client client = new AmazonS3Client(strAccessKey, strSecretKey);
            GetBucketLocationRequest request = new GetBucketLocationRequest
            {
                BucketName = strPrefix
            };
            GetBucketLocationResponse response = null;
            try
            {
                response = client.GetBucketLocation(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Account error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "null";
            }
            return response.Location;
        }

        //List buckets on the left side on the form
        private void ListBuckets()
        {            
            dgvBuckets.Rows.Clear();
            intBucketCount = 0;
            Cursor.Current = Cursors.WaitCursor;
            if (strPrefix != "")
            {                
                string strRegion = GetBucketLocation(strPrefix);
                if (strRegion == "null")
                {
                    bAccountError = true;
                    return;
                }
                if (strRegion == "")
                {
                    strRegion = "us-east-1";
                }                
                dgvBuckets.Rows.Add(strPrefix, strRegion, "NO DATA");
                RefreshKeysGrid(strPrefix, "");
                return;
            }
            AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
            
            try
            {
                bAccountError = false;
                ListBucketsResponse response = awsS3Client.ListBuckets();
                GetBucketLocationResponse bucketresponse = null;
                string strRegion;
                bool bErrorResponse;

                foreach (S3Bucket bucket in response.Buckets)
                {
                    GetBucketLocationRequest bucketrequest = new GetBucketLocationRequest
                    {
                        BucketName = bucket.BucketName
                    };
                    try
                    {
                        bucketresponse = awsS3Client.GetBucketLocation(bucketrequest);
                        bErrorResponse = false;
                    }
                    catch (AmazonS3Exception e)
                    {                                                
                        LogEntry(FontStyle.Regular, bucket.BucketName + " " + e.Message);
                        bErrorResponse = true;                        
                    }
                    if (!bErrorResponse) strRegion = bucketresponse.Location;
                        else strRegion = "ERROR";
                    if (strRegion == "")
                    {
                        strRegion = "us-east-1";
                    }
                    dgvBuckets.Rows.Add(bucket.BucketName, strRegion, bucket.CreationDate);
                    intBucketCount++;
                }
                lblBuckets.Text = "Buckets: " + intBucketCount.ToString();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Account error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                bAccountError = true;
            }
        }


        //Find the Nth occurence of a character in a string
        private int IndexOfOccurence(string s, char match, int occurence)
        {
            int i = 1;
            int index = 0;

            while (i <= occurence && (index = s.IndexOf(match, index + 1)) != -1)
            {
                if (i == occurence)
                    return index;

                i++;
            }

            return -1;
        }

        //List buckets when the form is shown
        private void frmView_Load(object sender, EventArgs e)
        {
            ListBuckets();
            if (bAccountError)
            {
                this.Close();
                return;
            }
            lblBevel.Height = 2;
            dgvFiles.Columns[3].DefaultCellStyle.Format = "N0";
        }

        //Gets all objects on the right side
        private List<cMyS3Object> GetAllS3Objects(string strFolder, string strPrefix)
        {
            List<cMyS3Object> lstS3Objects = new List<cMyS3Object>();
            AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
            ListObjectsV2Request lstRequest = new ListObjectsV2Request
            {
                BucketName = strFolder,
                Prefix = strPrefix,
                Delimiter = "",
            };

            ListObjectsV2Response lstResponse;
            do
            {
                lstResponse = awsS3Client.ListObjectsV2(lstRequest);
                char cFolderDelimiter = '/';
                IEnumerable<S3Object> files;
                IEnumerable<S3Object> folders;
                
                folders = lstResponse.S3Objects.Clone();

                //This returns folders only
                if (strPrefix == "")
                {
                    folders = folders.Where(x => x.Key.EndsWith(@"/") && x.Size == 0
                              || x.Key.Count(f => (f == cFolderDelimiter)) >= 1).ToList();
                }
                else
                {
                    folders = folders.Where(x => x.Key.Count(f => (f == cFolderDelimiter)) > 1).ToList();
                    //Get the subfolders only                                                            
                    folders.ToList().ForEach(s => s.Key = s.Key.Substring(0, IndexOfOccurence(s.Key, cFolderDelimiter, 
                        strPrefix.Count(f => f == cFolderDelimiter) + 2) + 1));
                    folders = folders.Where(x => x.Key != "").ToList();
                    //Remove duplicates
                    folders = folders.GroupBy(x => x.Key).Select(x => x.First()).ToList();
                }
                //This returns files only 
                if (strPrefix == "")
                {
                    files = lstResponse.S3Objects;
                    files = files.Where(x => x.Key.Count(f => f == cFolderDelimiter) == 0);
                }
                else
                {                 
                    files = lstResponse.S3Objects;
                    files = files.Where(x => !(string.IsNullOrEmpty(x.Key)));
                    files = files.GroupBy(x => x.Key).Select(x => x.First());
                    files = files.Where(x => x.Key.Substring(strPrefix.Length + 1).Count(f => f == cFolderDelimiter) == 0
                                                       && x.Key.Substring(strPrefix.Length + 1) != "");
                }
                
                //Parse folders                 
                foreach (S3Object obj in folders)
                {
                    cMyS3Object MyS3ObjectFolder = new cMyS3Object();
                    if (strPrefix == "")
                    {
                        MyS3ObjectFolder.Key = obj.Key;
                        MyS3ObjectFolder.Key = string.Concat(obj.Key.TakeWhile((c) => c != cFolderDelimiter));
                        //folders = folders.Select(x => x.Key.Split('|')).ToList();
                        MyS3ObjectFolder.Key = MyS3ObjectFolder.Key + cFolderDelimiter;
                    }
                    else
                    {
                        MyS3ObjectFolder.Key = obj.Key.Substring(strPrefix.Length + 1);
                    }
                    MyS3ObjectFolder.Size = obj.Size;
                    MyS3ObjectFolder.LastModified = obj.LastModified;
                    MyS3ObjectFolder.StorageClass = obj.StorageClass;
                    MyS3ObjectFolder.Folder = true;
                    lstS3Objects.Add(MyS3ObjectFolder);
                }
                //Parse files
                foreach (S3Object obj in files)
                {
                    cMyS3Object MyS3ObjectFile = new cMyS3Object();
                    if (strPrefix == "")
                    {
                        MyS3ObjectFile.Key = obj.Key;
                    }
                    else
                    {
                        MyS3ObjectFile.Key = obj.Key.Substring(strPrefix.Length + 1);
                    }
                    MyS3ObjectFile.Size = obj.Size;
                    MyS3ObjectFile.LastModified = obj.LastModified;
                    MyS3ObjectFile.StorageClass = obj.StorageClass;
                    MyS3ObjectFile.Folder = false;
                    lstS3Objects.Add(MyS3ObjectFile);
                }
                lstRequest.ContinuationToken = lstResponse.NextContinuationToken;
            } while (lstResponse.IsTruncated);
            lstS3Objects = lstS3Objects.GroupBy(x => x.Key).Select(x => x.First()).ToList();
            return lstS3Objects;
        }

        //Shows a single page if there are more than MaxKeys = 1000 objects
        private void ShowPage(int intPageNo, List<cMyS3Object> lstS3Objects)
        {
            int intTotalRows = lstS3Objects.Count - (intPageNo * constMaxKeys);
            if (intTotalRows > constMaxKeys)
            {
                intTotalRows = constMaxKeys;
            }
            else
            {
                btnNext.Enabled = false;
            }
            dgvFiles.Rows.Clear();

            Bitmap bmpImage;
            for (int i = 0; i < intTotalRows; i++)
            {
                string strObject = lstS3Objects[i + intPageNo * constMaxKeys].Key;
                if (strObject.Substring(strObject.Length - 1, 1) == "/")
                {
                    strObject = strObject.Substring(0, strObject.Length - 1);
                    bmpImage = Properties.Resources.folder;
                    bmpImage.Tag = "folder";
                }
                else
                {
                    bmpImage = Properties.Resources.file;
                    bmpImage.Tag = "file";
                }
                dgvFiles.Rows.Add(bmpImage, strObject, lstS3Objects[i + intPageNo * constMaxKeys].StorageClass, lstS3Objects[i + intPageNo * constMaxKeys].Size, lstS3Objects[i + intPageNo * constMaxKeys].LastModified);
            }
            if (intPageNo == 0)
            {
                btnPrev.Enabled = false;
            }
        }

        //Refresh showing objects on the right side
        private void RefreshKeysGrid(string strFolderName, string strPrefix)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (!string.IsNullOrEmpty(strFolderName))
            {
                lstS3Objects = GetAllS3Objects(strFolderName, strPrefix);
                intTotalObjects = lstS3Objects.Count;
                intTotalPages = intTotalObjects / constMaxKeys;
                intPage = 0;
                if (intTotalPages > 0)
                {
                    btnNext.Enabled = true;
                }

                ShowPage(intPage, lstS3Objects);
            }
            Cursor.Current = Cursors.Default;
            lblCurrentFolder.Text = "Path: " + PathShortener(strFolderName + "/" + strPrefix, 65);
        }

        //Double-click bucket on the left
        private void dgvBuckets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strBucketName = dgvBuckets.Rows[dgvBuckets.CurrentRow.Index].Cells[0].Value.ToString();
            string strRegion = dgvBuckets.Rows[dgvBuckets.CurrentRow.Index].Cells[1].Value.ToString();
            if (strRegion == "ERROR")
            {
                LogEntry(FontStyle.Bold, strBucketName + " is in ERROR state!");
                return;
            }
            strTopLevelBucket = strBucketName;
            strCurrentPrefix = "";
            RefreshKeysGrid(strBucketName, strCurrentPrefix);
            LogEntry(FontStyle.Regular, strTopLevelBucket + " list completed.");
        }

        //Download object, only single object is allowed
        //You can probalby make it work for multiple objects, see upload async method
        private async void btnDownload_Click(object sender, EventArgs e)
        {            
            progressBar1.Value = 0;
            int selectedCellCount = dgvFiles.SelectedRows.Count;
            if (selectedCellCount > 1)
            {
                MessageBox.Show("You can't download multiple objects.", "Download error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (selectedCellCount == 1)
            {
                string strBucketName = dgvBuckets.Rows[dgvBuckets.CurrentRow.Index].Cells[0].Value.ToString();
                strDownloadFileName = dgvFiles.Rows[dgvFiles.SelectedRows[0].Index].Cells[1].Value.ToString();
                Bitmap bmpType = (Bitmap)dgvFiles.Rows[dgvFiles.CurrentRow.Index].Cells[0].Value;
                if ((string)bmpType.Tag == "folder")
                {
                    MessageBox.Show("You can't download folder objects.", "Download error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strFolderName = string.Empty;
                    strFolderName = folderBrowserDialog1.SelectedPath;
                    
                    CancellationToken token = tokenSource.Token;
                    AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
                    using (var transferUtility = new TransferUtility(awsS3Client))
                    {
                        var downloadRequest = new TransferUtilityDownloadRequest
                        {
                            BucketName = strBucketName,
                            Key = strCurrentPrefix + strDownloadFileName,
                            FilePath = @strFolderName + "\\" + strDownloadFileName
                        };
                        btnCancel.Enabled = true;
                        downloadRequest.WriteObjectProgressEvent += OnDownloadObjectProgressEvent;
                        LogEntry(FontStyle.Regular, strDownloadFileName + " download started...");                        
                        try
                        {
                            await transferUtility.DownloadAsync(downloadRequest, token);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                            btnCancel.Enabled = false;
                        }
                        finally
                        {
                            tokenSource.Dispose();
                            tokenSource = new CancellationTokenSource();
                            progressBar1.Value = 0;
                            lblTransferredBytes.Text = "Transferred: 0/0";
                        }
                    }
                    btnCancel.Enabled = false;
                }
            }
        }

        //Async download, show progress bar and bytes transferred
        void OnDownloadObjectProgressEvent(object sender, WriteObjectProgressArgs e)
        {
            // Process progress update events.
            progressBar1.BeginInvoke(new Action(() => progressBar1.Value = e.PercentDone));            
            if (e.PercentDone == 100)
            {
                Invoke(new Action(() =>
                {
                    LogEntry(FontStyle.Regular, strDownloadFileName + " download finished.");
                    btnCancel.Enabled = false;
                    progressBar1.Value = 0;
                    lblTransferredBytes.Text = "Transferred: 0/0";
                }));                
            }
            lblTransferredBytes.Invoke(new Action(() => {
                lblTransferredBytes.Text = "Transferred: " + String.Format("{0:n0}", e.TransferredBytes) 
                    + " / " + String.Format("{0:n0}", e.TotalBytes);
            }));
            Application.DoEvents();            
        }

        //Cancel upload or download
        private void btnCancel_Click(object sender, EventArgs e)
        {            
            tokenSource.Cancel();            
            LogEntry(FontStyle.Bold,  "Operation cancelled.");                      
        }

        //If more than MaxKeys = 1000 objects on the right grid, show the next from 1001+
        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowPage(++intPage, lstS3Objects);
            btnPrev.Enabled = true;
        }

        //Show the prev page if more than MaxKeys = 1000 objects on the right grid
        private void btnPrev_Click(object sender, EventArgs e)
        {
            ShowPage(--intPage, lstS3Objects);
            btnNext.Enabled = true;
        }

        //Delete a bucket on the left. It deletes non-empty buckets too.
        //Takes some time if a lot of objects
        private void btnDeleteBucket_Click(object sender, EventArgs e)
        {
            string strBucketName = dgvBuckets.Rows[dgvBuckets.CurrentRow.Index].Cells[0].Value.ToString();
            if (!string.IsNullOrEmpty(strBucketName))
            {
                DialogResult dialogResult = MessageBox.Show(strBucketName + " will be deleted. Are you sure?", "Delete S3 Bucket", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var client = new AmazonS3Client(strAccessKey, strSecretKey);
                    var deleteBucketRequest = new DeleteBucketRequest
                    {
                        BucketName = strBucketName
                    };

                    try
                    {
                        client.DeleteBucket(deleteBucketRequest);
                        LogEntry(FontStyle.Regular, strBucketName + " deleted.");
                        // If we get here, no error was generated so we'll assume the bucket was deleted and return.
                        foreach (DataGridViewRow row in dgvBuckets.SelectedRows)
                        {
                            dgvBuckets.Rows.RemoveAt(row.Index);
                        }
                        intBucketCount--;
                        lblBuckets.Text = "Buckets: " + intBucketCount.ToString();

                        return;
                    }

                    catch (AmazonS3Exception ex)
                    {
                        if (!ex.ErrorCode.Equals("BucketNotEmpty"))
                        {
                            // We got an unanticipated error. Just rethrow.
                            LogEntry(FontStyle.Bold, strBucketName + " deletion failed! Check the policy for accidental deletion.");
                            //throw;
                        }
                        if (ex.ErrorCode.Equals("BucketNotEmpty"))
                        {
                            // We got an unanticipated error. Just rethrow.
                            LogEntry(FontStyle.Bold, strBucketName + " bucket is not empty. This might take a while.");
                            //throw;
                        }

                    }

                    DeleteObjectsRequest deleteObjectsRequest = new DeleteObjectsRequest { BucketName = strBucketName };
                    LogEntry(FontStyle.Regular, "Deleting objects in a bucket. Be patient...");
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (S3Object obj in client.ListObjects(new ListObjectsRequest { BucketName = strBucketName }).S3Objects)
                    {
                        // Add keys for the objects to the delete request
                        deleteObjectsRequest.AddKey(obj.Key, null);
                    }
                    // Submit the request
                    try
                    {
                        client.DeleteObjects(deleteObjectsRequest);
                    }
                    catch (AmazonS3Exception ex)
                    {
                        if (!ex.ErrorCode.Equals("BucketNotEmpty"))
                        {
                            // We got an unanticipated error. Just rethrow.
                            //Logs(FontStyle.Bold, "2Failed! Check the policy for accidental deletion.");
                            return;
                        }
                    }
                    Cursor.Current = Cursors.Default;
                    // The bucket is empty now, so delete the bucket.
                    try
                    {
                        client.DeleteBucket(deleteBucketRequest);
                    }
                    catch (AmazonS3Exception ex)
                    {
                        if (!ex.ErrorCode.Equals("BucketNotEmpty"))
                        {
                            // We got an unanticipated error. Just rethrow.
                            LogEntry(FontStyle.Bold, "Failed! Check the policy for accidental deletion.");
                            return;
                        }
                    }
                    LogEntry(FontStyle.Regular, strBucketName + " successfully emptied and deleted.");
                    foreach (DataGridViewRow row in dgvBuckets.SelectedRows)
                    {
                        dgvBuckets.Rows.RemoveAt(row.Index);
                    }
                    intBucketCount--;
                    lblBuckets.Text = "Buckets: " + intBucketCount.ToString();
                    dgvFiles.Rows.Clear();
                    strBucketName = "";
                    strTopLevelBucket = "";
                }
            }
        }

        //Upload objects in the right grid. Multiple uploads allowed
        private async void btnUpload_Click(object sender, EventArgs e)
        {            
            progressBar1.Value = 0;
            int intUploadedFiles = 1;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                intUploadCount = 0;
                foreach (string strFilePathName in openFileDialog1.FileNames)
                {
                    int intTotalFiles = openFileDialog1.FileNames.Length;

                    strUploadFileName = openFileDialog1.SafeFileNames;
                    CancellationToken token = tokenSource.Token;
                    AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
                    using (var transferUtility = new TransferUtility(awsS3Client))
                    {
                        var uploadRequest = new TransferUtilityUploadRequest
                        {
                            BucketName = strTopLevelBucket,
                            Key = strCurrentPrefix + strUploadFileName[intUploadCount],
                            FilePath = strFilePathName
                        };

                        btnCancel.Enabled = true;
                        uploadRequest.UploadProgressEvent += OnUploadObjectProgressEvent;
                        LogEntry(FontStyle.Regular, strUploadFileName[intUploadCount] + " upload started...");
                        intUploadedFiles++;
                        try
                        {
                            await transferUtility.UploadAsync(uploadRequest, token);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                            btnCancel.Enabled = false;
                        }
                        finally
                        {
                            tokenSource.Dispose();
                            tokenSource = new CancellationTokenSource();
                            progressBar1.Value = 0;
                            lblTransferredBytes.Text = "Transferred: 0/0";
                        }
                    }
                    intUploadCount++;                    
                }
            }
            RefreshKeys();
        }

        //Show progress bar and bytes transferred for upload
        void OnUploadObjectProgressEvent(object sender, UploadProgressArgs e)
        {
            // Process progress update events.
            progressBar1.BeginInvoke(new Action(() => progressBar1.Value = e.PercentDone));
            if (e.PercentDone == 100)
            {
                Invoke(new Action(() =>
                {
                    LogEntry(FontStyle.Regular, strUploadFileName[intUploadCount] + " upload finished.");
                    btnCancel.Enabled = false;
                    progressBar1.Value = 0;
                    lblTransferredBytes.Text = "Transferred: 0/0";                    
                }));

            }
            lblTransferredBytes.Invoke(new Action(() => {
                lblTransferredBytes.Text = "Transferred: " + String.Format("{0:n0}", e.TransferredBytes)
                    + " / " + String.Format("{0:n0}", e.TotalBytes);
            }));
            Application.DoEvents();
        }

        //Do some regex stuff to see if the bucket name is valid
        private bool IsValidBucketName(string strBucketName)
        {
            var regexItem = new Regex(@"(?=^.{1,63}$)(?!^(\d+\.)+\d+$)(^(([a-z0-9]|[a-z0-9][a-z0-9\-]*[a-z0-9])\.)*([a-z0-9]|[a-z0-9][a-z0-9\-]*[a-z0-9])$)");

            if (regexItem.IsMatch(strBucketName)) return true;
                else return false;
        }
       
        //Create a bucket on the left
        private void btnCreateBucket_Click(object sender, EventArgs e)
        {
            bucketForm = new frmAddFolder();
            bucketForm.cbRegion.Enabled = true;
            bucketForm.ShowDialog();
            if (isBucketInputValid)
            {
                if (!IsValidBucketName(bucketForm.strBucketName))
                {
                    MessageBox.Show("Invalid bucket name.", "Error creating object",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                RegionEndpoint region = RegionEndpoint.GetBySystemName(bucketForm.strRegion);
                try
                {
                    var client = new AmazonS3Client(strAccessKey, strSecretKey, region);
                    if (DoesS3ObjectExist(client, bucketForm.strBucketName, "/"))
                    {
                        bucketForm.Dispose();
                        MessageBox.Show("Object already exist.", "Error creating bucket",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    PutBucketRequest request = new PutBucketRequest();
                    request.BucketName = bucketForm.strBucketName;
                    client.PutBucket(request);
                }
                catch (AmazonS3Exception amazonS3Exception)
                {
                    if (amazonS3Exception.ErrorCode != null)
                    {
                        LogEntry(FontStyle.Regular, amazonS3Exception.Message);
                        return;
                    }
                }
                LogEntry(FontStyle.Regular, bucketForm.strBucketName + " created in " + bucketForm.strRegion);
                dgvBuckets.Rows.Add(bucketForm.strBucketName, bucketForm.strRegion, DateTime.Now.ToString());
                intBucketCount++;
                lblBuckets.Text = "Buckets: " + intBucketCount.ToString();
            }
            bucketForm.Dispose();
        }

        //Double-click on the right grid, it has to be a folder - not a file
        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strBucketName = dgvFiles.Rows[dgvFiles.CurrentRow.Index].Cells[1].Value.ToString();
            Bitmap bmpType = (Bitmap)dgvFiles.Rows[dgvFiles.CurrentRow.Index].Cells[0].Value;
            if ((string)bmpType.Tag == "folder")
            {
                RefreshKeysGrid(strTopLevelBucket, strCurrentPrefix + strBucketName);

                strCurrentPrefix = strCurrentPrefix + strBucketName + "/";

                LogEntry(FontStyle.Regular, strBucketName + " list completed.");
            }
        }

        //Go up one folder in the right grid
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (strCurrentPrefix == "") return;
            // Remove last /
            strCurrentPrefix = strCurrentPrefix.Substring(0, strCurrentPrefix.Length - 1);
            // Cut until the last /
            int intDelimiterPosition = strCurrentPrefix.LastIndexOf('/');
            if (intDelimiterPosition > 0)
                strCurrentPrefix = strCurrentPrefix.Substring(0, intDelimiterPosition);
            else strCurrentPrefix = "";
            RefreshKeysGrid(strTopLevelBucket, strCurrentPrefix);
            if (strCurrentPrefix != "") strCurrentPrefix = strCurrentPrefix + "/";
        }

        //Refresh buckets on left
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ListBuckets();
        }

        //Check if S3 object exists
        private bool DoesS3ObjectExist(AmazonS3Client client, string strTopLevelBucket, string strObject)
        {
            S3FileInfo s3FileInfo = new Amazon.S3.IO.S3FileInfo(client, strTopLevelBucket, strObject);
            if (s3FileInfo.Exists) return true;
                else return false;            
        }

        //Create a folder on the right
        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            if (strTopLevelBucket == "")
            {
                MessageBox.Show("Double-click on a bucket on the left.", "Select a top bucket",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bucketForm = new frmAddFolder();
            bucketForm.cbRegion.Enabled = false;
            bucketForm.ShowDialog();
            if (isBucketInputValid)
            {
                if (!IsValidBucketName(bucketForm.strBucketName))
                {
                    MessageBox.Show("Invalid folder name.", "Error creating object",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var client = new AmazonS3Client(strAccessKey, strSecretKey);
                if (DoesS3ObjectExist(client, strTopLevelBucket, strCurrentPrefix + bucketForm.strBucketName + "/"))
                {
                    bucketForm.Dispose();
                    MessageBox.Show("Object already exists.", "Error creating object",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PutObjectRequest request = new PutObjectRequest()
                {
                    BucketName = strTopLevelBucket,
                    Key = strCurrentPrefix + bucketForm.strBucketName + "/"
                };
                PutObjectResponse response = client.PutObject(request);

                LogEntry(FontStyle.Regular, bucketForm.strBucketName + " created.");                
                Bitmap bmpImage;
                bmpImage = Properties.Resources.folder;
                bmpImage.Tag = "folder";
                dgvFiles.Rows.Add(bmpImage, bucketForm.strBucketName, "STANDARD", "0", DateTime.Now.ToString());
            }
            bucketForm.Dispose();            
        }

        //Refresh all object on right
        private void RefreshKeys()
        {
            string strRefreshPrefix;
            if (strCurrentPrefix != "")
            {
                strRefreshPrefix = strCurrentPrefix.Remove(strCurrentPrefix.Length - 1, 1);
            }
            else
            {
                strRefreshPrefix = "";
            }
            if (string.IsNullOrEmpty(strTopLevelBucket)) return;
            RefreshKeysGrid(strTopLevelBucket, strRefreshPrefix);
            LogEntry(FontStyle.Regular, "Refresh completed.");
        }

        //Click refresh button
        private void btnRefreshFolders_Click(object sender, EventArgs e)
        {
            RefreshKeys();
        }

        //Delete file/folder = object = key on the right
        private async void btnDeleteFile_Click(object sender, EventArgs e)
        {            
            int intselectedCellCount = dgvFiles.SelectedRows.Count;
            if (intselectedCellCount == 0)
            {
                MessageBox.Show("Please select object(s).", "Delete error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Object(s) will be deleted. Are you sure?", 
                "Delete S3 Objects", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                foreach (DataGridViewRow r in dgvFiles.SelectedRows)
                {
                    string strDeleteName = r.Cells[1].Value.ToString();
                    Bitmap bmpType = (Bitmap)r.Cells[0].Value;
                    AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
                    if ((string)bmpType.Tag == "folder")
                    {                                              
                        S3DirectoryInfo objToDelete = new S3DirectoryInfo(awsS3Client, strTopLevelBucket, strCurrentPrefix + strDeleteName);
                        objToDelete.Delete(true);                                                
                    }
                    try
                    {
                        var deleteObjectRequest = new DeleteObjectRequest
                        {
                            BucketName = strTopLevelBucket,
                            Key = strCurrentPrefix + strDeleteName
                        };
                        await awsS3Client.DeleteObjectAsync(deleteObjectRequest);
                    }
                    catch (AmazonS3Exception ex)
                    {
                        MessageBox.Show("Error encountered on server. Message:'{0}' when deleting an object", ex.Message,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unknown error encountered on server. Message:'{0}' when deleting an object", ex.Message,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LogEntry(FontStyle.Regular, strDeleteName + " deleted.");
                }                
            }
            RefreshKeys();
            Cursor.Current = Cursors.Default;
        }
    }
}