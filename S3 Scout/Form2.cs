using System;
using System.Windows.Forms;

namespace S3_Scout
{
    public partial class frmAddAccount : Form
    {
        public string strAccountName = "";
        public string strAccessKey = "";
        public string strSecretKey = "";
        public string strPrefix = "";

        public frmAddAccount()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain.isValid = false;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            frmMain.isValid = true;

            strAccountName = txtAccountName.Text.Trim();
            strAccessKey = txtAccessKey.Text.Trim();
            strSecretKey = txtSecretKey.Text.Trim();
            strPrefix = txtPrefix.Text.Trim();
            if (string.IsNullOrEmpty(strAccountName) || (string.IsNullOrEmpty(strAccessKey)) || (string.IsNullOrEmpty(strSecretKey)))
            {
                MessageBox.Show("All fields except prefix are mandatory!", 
                    "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmMain.isValid = false;
            }
            if (frmMain.isValid) this.Close();
        }

        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            txtAccountName.Text = strAccountName;
            txtAccessKey.Text = strAccessKey;
            txtSecretKey.Text = strSecretKey;
            txtPrefix.Text = strPrefix;
        }

        private void txtSecretKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrefix.Focus();
            }
        }

        private void txtAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAccessKey.Focus();
            }
        }

        private void txtAccessKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSecretKey.Focus();
            }
        }

        private void txtPrefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, new EventArgs());
            }
        }
    }
}
