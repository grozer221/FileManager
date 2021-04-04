using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public class DataGridViewVisualise : ClassFileManager
    {

        private DataGridView DataGridViewFileManager;
        private DataGridView DataGridViewQuickAccessFolders;
        private List<string> ListVisualisedItems = new List<string>();

        public DataGridViewVisualise(DataGridView DataGridViewFileManager, DataGridView DataGridViewQuickAccessFolders)
        {
            this.DataGridViewFileManager = DataGridViewFileManager;
            this.DataGridViewQuickAccessFolders = DataGridViewQuickAccessFolders;
        }

        public void PrintDisks()
        {
            DataGridViewFileManager.DataSource = GetDisksInObj(ref ListVisualisedItems);
            SetSizeForDataGrid();
            SetReadOnlyForDisks();
            DataGridViewFileManager.SelectedRows[0].Selected = false;
        }

        public void PrintFilesAndFolder(ref string currentPath)
        {
            try
            {
                DataGridViewFileManager.DataSource = GetFilesAndFoldersInObj(currentPath, ref ListVisualisedItems);
            }
            catch
            {
                MessageBox.Show("Доступ заборонено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentPath = Directory.GetParent(currentPath).ToString();
                PrintFilesAndFolder(ref currentPath);
            }
            SetSizeForDataGrid();
            SetReadOnlyForFilesAndFolders();
            DataGridViewFileManager.SelectedRows[0].Selected = false;
        }

        public void SetReadOnlyForDisks()
        {
            DataGridViewFileManager.Columns[0].ReadOnly = true;
            DataGridViewFileManager.Columns[1].ReadOnly = true;
            DataGridViewFileManager.Columns[2].ReadOnly = true;
            DataGridViewFileManager.Columns[3].ReadOnly = true;
            DataGridViewFileManager.Columns[4].ReadOnly = true;
        }

        public void SetReadOnlyForFilesAndFolders()
        {
            DataGridViewFileManager.Columns[0].ReadOnly = true;
            DataGridViewFileManager.Columns[1].ReadOnly = false;
            DataGridViewFileManager.Columns[2].ReadOnly = true;
            DataGridViewFileManager.Columns[3].ReadOnly = true;
            DataGridViewFileManager.Columns[4].ReadOnly = true;
        }

        public void SetSizeForDataGrid()
        {
            for (int i = 0; i < DataGridViewFileManager.RowCount; i++)
                DataGridViewFileManager.Rows[i].Height = 25;
            DataGridViewFileManager.Columns[0].Width = 25;
            DataGridViewFileManager.Columns[1].Width = 250;
            DataGridViewFileManager.Columns[2].Width = 175;
            DataGridViewFileManager.Columns[3].Width = 115;
            DataGridViewFileManager.Columns[4].Width = 110;
            DataGridViewFileManager.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void CellDoubleClick(DataGridViewCellEventArgs e, ref string currentPath)
        {
            try
            {
                if (Directory.Exists(ListVisualisedItems[e.RowIndex - 1]))
                {
                    currentPath = ListVisualisedItems[e.RowIndex - 1];
                    PrintFilesAndFolder(ref currentPath);
                }
                else if (File.Exists(ListVisualisedItems[e.RowIndex - 1]))
                    Process.Start(ListVisualisedItems[e.RowIndex - 1]);
            }
            catch { }
        }

        public void StepBack(ref string currentPath)
        {
            try
            {
                currentPath = Directory.GetParent(currentPath).FullName;
                PrintFilesAndFolder(ref currentPath);
            }
            catch
            {
                currentPath = null;
                PrintDisks();
            }
        }

        public void PrintQuickAccessFolders()
        {
            DataGridViewQuickAccessFolders.DataSource = GetQuickAccessFoldersInObjs();
            DataGridViewQuickAccessFolders.ClearSelection();
            DataGridViewQuickAccessFolders.Columns[0].Width = 25;
            DataGridViewQuickAccessFolders.Columns[1].Width = 150;
            for (int i = 0; i < DataGridViewQuickAccessFolders.RowCount; i++)
                DataGridViewQuickAccessFolders.Rows[i].Height = 25;
        }

        public void dataGridQuickAccessCellMouseClick(DataGridViewCellMouseEventArgs e, ref string currentPath)
        {
            DataGridViewQuickAccessFolders.ClearSelection();
            if (e.RowIndex == 0 || DataGridViewQuickAccessFolders[1, e.RowIndex].Value == null)
                return;

            if (e.RowIndex == DataGridViewQuickAccessFolders.Rows.Count - 1)
            {
                currentPath = "";
                PrintDisks();
                return;
            }

            //if (!Directory.Exists(ListQuickAccessFolders[e.RowIndex - 1]))
            //{
            //    if (MessageBox.Show("Папка була видалена.\nВидалили із швидкого доступу?", "Попередження", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            //    {
            //        fileManager.RemoveQuickAccessFolder(e.RowIndex - 1);
            //        fileManager.PrintQuickAccessFolders();
            //        return;
            //    }
            //    else
            //        return;
            //}
            currentPath = GetListQuickAccessFolders()[e.RowIndex - 1];
            PrintFilesAndFolder(ref currentPath);
        }

        public void SearchDirectory(ref string currentPath)
        {
            if (currentPath == null)
                PrintDisks();
            else if (Regex.IsMatch(currentPath, @"^[A-Z\|a-z]:$"))
            {
                currentPath = null;
                PrintDisks();
            }
            else if (Directory.Exists(currentPath))
            {
                currentPath = new DirectoryInfo(currentPath).FullName;
                PrintFilesAndFolder(ref currentPath);
            }
            else if (File.Exists(currentPath))
            {
                Process.Start(currentPath);
                currentPath = Directory.GetParent(currentPath).ToString();
            }
            else
                throw new Exception();
        }


        public void AddNewRowForNewFolder(string currentPath)
        {
            DataGridViewFileManager.DataSource = GetFilesAndFoldersInObj(currentPath, ref ListVisualisedItems, "CreateNewFolder");
            SetSizeForDataGrid();
           
            DataGridViewFileManager.CurrentCell = DataGridViewFileManager.Rows[DataGridViewFileManager.Rows.Count - 1].Cells[1];
            DataGridViewFileManager.BeginEdit(true);
        }

        public void RenameFileOfFolderInDataGrid(ref string currentPath)
        {
            if (DataGridViewFileManager[1, DataGridViewFileManager.SelectedRows[0].Index].Value.ToString() == new DirectoryInfo(ListVisualisedItems[DataGridViewFileManager.SelectedRows[0].Index - 1]).Name ||
               DataGridViewFileManager[1, DataGridViewFileManager.SelectedRows[0].Index].Value.ToString() == new FileInfo(ListVisualisedItems[DataGridViewFileManager.SelectedRows[0].Index - 1]).Name)
                return;
            if (Directory.Exists($@"{currentPath}\{DataGridViewFileManager[1, DataGridViewFileManager.SelectedRows[0].Index].Value}") || File.Exists($@"{currentPath}\{DataGridViewFileManager[1, DataGridViewFileManager.SelectedRows[0].Index].Value}"))
            {
                MessageBox.Show($"Файл або папка з іменем {DataGridViewFileManager[1, DataGridViewFileManager.SelectedRows[0].Index].Value} вже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PrintFilesAndFolder(ref currentPath);
                return;
            }
            RenameFolderOfFile(ListVisualisedItems[DataGridViewFileManager.SelectedRows[0].Index - 1], $@"{currentPath}\{DataGridViewFileManager[1, DataGridViewFileManager.SelectedRows[0].Index].Value}");
            PrintFilesAndFolder(ref currentPath);
        }







    }
}
