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
            this.components = new System.ComponentModel.Container();
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rbLogs = new System.Windows.Forms.RichTextBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCreateBucket = new System.Windows.Forms.Button();
            this.btnDeleteBucket = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDeleteFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblBuckets = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.lblCurrentFolder = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.btnRefreshFolders = new System.Windows.Forms.Button();
            this.lblTransferredBytes = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblBevel = new System.Windows.Forms.Label();
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
            this.dgvBuckets.Location = new System.Drawing.Point(9, 55);
            this.dgvBuckets.MultiSelect = false;
            this.dgvBuckets.Name = "dgvBuckets";
            this.dgvBuckets.ReadOnly = true;
            this.dgvBuckets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuckets.Size = new System.Drawing.Size(466, 273);
            this.dgvBuckets.TabIndex = 2;
            this.dgvBuckets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuckets_CellDoubleClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Bucket Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
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
            this.colBucketDate.Width = 150;
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
            this.dgvFiles.Location = new System.Drawing.Point(481, 55);
            this.dgvFiles.Name = "dgvFiles";
            this.dgvFiles.ReadOnly = true;
            this.dgvFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFiles.Size = new System.Drawing.Size(516, 273);
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
            this.colObjDate.Width = 130;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(619, 9);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(40, 40);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "↓";
            this.toolTip1.SetToolTip(this.btnDownload, "Download");
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(963, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(34, 34);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "X";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbLogs
            // 
            this.rbLogs.Location = new System.Drawing.Point(9, 431);
            this.rbLogs.Name = "rbLogs";
            this.rbLogs.ReadOnly = true;
            this.rbLogs.Size = new System.Drawing.Size(988, 106);
            this.rbLogs.TabIndex = 9;
            this.rbLogs.Text = "";
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(878, 334);
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
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(958, 334);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCreateBucket
            // 
            this.btnCreateBucket.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBucket.Location = new System.Drawing.Point(9, 9);
            this.btnCreateBucket.Name = "btnCreateBucket";
            this.btnCreateBucket.Size = new System.Drawing.Size(40, 40);
            this.btnCreateBucket.TabIndex = 13;
            this.btnCreateBucket.Text = "+";
            this.toolTip1.SetToolTip(this.btnCreateBucket, "Create Bucket");
            this.btnCreateBucket.UseVisualStyleBackColor = true;
            this.btnCreateBucket.Click += new System.EventHandler(this.btnCreateBucket_Click);
            // 
            // btnDeleteBucket
            // 
            this.btnDeleteBucket.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBucket.Location = new System.Drawing.Point(55, 9);
            this.btnDeleteBucket.Name = "btnDeleteBucket";
            this.btnDeleteBucket.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteBucket.TabIndex = 14;
            this.btnDeleteBucket.Text = "-";
            this.toolTip1.SetToolTip(this.btnDeleteBucket, "Delete Bucket");
            this.btnDeleteBucket.UseVisualStyleBackColor = true;
            this.btnDeleteBucket.Click += new System.EventHandler(this.btnDeleteBucket_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(665, 9);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(40, 40);
            this.btnUpload.TabIndex = 16;
            this.btnUpload.Text = "↑";
            this.toolTip1.SetToolTip(this.btnUpload, "Upload");
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFile.Location = new System.Drawing.Point(527, 9);
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteFile.TabIndex = 17;
            this.btnDeleteFile.Text = "-";
            this.btnDeleteFile.UseVisualStyleBackColor = true;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // lblBuckets
            // 
            this.lblBuckets.AutoSize = true;
            this.lblBuckets.Location = new System.Drawing.Point(6, 334);
            this.lblBuckets.Name = "lblBuckets";
            this.lblBuckets.Size = new System.Drawing.Size(52, 13);
            this.lblBuckets.TabIndex = 19;
            this.lblBuckets.Text = "Buckets: ";
            // 
            // btnUp
            // 
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(918, 334);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(34, 23);
            this.btnUp.TabIndex = 20;
            this.btnUp.Text = "^";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // lblCurrentFolder
            // 
            this.lblCurrentFolder.AutoSize = true;
            this.lblCurrentFolder.Location = new System.Drawing.Point(478, 334);
            this.lblCurrentFolder.Name = "lblCurrentFolder";
            this.lblCurrentFolder.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentFolder.TabIndex = 21;
            this.lblCurrentFolder.Text = "Path: ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(101, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(40, 40);
            this.btnRefresh.TabIndex = 22;
            this.btnRefresh.Text = "⟳";
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateFolder.Location = new System.Drawing.Point(481, 9);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(40, 40);
            this.btnCreateFolder.TabIndex = 24;
            this.btnCreateFolder.Text = "+";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // btnRefreshFolders
            // 
            this.btnRefreshFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshFolders.Location = new System.Drawing.Point(573, 9);
            this.btnRefreshFolders.Name = "btnRefreshFolders";
            this.btnRefreshFolders.Size = new System.Drawing.Size(40, 40);
            this.btnRefreshFolders.TabIndex = 25;
            this.btnRefreshFolders.Text = "⟳";
            this.btnRefreshFolders.UseVisualStyleBackColor = true;
            this.btnRefreshFolders.Click += new System.EventHandler(this.btnRefreshFolders_Click);
            // 
            // lblTransferredBytes
            // 
            this.lblTransferredBytes.AutoSize = true;
            this.lblTransferredBytes.Location = new System.Drawing.Point(6, 369);
            this.lblTransferredBytes.Name = "lblTransferredBytes";
            this.lblTransferredBytes.Size = new System.Drawing.Size(84, 13);
            this.lblTransferredBytes.TabIndex = 18;
            this.lblTransferredBytes.Text = "Transferred: 0/0";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 389);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(948, 36);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            // 
            // lblBevel
            // 
            this.lblBevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBevel.Location = new System.Drawing.Point(9, 364);
            this.lblBevel.Name = "lblBevel";
            this.lblBevel.Size = new System.Drawing.Size(993, 10);
            this.lblBevel.TabIndex = 26;
            this.lblBevel.Text = "label1";
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 540);
            this.Controls.Add(this.lblBevel);
            this.Controls.Add(this.rbLogs);
            this.Controls.Add(this.lblTransferredBytes);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteBucket);
            this.Controls.Add(this.btnCreateBucket);
            this.Controls.Add(this.dgvBuckets);
            this.Controls.Add(this.lblBuckets);
            this.Controls.Add(this.btnRefreshFolders);
            this.Controls.Add(this.btnCreateFolder);
            this.Controls.Add(this.lblCurrentFolder);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDeleteFile);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox rbLogs;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCreateBucket;
        private System.Windows.Forms.Button btnDeleteBucket;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDeleteFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblBuckets;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Label lblCurrentFolder;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Button btnRefreshFolders;
        private System.Windows.Forms.Label lblTransferredBytes;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBucketDate;
        private System.Windows.Forms.Label lblBevel;
        private System.Windows.Forms.DataGridViewImageColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStorageClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjDate;
    }
}