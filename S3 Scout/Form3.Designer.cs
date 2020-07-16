namespace S3_Scout
{
    partial class frmView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmView));
            this.dgvBuckets = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBucketDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFiles = new System.Windows.Forms.DataGridView();
            this.colType = new System.Windows.Forms.DataGridViewImageColumn();
            this.colObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStorageClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rbLogs = new System.Windows.Forms.RichTextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCreateBucket = new System.Windows.Forms.Button();
            this.btnDeleteBucket = new System.Windows.Forms.Button();
            this.lblTransferredFiles = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblTransferredBytes = new System.Windows.Forms.Label();
            this.lblBuckets = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblCurrentFolder = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.btnRefreshFolders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuckets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBuckets
            // 
            this.dgvBuckets.AllowUserToAddRows = false;
            this.dgvBuckets.AllowUserToDeleteRows = false;
            this.dgvBuckets.AllowUserToResizeRows = false;
            this.dgvBuckets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuckets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colRegion,
            this.colBucketDate});
            this.dgvBuckets.Location = new System.Drawing.Point(12, 12);
            this.dgvBuckets.MultiSelect = false;
            this.dgvBuckets.Name = "dgvBuckets";
            this.dgvBuckets.ReadOnly = true;
            this.dgvBuckets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuckets.Size = new System.Drawing.Size(382, 150);
            this.dgvBuckets.TabIndex = 2;
            this.dgvBuckets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuckets_CellDoubleClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Bucket Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 200;
            // 
            // colRegion
            // 
            this.colRegion.HeaderText = "Region";
            this.colRegion.Name = "colRegion";
            this.colRegion.ReadOnly = true;
            // 
            // colBucketDate
            // 
            this.colBucketDate.HeaderText = "Bucket Date";
            this.colBucketDate.Name = "colBucketDate";
            this.colBucketDate.ReadOnly = true;
            // 
            // dgvFiles
            // 
            this.dgvFiles.AllowUserToAddRows = false;
            this.dgvFiles.AllowUserToDeleteRows = false;
            this.dgvFiles.AllowUserToResizeRows = false;
            this.dgvFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colType,
            this.colObjectName,
            this.colStorageClass,
            this.colObjSize,
            this.colObjDate});
            this.dgvFiles.Location = new System.Drawing.Point(416, 12);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(485, 150);
            this.dgvFiles.TabIndex = 3;
            this.dgvFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFiles_CellDoubleClick);
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 35;
            // 
            // colObjectName
            // 
            this.colObjectName.HeaderText = "File Name";
            this.colObjectName.Name = "colObjectName";
            this.colObjectName.ReadOnly = true;
            // 
            // colStorageClass
            // 
            this.colStorageClass.HeaderText = "Storage Class";
            this.colStorageClass.Name = "colStorageClass";
            this.colStorageClass.ReadOnly = true;
            // 
            // colObjSize
            // 
            this.colObjSize.HeaderText = "Size (bytes)";
            this.colObjSize.Name = "colObjSize";
            this.colObjSize.ReadOnly = true;
            // 
            // colObjDate
            // 
            this.colObjDate.HeaderText = "Date Modified";
            this.colObjDate.Name = "colObjDate";
            this.colObjDate.ReadOnly = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(498, 217);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(405, 265);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(664, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbLogs
            // 
            this.rbLogs.Location = new System.Drawing.Point(32, 350);
            this.rbLogs.Name = "rbLogs";
            this.rbLogs.ReadOnly = true;
            this.rbLogs.Size = new System.Drawing.Size(783, 96);
            this.rbLogs.TabIndex = 9;
            this.rbLogs.Text = "";
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Location = new System.Drawing.Point(781, 168);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(34, 23);
            this.btnPrev.TabIndex = 11;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(867, 169);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCreateBucket
            // 
            this.btnCreateBucket.Location = new System.Drawing.Point(85, 169);
            this.btnCreateBucket.Name = "btnCreateBucket";
            this.btnCreateBucket.Size = new System.Drawing.Size(91, 23);
            this.btnCreateBucket.TabIndex = 13;
            this.btnCreateBucket.Text = "Create Bucket";
            this.btnCreateBucket.UseVisualStyleBackColor = true;
            this.btnCreateBucket.Click += new System.EventHandler(this.btnCreateBucket_Click);
            // 
            // btnDeleteBucket
            // 
            this.btnDeleteBucket.Location = new System.Drawing.Point(191, 169);
            this.btnDeleteBucket.Name = "btnDeleteBucket";
            this.btnDeleteBucket.Size = new System.Drawing.Size(78, 23);
            this.btnDeleteBucket.TabIndex = 14;
            this.btnDeleteBucket.Text = "Delete Bucket";
            this.btnDeleteBucket.UseVisualStyleBackColor = true;
            this.btnDeleteBucket.Click += new System.EventHandler(this.btnDeleteBucket_Click);
            // 
            // lblTransferredFiles
            // 
            this.lblTransferredFiles.AutoSize = true;
            this.lblTransferredFiles.Location = new System.Drawing.Point(413, 300);
            this.lblTransferredFiles.Name = "lblTransferredFiles";
            this.lblTransferredFiles.Size = new System.Drawing.Size(25, 13);
            this.lblTransferredFiles.TabIndex = 15;
            this.lblTransferredFiles.Text = "123";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(580, 217);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 23);
            this.btnUpload.TabIndex = 16;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Location = new System.Drawing.Point(740, 217);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteFile.TabIndex = 17;
            this.btnDeleteFile.Text = "Delete";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // lblTransferredBytes
            // 
            this.lblTransferredBytes.AutoSize = true;
            this.lblTransferredBytes.Location = new System.Drawing.Point(413, 322);
            this.lblTransferredBytes.Name = "lblTransferredBytes";
            this.lblTransferredBytes.Size = new System.Drawing.Size(35, 13);
            this.lblTransferredBytes.TabIndex = 18;
            this.lblTransferredBytes.Text = "label1";
            // 
            // lblBuckets
            // 
            this.lblBuckets.AutoSize = true;
            this.lblBuckets.Location = new System.Drawing.Point(12, 178);
            this.lblBuckets.Name = "lblBuckets";
            this.lblBuckets.Size = new System.Drawing.Size(52, 13);
            this.lblBuckets.TabIndex = 19;
            this.lblBuckets.Text = "Buckets: ";
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(821, 168);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(42, 23);
            this.btnUp.TabIndex = 20;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblCurrentFolder
            // 
            this.lblCurrentFolder.AutoSize = true;
            this.lblCurrentFolder.Location = new System.Drawing.Point(413, 173);
            this.lblCurrentFolder.Name = "lblCurrentFolder";
            this.lblCurrentFolder.Size = new System.Drawing.Size(16, 13);
            this.lblCurrentFolder.TabIndex = 21;
            this.lblCurrentFolder.Text = "L:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(287, 168);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 23);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(661, 215);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 23;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Location = new System.Drawing.Point(402, 217);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(90, 23);
            this.btnCreateFolder.TabIndex = 24;
            this.btnCreateFolder.Text = "Create Folder";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // btnRefreshFolders
            // 
            this.btnRefreshFolders.Location = new System.Drawing.Point(821, 215);
            this.btnRefreshFolders.Name = "btnRefreshFolders";
            this.btnRefreshFolders.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshFolders.TabIndex = 25;
            this.btnRefreshFolders.Text = "Refresh";
            this.btnRefreshFolders.UseVisualStyleBackColor = true;
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 646);
            this.Controls.Add(this.btnRefreshFolders);
            this.Controls.Add(this.btnCreateFolder);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCurrentFolder);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lblBuckets);
            this.Controls.Add(this.lblTransferredBytes);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblTransferredFiles);
            this.Controls.Add(this.btnDeleteBucket);
            this.Controls.Add(this.btnCreateBucket);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.rbLogs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvFiles);
            this.Controls.Add(this.dgvBuckets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmView";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.frmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuckets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvBuckets;
        private System.Windows.Forms.DataGridView dgvFiles;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox rbLogs;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCreateBucket;
        private System.Windows.Forms.Button btnDeleteBucket;
        private System.Windows.Forms.Label lblTransferredFiles;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblTransferredBytes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBucketDate;
        private System.Windows.Forms.Label lblBuckets;
        private System.Windows.Forms.DataGridViewImageColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStorageClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjDate;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblCurrentFolder;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnRefreshFolders;
    }
}