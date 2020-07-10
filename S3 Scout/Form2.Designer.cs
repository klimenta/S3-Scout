namespace S3_Scout
{
    partial class frmAddAccount
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
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblAccessKey = new System.Windows.Forms.Label();
            this.lblSecretKey = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.txtAccessKey = new System.Windows.Forms.TextBox();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Location = new System.Drawing.Point(10, 10);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(78, 13);
            this.lblAccountName.TabIndex = 0;
            this.lblAccountName.Text = "Account Name";
            // 
            // lblAccessKey
            // 
            this.lblAccessKey.AutoSize = true;
            this.lblAccessKey.Location = new System.Drawing.Point(10, 60);
            this.lblAccessKey.Name = "lblAccessKey";
            this.lblAccessKey.Size = new System.Drawing.Size(63, 13);
            this.lblAccessKey.TabIndex = 1;
            this.lblAccessKey.Text = "Access Key";
            // 
            // lblSecretKey
            // 
            this.lblSecretKey.AutoSize = true;
            this.lblSecretKey.Location = new System.Drawing.Point(10, 110);
            this.lblSecretKey.Name = "lblSecretKey";
            this.lblSecretKey.Size = new System.Drawing.Size(59, 13);
            this.lblSecretKey.TabIndex = 2;
            this.lblSecretKey.Text = "Secret Key";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Location = new System.Drawing.Point(12, 28);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(296, 20);
            this.txtAccountName.TabIndex = 3;
            this.txtAccountName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountName_KeyDown);
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Location = new System.Drawing.Point(12, 78);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Size = new System.Drawing.Size(296, 20);
            this.txtAccessKey.TabIndex = 4;
            this.txtAccessKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccessKey_KeyDown);
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Location = new System.Drawing.Point(12, 128);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(296, 20);
            this.txtSecretKey.TabIndex = 5;
            this.txtSecretKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSecretKey_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(76, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(167, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(323, 206);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSecretKey);
            this.Controls.Add(this.txtAccessKey);
            this.Controls.Add(this.txtAccountName);
            this.Controls.Add(this.lblSecretKey);
            this.Controls.Add(this.lblAccessKey);
            this.Controls.Add(this.lblAccountName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddAccount";
            this.Load += new System.EventHandler(this.frmAddAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label lblAccessKey;
        private System.Windows.Forms.Label lblSecretKey;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

    }
}