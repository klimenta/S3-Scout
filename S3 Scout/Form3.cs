﻿using System;
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

namespace S3_Scout
{
    public partial class frmView : Form
    {
        public static bool isValid;
        frmAddBucket bucketForm;
        int intPage = 0;
        int intBucketCount = 0;
        const int constMaxKeys = 1000;
        int intTotalObjects = 0;
        int intTotalPages = 0;
        public string strAccessKey = "";
        public string strSecretKey = "";
        string strTopLevelBucket = "";
        string strCurrentPrefix = "";
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        List<cMyS3Object> lstS3Objects = new List<cMyS3Object>();        

        [DllImport("shlwapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool PathCompactPathEx(System.Text.StringBuilder pszOut, string pszSrc, Int32 cchMax, Int32 dwFlags);

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

        private class cMyS3Object
        {
            public string Key { get; set; }
            public DateTime LastModified { get; set; }
            public long Size { get; set; }
            public bool Folder { get; set; }
            public string StorageClass { get; set; }
        }

        private void Logs(FontStyle fontStyle, string strText)
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

        private void ListBuckets()
        {
            dgvBuckets.Rows.Clear();
            intBucketCount = 0;
            Cursor.Current = Cursors.WaitCursor;
            AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
            ListBucketsResponse response = awsS3Client.ListBuckets();

            foreach (S3Bucket bucket in response.Buckets)
            {
                GetBucketLocationRequest bucketrequest = new GetBucketLocationRequest
                {
                    BucketName = bucket.BucketName
                };
                GetBucketLocationResponse bucketresponse = awsS3Client.GetBucketLocation(bucketrequest);
                string strRegion = bucketresponse.Location;
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


        private void frmView_Load(object sender, EventArgs e)
        {
            ListBuckets();
        }

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
                IEnumerable<S3Object> folders;
                IEnumerable<S3Object> files;

                //This returns folders only
                if (strPrefix == "")
                {
                    folders = lstResponse.S3Objects.Where(x => x.Key.EndsWith(@"/") && x.Size == 0 
                                                            && x.Key.Count(f => (f == cFolderDelimiter)) == 1);
                }
                else
                {
                    folders = lstResponse.S3Objects.Where(x => x.Key.Substring(strPrefix.Length + 1).EndsWith(@"/") 
                                                            && x.Size == 0 
                                                            && x.Key.Substring(strPrefix.Length + 1).Count(f => (f == cFolderDelimiter)) == 1);
                }
                //This returns files only 
                if (strPrefix == "")
                {
                    files = lstResponse.S3Objects.Where(x => x.Key.Count(f => f == cFolderDelimiter) == 0);
                }
                else
                {
                    files = lstResponse.S3Objects.Where(x => x.Key.Substring(strPrefix.Length + 1).Count(f => f == cFolderDelimiter) == 0 
                                                        && x.Key.Substring(strPrefix.Length +1) != "");
                }
                foreach (S3Object obj in folders)
                {
                    cMyS3Object MyS3ObjectFolder = new cMyS3Object();
                    if (strPrefix == "")
                    {
                        MyS3ObjectFolder.Key = obj.Key;
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
            return lstS3Objects;
        }

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

            Bitmap bmpImage = null;
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

        private void Refresh(string strFolderName, string strPrefix)
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
            lblCurrentFolder.Text = "L: " + PathShortener(strFolderName + "/" + strPrefix, 90);

        }


        private void dgvBuckets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string strBucketName = dgvBuckets.Rows[dgvBuckets.CurrentRow.Index].Cells[0].Value.ToString();
            strTopLevelBucket = strBucketName;
            strCurrentPrefix = "";
            
            Refresh(strBucketName, strCurrentPrefix);
            
            Logs(FontStyle.Regular, strTopLevelBucket + " list completed.");
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            Logs(FontStyle.Bold, "Download");
            int intDownloadedFiles = 1;
            int selectedCellCount = dgvFiles.SelectedRows.Count;
            if (selectedCellCount > 0)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strBucketName = dgvBuckets.Rows[dgvBuckets.CurrentRow.Index].Cells[1].Value.ToString();
                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        string strFileName = dgvFiles.Rows[dgvFiles.SelectedRows[i].Index].Cells[1].Value.ToString();
                        string strFolderName = string.Empty;
                        strFolderName = folderBrowserDialog1.SelectedPath;

                        var token = tokenSource.Token;
                        AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
                        using (var transferUtility = new TransferUtility(awsS3Client))
                        {
                            var downloadRequest = new TransferUtilityDownloadRequest
                            {
                                BucketName = strBucketName,
                                Key = strFileName,
                                FilePath = @strFolderName + "\\" + strFileName
                            };
                            lblTransferredFiles.Text = intDownloadedFiles.ToString() + "/" + selectedCellCount.ToString();
                            downloadRequest.WriteObjectProgressEvent += OnWriteObjectProgressEvent;

                            intDownloadedFiles++;
                            try
                            {
                                await transferUtility.DownloadAsync(downloadRequest, token);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                }
            }
        }

        void OnWriteObjectProgressEvent(object sender, WriteObjectProgressArgs e)
        {
            // Process progress update events.
            progressBar1.BeginInvoke(new Action(() => progressBar1.Value = e.PercentDone));
            //e.transferredbytes and e.totalbytes  

            lblTransferredBytes.Invoke(new Action(() => { lblTransferredBytes.Text = e.TransferredBytes.ToString() + "/" + e.TotalBytes.ToString(); }));
            Application.DoEvents();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //token.ThrowIfCancellationRequested();
            progressBar1.Value = 0;
            tokenSource.Cancel();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ShowPage(++intPage, lstS3Objects);
            btnPrev.Enabled = true;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ShowPage(--intPage, lstS3Objects);
            btnNext.Enabled = true;
        }

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
                        Logs(FontStyle.Regular, strBucketName + " deleted.");
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
                            Logs(FontStyle.Bold, "Bucket is not empty. Deleting anyway...");
                            throw;
                        }
                    }

                    DeleteObjectsRequest deleteObjectsRequest = new DeleteObjectsRequest { BucketName = strBucketName };
                    Logs(FontStyle.Regular, "Deleting objects in a bucket. Be patient...");
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (S3Object obj in client.ListObjects(new ListObjectsRequest { BucketName = strBucketName }).S3Objects)
                    {
                        // Add keys for the objects to the delete request
                        deleteObjectsRequest.AddKey(obj.Key, null);
                    }

                    // Submit the request
                    client.DeleteObjects(deleteObjectsRequest);
                    Cursor.Current = Cursors.Default;
                    // The bucket is empty now, so delete the bucket.
                    client.DeleteBucket(deleteBucketRequest);
                    Logs(FontStyle.Regular, strBucketName + " deleted.");
                    foreach (DataGridViewRow row in dgvBuckets.SelectedRows)
                    {
                        dgvBuckets.Rows.RemoveAt(row.Index);
                    }
                    intBucketCount--;
                    lblBuckets.Text = "Buckets: " + intBucketCount.ToString();

                }
                //https://stackoverflow.com/questions/11797476/delete-a-bucket-in-s3
                //https://csharp.hotexamples.com/examples/Amazon.S3/AmazonS3Client/DeleteBucket/php-amazons3client-deletebucket-method-examples.html
            }
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            int intUploadedFiles = 1;
            int selectedCellCount = dgvBuckets.SelectedRows.Count;
            if (selectedCellCount == 1)
            {
                string strBucketName = dgvBuckets.Rows[dgvBuckets.CurrentRow.Index].Cells[0].Value.ToString();

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int intFileCount = 0;
                    foreach (string strFilePathName in openFileDialog1.FileNames)
                    {

                        int intTotalFiles = openFileDialog1.FileNames.Length;

                        string[] strFileNames = openFileDialog1.SafeFileNames;
                        //MessageBox.Show(file);
                        var token = tokenSource.Token;
                        AmazonS3Client awsS3Client = new AmazonS3Client(strAccessKey, strSecretKey);
                        using (var transferUtility = new TransferUtility(awsS3Client))
                        {
                            var uploadRequest = new TransferUtilityUploadRequest
                            {
                                BucketName = strBucketName,
                                Key = strFileNames[intFileCount],
                                FilePath = strFilePathName
                            };
                            lblTransferredFiles.Text = intUploadedFiles.ToString() + "/" + intTotalFiles.ToString();
                            uploadRequest.UploadProgressEvent += OnUploadObjectProgressEvent;
                            intUploadedFiles++;
                            try
                            {
                                await transferUtility.UploadAsync(uploadRequest, token);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                        intFileCount++;
                    }
                }
                Refresh(strBucketName,"");
            }

        }

