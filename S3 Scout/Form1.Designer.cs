namespace S3_Scout
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tlpAccounts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lnkAbout = new System.Windows.Forms.LinkLabel();
            this.btnView = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.colAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccessKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecretKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttipAbout = new System.Windows.Forms.ToolTip(this.components);
            this.tlpAccounts.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpAccounts
            // 
            this.tlpAccounts.ColumnCount = 2;
            this.tlpAccounts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpAccounts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAccounts.Controls.Add(this.pnlMain, 0, 0);
            this.tlpAccounts.Controls.Add(this.dgvAccounts, 1, 0);
            this.tlpAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAccounts.Location = new System.Drawing.Point(0, 0);
            this.tlpAccounts.Name = "tlpAccounts";
            this.tlpAccounts.RowCount = 1;
            this.tlpAccounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAccounts.Size = new System.Drawing.Size(899, 321);
            this.tlpAccounts.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMain.Controls.Add(this.lnkAbout);
            this.pnlMain.Controls.Add(this.btnView);
            this.pnlMain.Controls.Add(this.btndelete);
            this.pnlMain.Controls.Add(this.btnEdit);
            this.pnlMain.Controls.Add(this.btnNew);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(194, 315);
            this.pnlMain.TabIndex = 0;
            // 
            // lnkAbout
            // 
            this.lnkAbout.AutoSize = true;
            this.lnkAbout.Location = new System.Drawing.Point(55, 280);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(84, 13);
            this.lnkAbout.TabIndex = 4;
            this.lnkAbout.TabStop = true;
            this.lnkAbout.Text = "Kliment Andreev";
            this.ttipAbout.SetToolTip(this.lnkAbout, "Go to https://blog.andreev.it");
            this.lnkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAbout_LinkClicked);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(40, 215);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(116, 50);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(40, 155);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(116, 50);
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "&Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(40, 95);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(116, 50);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(40, 35);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(116, 50);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.AllowUserToDeleteRows = false;
            this.dgvAccounts.AllowUserToOrderColumns = true;
            this.dgvAccounts.AllowUserToResizeRows = false;
            this.dgvAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAccountName,
            this.colAccessKey,
            this.colSecretKey,
            this.colPrefix});
            this.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccounts.Location = new System.Drawing.Point(203, 3);
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(693, 315);
            this.dgvAccounts.TabIndex = 1;
            this.dgvAccounts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccounts_CellContentDoubleClick);
            this.dgvAccounts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAccounts_CellFormatting);
            // 
            // colAccountName
            // 
            this.colAccountName.FillWeight = 75F;
            this.colAccountName.HeaderText = "Account Name";
            this.colAccountName.Name = "colAccountName";
            this.colAccountName.ReadOnly = true;
            // 
            // colAccessKey
            // 
            this.colAccessKey.HeaderText = "Access Key";
            this.colAccessKey.Name = "colAccessKey";
            this.colAccessKey.ReadOnly = true;
            // 
            // colSecretKey
            // 
            this.colSecretKey.HeaderText = "Secret Key";
            this.colSecretKey.Name = "colSecretKey";
            this.colSecretKey.ReadOnly = true;
            // 
            // colPrefix
            // 
            this.colPrefix.FillWeight = 75F;
            this.colPrefix.HeaderText = "Prefix";
            this.colPrefix.Name = "colPrefix";
            this.colPrefix.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 321);
            this.Controls.Add(this.tlpAccounts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 360);
            this.Name = "frmMain";
            this.Text = "S3 Scout - v0.0.2";
            this.tlpAccounts.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAccounts;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.LinkLabel lnkAbout;
        private System.Windows.Forms.ToolTip ttipAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSecretKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrefix;
    }
}

