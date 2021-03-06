﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace S3_Scout
{
    public partial class frmAddFolder : Form
    {

        public string strBucketName = "";
        public string strRegion = "";
        List<string> lstRegions = new List<string> { "us-east-1", "us-east-2", "us-west-1", "us-west-2",
                                                  "af-south-1", "ap-east-1", "ap-northeast-1", "ap-northeast-2",
                                                  "ap-northeast-3", "ap-south-1", "ap-southeast-1", "ap-southeast-2",
                                                  "ca-central-1", "cn-north-1", "cn-northwest-1", "eu-central-1",
                                                  "eu-north-1", "eu-south-1", "eu-west-1", "eu-west-2",
                                                  "eu-west-3", "me-south-1", "sa-east-1"};

        public frmAddFolder()
        {
            InitializeComponent();
        }

        //Cancels out of the form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmView.isBucketInputValid = false;
            Close();
        }

        //Validates the bucket name
        private void btnOK_Click(object sender, EventArgs e)
        {
            frmView.isBucketInputValid = true;
            strBucketName = txtFolderName.Text.Trim();

            int intRegion = cbRegion.SelectedIndex;
            strRegion = lstRegions.ElementAt(intRegion);            
            if (string.IsNullOrEmpty(strBucketName))
            {
                MessageBox.Show("Folder name is mandatory!", "Add Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmView.isBucketInputValid = false;
            }
            if (frmView.isBucketInputValid) this.Close();
        }

        //Folders inherit region from the bucket, it can't be changed
        private void frmAddBucket_Load(object sender, EventArgs e)
        {
            cbRegion.SelectedIndex = 0;
        }

        //Simulate Enter for OK and ESC to cancel out the form
        private void txtBucketName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }        
    }
}