        void OnUploadObjectProgressEvent(object sender, UploadProgressArgs e)
        {
            // Process progress update events.
            progressBar1.BeginInvoke(new Action(() => progressBar1.Value = e.PercentDone));
            Application.DoEvents();
        }

        private void btnCreateBucket_Click(object sender, EventArgs e)
        {
            bucketForm = new frmAddBucket();
            bucketForm.ShowDialog();
            if (isValid)
            {

                //MessageBox.Show(bucketForm.strBucketName);
                //MessageBox.Show(bucketForm.strRegion);
                RegionEndpoint region = RegionEndpoint.GetBySystemName(bucketForm.strRegion);
                try
                {
                    var client = new AmazonS3Client(strAccessKey, strSecretKey, region);
                    //var client = new AmazonS3Client();
                    PutBucketRequest request = new PutBucketRequest();
                    request.BucketName = bucketForm.strBucketName;
                    client.PutBucket(request);
                }
                catch (AmazonS3Exception amazonS3Exception)
                {
                    if (amazonS3Exception.ErrorCode != null)
                    {
                        Logs(FontStyle.Regular, amazonS3Exception.Message);
                        return;
                    }
                }
                Logs(FontStyle.Regular, bucketForm.strBucketName + " created in " + bucketForm.strRegion);
                dgvBuckets.Rows.Add(bucketForm.strBucketName, bucketForm.strRegion, DateTime.Now.ToString());
                intBucketCount++;
                lblBuckets.Text = "Buckets: " + intBucketCount.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            MessageBox.Show(RegionEndpoint.AFSouth1.DisplayName);
            MessageBox.Show(RegionEndpoint.APEast1.DisplayName);
            MessageBox.Show(RegionEndpoint.APNortheast1.DisplayName);
            MessageBox.Show(RegionEndpoint.APNortheast2.DisplayName);
            MessageBox.Show(RegionEndpoint.APNortheast3.DisplayName);
            MessageBox.Show(RegionEndpoint.APSouth1.DisplayName);
            MessageBox.Show(RegionEndpoint.APSoutheast1.DisplayName);
            MessageBox.Show(RegionEndpoint.APSoutheast2.DisplayName);
            MessageBox.Show(RegionEndpoint.CACentral1.DisplayName);
            MessageBox.Show(RegionEndpoint.CNNorth1.DisplayName);
            MessageBox.Show(RegionEndpoint.CNNorthWest1.DisplayName);
            MessageBox.Show(RegionEndpoint.EUCentral1.DisplayName);
            MessageBox.Show(RegionEndpoint.EUNorth1.DisplayName);
            MessageBox.Show(RegionEndpoint.EUSouth1.DisplayName);
            MessageBox.Show(RegionEndpoint.EUWest1.DisplayName);
            MessageBox.Show(RegionEndpoint.EUWest2.DisplayName);
            MessageBox.Show(RegionEndpoint.EUWest3.DisplayName);
            MessageBox.Show(RegionEndpoint.MESouth1.DisplayName);
            MessageBox.Show(RegionEndpoint.SAEast1.DisplayName);
            MessageBox.Show(RegionEndpoint.USEast1.DisplayName);
            MessageBox.Show(RegionEndpoint.USEast2.DisplayName);
            MessageBox.Show(RegionEndpoint.USGovCloudEast1.DisplayName);
            MessageBox.Show(RegionEndpoint.USGovCloudWest1.DisplayName);
            MessageBox.Show(RegionEndpoint.USWest1.DisplayName);
            MessageBox.Show(RegionEndpoint.USWest2.DisplayName);
            */
            Console.WriteLine(RegionEndpoint.AFSouth1.DisplayName);
            Console.WriteLine(RegionEndpoint.APEast1.DisplayName);
            Console.WriteLine(RegionEndpoint.APNortheast1.DisplayName);
            Console.WriteLine(RegionEndpoint.APNortheast2.DisplayName);
            Console.WriteLine(RegionEndpoint.APNortheast3.DisplayName);
            Console.WriteLine(RegionEndpoint.APSouth1.DisplayName);
            Console.WriteLine(RegionEndpoint.APSoutheast1.DisplayName);
            Console.WriteLine(RegionEndpoint.APSoutheast2.DisplayName);
            Console.WriteLine(RegionEndpoint.CACentral1.DisplayName);
            Console.WriteLine(RegionEndpoint.CNNorth1.DisplayName);
            Console.WriteLine(RegionEndpoint.CNNorthWest1.DisplayName);
            Console.WriteLine(RegionEndpoint.EUCentral1.DisplayName);
            Console.WriteLine(RegionEndpoint.EUNorth1.DisplayName);
            Console.WriteLine(RegionEndpoint.EUSouth1.DisplayName);
            Console.WriteLine(RegionEndpoint.EUWest1.DisplayName);
            Console.WriteLine(RegionEndpoint.EUWest2.DisplayName);
            Console.WriteLine(RegionEndpoint.EUWest3.DisplayName);
            Console.WriteLine(RegionEndpoint.MESouth1.DisplayName);
            Console.WriteLine(RegionEndpoint.SAEast1.DisplayName);
            Console.WriteLine(RegionEndpoint.USEast1.DisplayName);
            Console.WriteLine(RegionEndpoint.USEast2.DisplayName);
            Console.WriteLine(RegionEndpoint.USGovCloudEast1.DisplayName);
            Console.WriteLine(RegionEndpoint.USGovCloudWest1.DisplayName);
            Console.WriteLine(RegionEndpoint.USWest1.DisplayName);
            Console.WriteLine(RegionEndpoint.USWest2.DisplayName);
        }

        private void dgvFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {                        
            string strBucketName = dgvFiles.Rows[dgvFiles.CurrentRow.Index].Cells[1].Value.ToString();
            Bitmap bmpType = (Bitmap)dgvFiles.Rows[dgvFiles.CurrentRow.Index].Cells[0].Value;
            if ((string)bmpType.Tag == "folder")
            {
                Refresh(strTopLevelBucket, strCurrentPrefix + strBucketName);
                
                strCurrentPrefix = strCurrentPrefix + strBucketName + "/";

                Logs(FontStyle.Regular, strBucketName + " list completed.");
            }
        }

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
            Refresh(strTopLevelBucket, strCurrentPrefix);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ListBuckets();
        }
    }
}
