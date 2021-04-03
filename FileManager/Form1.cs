using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;

namespace FileManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataGridViewVisualise dataGridViewVisualise;
        string currentPath;

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            dataGridViewVisualise = new DataGridViewVisualise(dataGridViewFileManager, dataGridViewQuickAccessFolders);
            dataGridViewVisualise.PrintDisks();
            dataGridViewVisualise.PrintQuickAccessFolders();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point movePoint;

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

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.Red;
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(0, 31, 41, 54);
        }

        private void dataGridViewFileManager_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewVisualise.CellDoubleClick(e, ref currentPath);
            textBoxPath.Text = currentPath;
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            if (currentPath != null)
                pictureBoxStepBack.Enabled = true;
            if (currentPath == null)
                pictureBoxStepBack.Enabled = false;
        }

        private void pictureBoxStepBack_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.StepBack(ref currentPath);
            textBoxPath.Text = currentPath;
        }

        private void dataGridViewFileManager_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                dataGridViewFileManager.ClearSelection();
        }

        private void dataGridViewQuickAccessFolders_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridViewQuickAccessFolders.ClearSelection();
        }

        private void dataGridViewQuickAccessFolders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewVisualise.dataGridQuickAccessCellMouseClick(e, ref currentPath);
            textBoxPath.Text = currentPath;
        }
    }
}
