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
            ReloadToolStripMenuItem_Click(null, null);
            dataGridViewVisualise.GetListQuickAccessFoldersFromFile();
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
        private void dataGridViewFileManager_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                dataGridViewFileManager.Rows[e.RowIndex].Selected = true;
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

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            string tmpCurrentPath = textBoxPath.Text;
            try { dataGridViewVisualise.SearchDirectory(ref tmpCurrentPath); }
            catch { return; }
            currentPath = tmpCurrentPath;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.GetFilesAndFolderForCopyFromDataGrid(currentPath, dataGridViewFileManager);
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.PasteCopiedFoldersAndFile(currentPath);
            ReloadToolStripMenuItem_Click(null, null);
        }

        private void AddToQuickAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.AddQuickAccessFolderToList(Path.Combine(currentPath, dataGridViewFileManager[1, dataGridViewFileManager.SelectedRows[0].Index].Value.ToString()));
            dataGridViewVisualise.PrintQuickAccessFolders();
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPath == null)
                dataGridViewVisualise.PrintDisks();
            else
                dataGridViewVisualise.PrintFilesAndFolder(ref currentPath);
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.RemoveQuickAccessFolder(dataGridViewQuickAccessFolders.SelectedRows[0].Index - 1);
            dataGridViewVisualise.PrintQuickAccessFolders();
        }

        private void dataGridViewQuickAccessFolders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
                dataGridViewQuickAccessFolders.Rows[e.RowIndex].Selected = true;
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Ви впевнені, що хочете видалити ?", "Попередження", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            dataGridViewVisualise.DeleteDirectoryOrFileFromDataGrid(currentPath, dataGridViewFileManager);
            ReloadToolStripMenuItem_Click(null, null);
        }

        private void NewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.AddNewRowForNewFolder(currentPath);
        }

        private void dataGridViewFileManager_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFileManager[2, dataGridViewFileManager.SelectedRows[0].Index].Value == null) 
                    dataGridViewVisualise.CreateNewFolder(currentPath, dataGridViewFileManager[1, dataGridViewFileManager.Rows.Count - 1].Value.ToString());
            else
            {
                dataGridViewVisualise.RenameFileOfFolderInDataGrid(ref currentPath);
            }
            dataGridViewVisualise.PrintFilesAndFolder(ref currentPath);
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewFileManager.CurrentCell = dataGridViewFileManager.Rows[dataGridViewFileManager.SelectedRows[0].Index].Cells[1];
            dataGridViewFileManager.BeginEdit(true);
        }
    }
}
