using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;

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
                Parallel.Invoke(new Action(() =>
                {
                    long folderSize = 0;
                    formPropertiesFileOrFolder.GetFolderSize(PathFileOrFolder, ref folderSize);
                }));  
            }
            else
            {
                formPropertiesDisk = new FormPropertiesDisk(PathFileOrFolder);
                openChildForm(formPropertiesDisk);
                formPropertiesDisk.PrintProperties();
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

        
    }
}
