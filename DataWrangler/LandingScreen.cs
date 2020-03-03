using System;
using System.Windows.Forms;

namespace DataWrangler
{
    public partial class LandingScreen : Form
    {
        public LandingScreen()
        {
            InitializeComponent();
        }
    
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.Hide();
            Import imForm = new Import();
            imForm.Show();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage mForm = new Manage();
            mForm.Show();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Options oForm = new Options();
            oForm.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
           ViewRecords vForm = new ViewRecords();
            vForm.Show();
        }

        private void LandingScreen_Load(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}