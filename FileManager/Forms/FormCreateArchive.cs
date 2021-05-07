using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;

namespace FileManager
{
    public partial class FormCreateArchive : Form
    {
        public FormCreateArchive(string ArchiveName)
        {
            InitializeComponent();
            if (ArchiveName != null)
                textBoxArchiveName.Text = ArchiveName;
        }

        public bool OkOrCancel;
        Point movePoint;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            OkOrCancel = false;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonClose_Click(null, null);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            OkOrCancel = true;
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
    }
}
