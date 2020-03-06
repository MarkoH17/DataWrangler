using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWrangler
{
    public partial class FirstTimeSetup : Form
    {
        public FirstTimeSetup()
        {
            InitializeComponent();
            var configSettings = ConfigurationHelper.GetDbSettings();
            configSettings.TryGetValue("dbFilePath", out var dbPath);
            if (dbPath != null)
            {
                var login = new Login(configSettings);
                login.Show();
                this.Close();
            
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void FileBrowseButton_Click(object sender, EventArgs e)
        {

            var filePath = string.Empty;
            if (radioButton1.Checked)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    
                    openFileDialog.Filter = "Database Files|*.db"; //Filter not working properly due to desktop location
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        FilePathBox.Text = openFileDialog.FileName;
                        NextButoon.Enabled = true;


                        ConfigurationHelper.SaveDbSettings(FilePathBox.Text);
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    saveFileDialog.Filter = "database files (*.db)|*.db"; //Filter not working properly
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        FilePathBox.Text = saveFileDialog.FileName;
                        NextButoon.Enabled = true;
                        ConfigurationHelper.SaveDbSettings(FilePathBox.Text);
                    }
                }
            }
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }
    }
}
