using System;
using System.Windows.Forms;
using DataWrangler.Forms;

namespace DataWrangler.Forms
{
    public partial class Landing : Form
    {
        public Landing()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Hide();
            //var imForm = new ImportRecords();
            //imForm.Show();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            Hide();
            //Manage mForm = new Manage();
            //mForm.Show();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            Hide();
            var oForm = new Options();
            oForm.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Hide();
            //var vForm = new ManageRecords();
            //vForm.Show();
        }

        private void LandingScreen_Load(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}