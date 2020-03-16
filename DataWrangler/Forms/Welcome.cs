using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataWrangler.Forms
{
    public partial class Welcome : MetroFramework.Forms.MetroForm
    {
        private Dictionary<string, string> _dbSettings;
        private string _userDefinedDbPath;

        public Welcome()
        {
            InitializeComponent();
            StyleHelper.LoadFormSavedStyle(this);
            _dbSettings = ConfigurationHelper.GetDbSettings();
            BringToFront();
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

                        _userDefinedDbPath = filePath;
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

                        _userDefinedDbPath = filePath;
                    }
                }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {

            if (radioNewSystem.Checked)
            {
                var initStatus = ObjectHelper.InitializeSystem(_userDefinedDbPath);
                if (initStatus.Success)
                {
                    var initResult = (Dictionary<string, string>) initStatus.Result;
                    var newUserName = initResult["newUserName"];
                    var newUserPass = initResult["newUserPass"];

                    MessageBox.Show(
                        "A new DataWrangler system has been initialized! Here are your new credentials:\n\tUsername: " +
                        newUserName + "\n\tPassword: " + newUserPass + "\n\nMake sure to save these credentials somewhere safe!");
                }
            }else if (radioExistingSystem.Checked)
            {
                ConfigurationHelper.SaveDbSettings(_userDefinedDbPath);
            }
                
            _dbSettings = ConfigurationHelper.GetDbSettings();

            Program.SwitchPrimaryForm(new Login(_dbSettings));
        }

        protected override void OnLoad(EventArgs e)
        {
            if (_dbSettings.Count > 0) Program.SwitchPrimaryForm(new Login(_dbSettings));
        }
    }
}