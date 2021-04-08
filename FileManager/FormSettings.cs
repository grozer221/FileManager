using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public bool ShowHiddenFilesAndFolders;

        private void buttonClose_Click(object sender, EventArgs e)
        {
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
            if (checkBoxShowHiddenFilesAndFolders.Checked)
                ShowHiddenFilesAndFolders = true;
            else
                ShowHiddenFilesAndFolders = false;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonClose_Click(sender, e);
        }
    }
}
