using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FileManager.Core;

namespace FileManager
{
    public partial class FormProperties : Form
    {
        public FormProperties(string pathFileOrFolder)
        {
            InitializeComponent();
            PathFileOrFolder = pathFileOrFolder;
        }

        FormPropertiesFileOrFolder formPropertiesFileOrFolder;
        FormPropertiesDisk formPropertiesDisk;
        Point movePoint;
        public bool OkOrCancel;
        string PathFileOrFolder;
        private Form ActiveForm = null;
        public bool ResultCheckBoxHidden = false;
        public bool IsHideRecursive = false;
        public bool EnabledNightMode;

        private void openChildForm(Form childForm)
        {
            if (ActiveForm != null)
                ActiveForm.Close();
            ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelProterties.Controls.Add(childForm);
            panelProterties.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            OkOrCancel = false;
            this.Close();
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            movePoint = new Point(e.X, e.Y);
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - movePoint.X;
                this.Top += e.Y - movePoint.Y;
            }
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.Red;
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(0, 31, 41, 54);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonClose_Click(sender, e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            OkOrCancel = true;
            try{ ResultCheckBoxHidden = formPropertiesFileOrFolder.checkBoxMakeHidden.Checked; }
            catch { }
            this.Close();
        }

        private void FormProperties_Load(object sender, EventArgs e)
        {
            if (Directory.GetParent(PathFileOrFolder) != null || File.Exists(PathFileOrFolder))
            {
                formPropertiesFileOrFolder = new FormPropertiesFileOrFolder(PathFileOrFolder);
                openChildForm(formPropertiesFileOrFolder);
                formPropertiesFileOrFolder.PrintProperties();
                if (EnabledNightMode)
                    formPropertiesFileOrFolder.PaintInDarkTheme();
                else
                    formPropertiesFileOrFolder.PaintInLightTheme();
            }
            else
            {
                formPropertiesDisk = new FormPropertiesDisk(PathFileOrFolder);
                openChildForm(formPropertiesDisk);
                formPropertiesDisk.PrintProperties();
                if (EnabledNightMode)
                    formPropertiesDisk.PaintInDarkTheme();
                else
                    formPropertiesDisk.PaintInLightTheme();
            }
        }

        private void FormProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.GetParent(PathFileOrFolder) != null || File.Exists(PathFileOrFolder))
            {
                if (ResultCheckBoxHidden)
                {
                    if (new FileInfo(PathFileOrFolder).Attributes.HasFlag(FileAttributes.Hidden))
                        return;
                    else
                        ClassFileManager.SetAttributesHidden(PathFileOrFolder, formPropertiesFileOrFolder.IsHideRecursive);
                }
                else
                {
                    if (new FileInfo(PathFileOrFolder).Attributes.HasFlag(FileAttributes.Hidden))
                        ClassFileManager.DeleteAttributesHidden(PathFileOrFolder, true);
                    else
                        return;
                }
            }
        }

        public void PaintInDarkTheme()
        {
            panelTop.BackColor = Color.FromArgb(36, 47, 61);
            panelProterties.BackColor = Color.FromArgb(36, 47, 61);
            panelButtons.BackColor = Color.FromArgb(36, 47, 61);
            buttonCancel.BackColor = Color.FromArgb(36, 47, 61);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.White;
            buttonOK.BackColor = Color.FromArgb(36, 47, 61);
            buttonOK.ForeColor = Color.White;
            buttonOK.FlatAppearance.BorderColor = Color.White;
            buttonClose.BackColor = Color.FromArgb(36, 47, 61);
            buttonClose.ForeColor = Color.White;
        }

        public void PaintInLightTheme()
        {
            panelTop.BackColor = Color.FromArgb(235, 235, 235);
            panelProterties.BackColor = Color.FromArgb(235, 235, 235);
            panelButtons.BackColor = Color.FromArgb(235, 235, 235);
            buttonCancel.BackColor = Color.FromArgb(235, 235, 235);
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.FlatAppearance.BorderColor = Color.Black;
            buttonOK.BackColor = Color.FromArgb(235, 235, 235);
            buttonOK.ForeColor = Color.Black;
            buttonOK.FlatAppearance.BorderColor = Color.Black;
            buttonClose.BackColor = Color.FromArgb(235, 235, 235);
            buttonClose.ForeColor = Color.Black;
        }
    }
}
