using System.Windows.Forms;
using MetroFramework.Controls;

namespace DataWrangler.Forms
{
    partial class EditRecordType
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
            this.lblId = new MetroFramework.Controls.MetroLabel();
            this.txtRecId = new MetroFramework.Controls.MetroTextBox();
            this.txtRecType = new MetroFramework.Controls.MetroTextBox();
            this.lblTypeId = new MetroFramework.Controls.MetroLabel();
            this.tabAttributes = new MetroFramework.Controls.MetroTabPage();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.btnUpdate = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 62);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(67, 19);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Record ID";
            // 
            // txtRecId
            // 
            // 
            // 
            // 
            this.txtRecId.CustomButton.Image = null;
            this.txtRecId.CustomButton.Location = new System.Drawing.Point(41, 1);
            this.txtRecId.CustomButton.Name = "";
            this.txtRecId.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRecId.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRecId.CustomButton.TabIndex = 1;
            this.txtRecId.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRecId.CustomButton.UseSelectable = true;
            this.txtRecId.CustomButton.Visible = false;
            this.txtRecId.Enabled = false;
            this.txtRecId.Lines = new string[0];
            this.txtRecId.Location = new System.Drawing.Point(85, 61);
            this.txtRecId.MaxLength = 32767;
            this.txtRecId.Name = "txtRecId";
            this.txtRecId.PasswordChar = '\0';
            this.txtRecId.ReadOnly = true;
            this.txtRecId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecId.SelectedText = "";
            this.txtRecId.SelectionLength = 0;
            this.txtRecId.SelectionStart = 0;
            this.txtRecId.ShortcutsEnabled = true;
            this.txtRecId.Size = new System.Drawing.Size(63, 23);
            this.txtRecId.TabIndex = 2;
            this.txtRecId.UseSelectable = true;
            this.txtRecId.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRecId.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtRecType
            // 
            // 
            // 
            // 
            this.txtRecType.CustomButton.Image = null;
            this.txtRecType.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.txtRecType.CustomButton.Name = "";
            this.txtRecType.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtRecType.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRecType.CustomButton.TabIndex = 1;
            this.txtRecType.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRecType.CustomButton.UseSelectable = true;
            this.txtRecType.CustomButton.Visible = false;
            this.txtRecType.Lines = new string[0];
            this.txtRecType.Location = new System.Drawing.Point(242, 61);
            this.txtRecType.MaxLength = 32767;
            this.txtRecType.Name = "txtRecType";
            this.txtRecType.PasswordChar = '\0';
            this.txtRecType.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRecType.SelectedText = "";
            this.txtRecType.SelectionLength = 0;
            this.txtRecType.SelectionStart = 0;
            this.txtRecType.ShortcutsEnabled = true;
            this.txtRecType.Size = new System.Drawing.Size(175, 23);
            this.txtRecType.TabIndex = 3;
            this.txtRecType.UseSelectable = true;
            this.txtRecType.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRecType.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblTypeId
            // 
            this.lblTypeId.AutoSize = true;
            this.lblTypeId.Location = new System.Drawing.Point(154, 62);
            this.lblTypeId.Name = "lblTypeId";
            this.lblTypeId.Size = new System.Drawing.Size(82, 19);
            this.lblTypeId.TabIndex = 4;
            this.lblTypeId.Text = "Record Type";
            // 
            // tabAttributes
            // 
            this.tabAttributes.AutoScroll = true;
            this.tabAttributes.HorizontalScrollbar = true;
            this.tabAttributes.HorizontalScrollbarBarColor = true;
            this.tabAttributes.HorizontalScrollbarHighlightOnWheel = false;
            this.tabAttributes.HorizontalScrollbarSize = 10;
            this.tabAttributes.Location = new System.Drawing.Point(4, 38);
            this.tabAttributes.Name = "tabAttributes";
            this.tabAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributes.Size = new System.Drawing.Size(408, 284);
            this.tabAttributes.TabIndex = 0;
            this.tabAttributes.Text = "Attributes";
            this.tabAttributes.UseVisualStyleBackColor = true;
            this.tabAttributes.VerticalScrollbar = true;
            this.tabAttributes.VerticalScrollbarBarColor = true;
            this.tabAttributes.VerticalScrollbarHighlightOnWheel = false;
            this.tabAttributes.VerticalScrollbarSize = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAttributes);
            this.tabControl1.Location = new System.Drawing.Point(12, 99);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(416, 326);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.UseSelectable = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(353, 431);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Close";
            this.btnUpdate.UseSelectable = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(272, 431);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.metroLabel1.Location = new System.Drawing.Point(12, 94);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(416, 2);
            this.metroLabel1.TabIndex = 8;
            // 
            // EditRecordType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 464);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTypeId);
            this.Controls.Add(this.txtRecType);
            this.Controls.Add(this.txtRecId);
            this.Controls.Add(this.lblId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditRecordType";
            this.Text = "Edit Record Type";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroLabel lblId;
        private MetroTextBox txtRecId;
        private MetroTextBox txtRecType;
        private MetroLabel lblTypeId;
        private MetroTabPage tabAttributes;
        private MetroTabControl tabControl1;
        private MetroButton btnUpdate;
        private MetroButton btnCancel;
        private MetroLabel metroLabel1;
    }
}