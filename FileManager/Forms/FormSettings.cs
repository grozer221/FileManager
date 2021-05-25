using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        Point movePoint;
        public bool IsPresedButtonCancel = false;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            IsPresedButtonCancel = true;
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

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonClose_Click(sender, e);
        }

        public void PaintInDarkTheme()
        {
            panelTop.BackColor = Color.FromArgb(36, 47, 61);
            panelSettings.BackColor = Color.FromArgb(36, 47, 61);
            buttonCancel.BackColor = Color.FromArgb(36, 47, 61);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.FlatAppearance.BorderColor = Color.White;
            buttonOK.BackColor = Color.FromArgb(36, 47, 61);
            buttonOK.ForeColor = Color.White;
            buttonOK.FlatAppearance.BorderColor = Color.White;
            buttonClose.BackColor = Color.FromArgb(36, 47, 61);
            buttonClose.ForeColor = Color.White;
            checkBoxNightMode.ForeColor = Color.White;
            checkBoxShowHiddenFilesAndFolders.ForeColor = Color.White;
        }
        
        public void PaintInLightTheme()
        {
            panelTop.BackColor = Color.FromArgb(235, 235, 235);
            panelSettings.BackColor = Color.FromArgb(235, 235, 235);
            buttonCancel.BackColor = Color.FromArgb(235, 235, 235);
            buttonCancel.ForeColor = Color.Black;
            buttonCancel.FlatAppearance.BorderColor = Color.Black;
            buttonOK.BackColor = Color.FromArgb(235, 235, 235);
            buttonOK.ForeColor = Color.Black;
            buttonOK.FlatAppearance.BorderColor = Color.Black;
            buttonClose.BackColor = Color.FromArgb(235, 235, 235);
            buttonClose.ForeColor = Color.Black;
            checkBoxNightMode.ForeColor = Color.Black;
            checkBoxShowHiddenFilesAndFolders.ForeColor = Color.Black;
        }
    }
}
