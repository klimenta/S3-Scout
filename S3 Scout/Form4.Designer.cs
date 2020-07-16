namespace S3_Scout
{
    partial class frmAddBucket
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBucketName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRegion = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter bucket name:";
            // 
            // txtBucketName
            // 
            this.txtBucketName.Location = new System.Drawing.Point(15, 25);
            this.txtBucketName.Name = "txtBucketName";
            this.txtBucketName.Size = new System.Drawing.Size(201, 20);
            this.txtBucketName.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(12, 64);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(80, 13);
            this.lblRegion.TabIndex = 4;
            this.lblRegion.Text = "Choose Region";
            // 
            // cbRegion
            // 
            this.cbRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Items.AddRange(new object[] {
            "US East (Virginia) - us-east-1",
            "US East (Ohio) - us-east-2",
            "US West (N. California) - us-west-1",
            "US West (Oregon) - us-west-2",
            "Africa (Cape Town) - af-south-1",
            "Asia Pacific (Hong Kong) - ap-east-1",
            "Asia Pacific (Tokyo) - ap-northeast-1",
            "Asia Pacific (Seoul) - ap-northeast-2",
            "Asia Pacific (Osaka-Local) - ap-northeast-3",
            "Asia Pacific (Mumbai) - ap-south-1",
            "Asia Pacific (Singapore) - ap-southeast-1",
            "Asia Pacific (Sydney) - ap-southeast-2",
            "Canada (Central) - ca-central-1",
            "China (Beijing) - cn-north-1",
            "China (Ningxia) - cn-northwest-1",
            "EU Central (Frankfurt) - eu-central-1",
            "EU North (Stockholm) - eu-north-1",
            "Europe (Milan) - eu-south-1",
            "EU West (Ireland) - eu-west-1",
            "EU West (London) - eu-west-2",
            "EU West (Paris) - eu-west-3",
            "Middle East (Bahrain) - me-south-1",
            "South America (Sao Paulo) - sa-east-1"});
            this.cbRegion.Location = new System.Drawing.Point(15, 80);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(201, 21);
            this.cbRegion.TabIndex = 6;
            // 
            // frmAddBucket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 151);
            this.Controls.Add(this.cbRegion);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBucketName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddBucket";
            this.Text = "Create Bucket";
            this.Load += new System.EventHandler(this.frmAddBucket_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBucketName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRegion;
        public System.Windows.Forms.ComboBox cbRegion;

    }
}