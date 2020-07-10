using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Text;
using System.Web;
using System.Web.Security;

namespace S3_Scout
{
    public partial class frmMain : Form
    {
        public static bool isValid;
        private string strAppDataFolder;
        frmAddAccount accountForm;
        frmView viewForm;
        private const string cstrSecret = "!@Sup3rS3cr3t^&&^&hHFB@sdf23";

        public class cAccount
        {
            public string colAccountName { get; set; }
            public string colAccessKey { get; set; }
            public string colSecretKey { get; set; }
        }

        public void Save2File()
        {
            string strJSON;
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dgvAccounts.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvAccounts.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            strJSON = DataTable2JSON(dt);
            System.IO.File.WriteAllText(@strAppDataFolder + "\\S3 Scout.json", strJSON);
        }

        public void JSON2DataTable(string x)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<cAccount> lstAccount = jsSerializer.Deserialize<List<cAccount>>(x);

            foreach (var actAccount in lstAccount)
            {
                if (!string.IsNullOrEmpty(actAccount.colAccountName))
                {
                    dgvAccounts.Rows.Add(Unprotect(actAccount.colAccountName, cstrSecret),
                        Unprotect(actAccount.colAccessKey, cstrSecret),
                        Unprotect(actAccount.colSecretKey, cstrSecret));
                }
            }
        }

        public string DataTable2JSON(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    string strProtect = row[col].ToString();
                    strProtect = Protect(strProtect, cstrSecret);
                    childRow.Add(col.ColumnName, strProtect);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

        public static string Protect(string text, string purpose)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            byte[] stream = Encoding.UTF8.GetBytes(text);
            byte[] encodedValue = MachineKey.Protect(stream, purpose);
            return HttpServerUtility.UrlTokenEncode(encodedValue);
        }

        public static string Unprotect(string text, string purpose)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            byte[] stream = HttpServerUtility.UrlTokenDecode(text);
            byte[] decodedValue = MachineKey.Unprotect(stream, purpose);
            return Encoding.UTF8.GetString(decodedValue);
        }

        public frmMain()
        {
            InitializeComponent();
            try
            {
                strAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string strJSON = System.IO.File.ReadAllText(@strAppDataFolder + "\\S3 Scout.json");
                JSON2DataTable(strJSON);
            }
            catch { }
        }

        private void ViewS3()
        {
            Cursor.Current = Cursors.WaitCursor;
            viewForm = new frmView();
            viewForm.Text = "Account: " + dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[0].Value.ToString();
            viewForm.strAccessKey = dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[1].Value.ToString();
            viewForm.strSecretKey = dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[2].Value.ToString();
            viewForm.ShowDialog();
            viewForm.Dispose();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                DataGridViewRow dgitem = dgvAccounts.SelectedRows[0];
                if (dgvAccounts.Rows.Count - dgitem.Index != 1)
                {
                    ViewS3();
                }
            }

            /*
            viewForm = new frmView();
            viewForm.Text = "Account: " + dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[0].Value.ToString();
            viewForm.strAccessKey = dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[1].Value.ToString();
            viewForm.strSecretKey = dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[2].Value.ToString();            
            viewForm.ShowDialog();
            viewForm.Dispose();
            */
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                DataGridViewRow dgitem = dgvAccounts.SelectedRows[0];
                if (dgvAccounts.Rows.Count - dgitem.Index != 1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure?", "Delete Account(s)", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow item in dgvAccounts.SelectedRows)
                        {
                            if (dgvAccounts.Rows.Count - item.Index != 1) dgvAccounts.Rows.RemoveAt(item.Index);
                        }
                        Save2File();
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            accountForm = new frmAddAccount();
            accountForm.Text = "New Account";
            accountForm.ShowDialog();

            if (isValid)
            {
                int intIndex = dgvAccounts.Rows.Count - 1;
                dgvAccounts.Rows.Add();
                dgvAccounts.Rows[intIndex].Cells[0].Value = accountForm.strAccountName;
                dgvAccounts.Rows[intIndex].Cells[1].Value = accountForm.strAccessKey;
                dgvAccounts.Rows[intIndex].Cells[2].Value = accountForm.strSecretKey;
            }
            accountForm.Dispose();
            Save2File();
        }

        private void lnkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.andreev.it");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 1)
            {
                DataGridViewRow item = dgvAccounts.SelectedRows[0];
                if (dgvAccounts.Rows.Count - item.Index != 1)
                {
                    accountForm = new frmAddAccount();
                    accountForm.Text = "Edit Account";
                    accountForm.strAccountName = dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[0].Value.ToString();
                    accountForm.strAccessKey = dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[1].Value.ToString();
                    accountForm.strSecretKey = dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[2].Value.ToString();

                    accountForm.ShowDialog();
                }
                if (isValid)
                {
                    int intIndex = dgvAccounts.Rows.Count - 1;
                    //dgvAccounts.Rows.Add();
                    dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[0].Value = accountForm.strAccountName;
                    dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[1].Value = accountForm.strAccessKey;
                    dgvAccounts.Rows[dgvAccounts.CurrentRow.Index].Cells[2].Value = accountForm.strSecretKey;
                    Save2File();
                }
            }
        }

        private void dgvAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewS3();
        }

    }
}
