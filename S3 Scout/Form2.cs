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

        //Cancel any changes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain.isAccountInputValid = false;
            Close();
        }
        
        //Validates the input in the text boxes
        private void btnOK_Click(object sender, EventArgs e)
        {
            frmMain.isAccountInputValid = true;

            strAccountName = txtAccountName.Text.Trim();
            strAccessKey = txtAccessKey.Text.Trim();
            strSecretKey = txtSecretKey.Text.Trim();
            strPrefix = txtPrefix.Text.Trim();
            if (string.IsNullOrEmpty(strAccountName) || (string.IsNullOrEmpty(strAccessKey)) || (string.IsNullOrEmpty(strSecretKey)))
            {
                MessageBox.Show("All fields except prefix are mandatory!", 
                    "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmMain.isAccountInputValid = false;
            }
            if (frmMain.isAccountInputValid) this.Close();
        }
        
        private void frmAddAccount_Load(object sender, EventArgs e)
        {
            txtAccountName.Text = strAccountName;
            txtAccessKey.Text = strAccessKey;
            txtSecretKey.Text = strSecretKey;
            txtPrefix.Text = strPrefix;
        }

        //Next edit box if enter is pressed
        private void txtSecretKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPrefix.Focus();
            }
        }

        //Next edit box if enter is pressed            
        private void txtAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAccessKey.Focus();
            }
        }

        //Next edit box if enter is pressed
        private void txtAccessKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSecretKey.Focus();
            }
        }

        //Simulate OK click if enter key is pressed for the last edit box
        private void txtPrefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, new EventArgs());
            }
        }
    }
}