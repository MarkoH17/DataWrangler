using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataWrangler.Forms
{
    public partial class Welcome : Form
    {
        private Dictionary<string, string> _dbSettings;

        public Welcome()
        {
            InitializeComponent();
            _dbSettings = ConfigurationHelper.GetDbSettings();
        }

        private void FileBrowseButton_Click(object sender, EventArgs e)
        {
            string filePath;
            if (radioExistingSystem.Checked)
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    openFileDialog.Filter = "DataWrangler Database (*.db)|*.db";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        FilePathBox.Text = filePath;
                        NextButton.Enabled = true;

                        ConfigurationHelper.SaveDbSettings(filePath);
                    }
                }
            else if (radioNewSystem.Checked)
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    saveFileDialog.Filter = "DataWrangler Database (*.db)|*.db";
                    saveFileDialog.FilterIndex = 2;
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        FilePathBox.Text = filePath;
                        NextButton.Enabled = true;

                        ConfigurationHelper.SaveDbSettings(filePath);
                    }
                }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            _dbSettings = ConfigurationHelper.GetDbSettings();
            Program.SwitchForm(new Login(_dbSettings));
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            if (_dbSettings.Count > 0) Program.SwitchForm(new Login(_dbSettings));
        }
    }
}