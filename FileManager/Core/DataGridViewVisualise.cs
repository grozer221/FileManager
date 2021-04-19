using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
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

        public DataGridViewVisualise(DataGridView DataGridViewFileManager)
        {
            this.DataGridViewFileManager = DataGridViewFileManager;
        }

        public void PrintDisks()
        {
            DataGridViewFileManager.DataSource = GetDisksInListOfObj(ref ListVisualisedItems);
            SetSizeForDataGrid();
            SetReadOnlyForDisks();
            DataGridViewFileManager.SelectedRows[0].Selected = false;
        }

        public void PrintFilesAndFolder(ref string currentPath, bool showHiddenFilesAndFolders = false)
        {
            try
            {
                DataGridViewFileManager.DataSource = GetFilesAndFoldersInListOfObj(currentPath, ref ListVisualisedItems, null, showHiddenFilesAndFolders);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentPath = Directory.GetParent(currentPath).ToString();
                PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
            }
            SetSizeForDataGrid();
            SetReadOnlyForFilesAndFolders();
            DataGridViewFileManager.SelectedRows[0].Selected = false;
            DataGridViewFileManager[1, 0].ReadOnly = true;
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

        public List<string> GetListVisualisedItems()
        {
            return ListVisualisedItems;
        }

        public void CellDoubleClick(int rowIndex, ref string currentPath, bool showHiddenFilesAndFolders = false)
        {
            try
            {
                if (Directory.Exists(ListVisualisedItems[rowIndex - 1]))
                {
                    currentPath = ListVisualisedItems[rowIndex - 1];
                    PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
                }
                else if (File.Exists(ListVisualisedItems[rowIndex - 1]))
                    Process.Start(ListVisualisedItems[rowIndex - 1]);
            }
            catch { }
        }

        public void StepBack(ref string currentPath, bool showHiddenFilesAndFolders = false)
        {
            string currentFolderName = new DirectoryInfo(currentPath).Name;
            try
            {
                currentPath = Directory.GetParent(currentPath).FullName;
                PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
            }
            catch
            {
                currentPath = null;
                PrintDisks();
            }
            SelectPreviusChoseFolder(currentFolderName);
        }

        public void SelectPreviusChoseFolder(string currentFolderName)
        {
            for (int i = 0; i < DataGridViewFileManager.Rows.Count; i++)
                if (DataGridViewFileManager[1, i].Value.ToString() == currentFolderName)
                    DataGridViewFileManager.Rows[i].Selected = true;
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

        public void dataGridQuickAccessCellMouseClick(DataGridViewCellMouseEventArgs e, ref string currentPath, bool showHiddenFilesAndFolders = false)
        {
            DataGridViewQuickAccessFolders.ClearSelection();
            if (e.RowIndex == 0 || DataGridViewQuickAccessFolders[1, e.RowIndex].Value == null)
                return;

            if (e.RowIndex == DataGridViewQuickAccessFolders.Rows.Count - 2)
            {
                currentPath = "";
                PrintDisks();
                return;
            }

            if (e.RowIndex == DataGridViewQuickAccessFolders.Rows.Count - 1)
            {
                try
                {
                    string pathToGame = Path.Combine(Environment.CurrentDirectory, "PlumberGame.exe");
                    FileStream fs = new FileStream(pathToGame, FileMode.OpenOrCreate);
                    fs.Write(FileManager.Properties.Resources.PlumberGame, 0, FileManager.Properties.Resources.PlumberGame.Length);
                    fs.Close();
                    Process.Start(pathToGame);
                }
                catch { }
                return;
            }

            if (!Directory.Exists(FileManager.Properties.Settings.Default.ListQuickAccessFolder[e.RowIndex - 1]))
            {
                if (MessageBox.Show("Дана папка була видалена.\nВидалили із швидкого доступу?", "Попередження", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    RemoveQuickAccessFolder(e.RowIndex - 1);
                    PrintQuickAccessFolders();
                }
                return;
            }

            currentPath = FileManager.Properties.Settings.Default.ListQuickAccessFolder[e.RowIndex - 1];
            PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
        }

        public void SearchDirectory(ref string currentPath, bool showHiddenFilesAndFolders = false)
        {
            if (Regex.IsMatch(currentPath, @"^[A-Z\|a-z]:$"))
                throw new Exception();
            if (currentPath == null)
                PrintDisks();

            else if (Directory.Exists(currentPath))
            {
                currentPath = new DirectoryInfo(currentPath).FullName;
                PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
            }
            else if (File.Exists(currentPath))
            {
                Process.Start(currentPath);
                currentPath = Directory.GetParent(currentPath).ToString();
            }
            else
                throw new Exception();
        }

        public void AddNewRowForNewFolder(string currentPath, bool showHiddenFilesAndFolders)
        {
            DataGridViewFileManager.DataSource = GetFilesAndFoldersInListOfObj(currentPath, ref ListVisualisedItems, "CreateNewFolder", showHiddenFilesAndFolders);
            SetSizeForDataGrid();
           
            DataGridViewFileManager.CurrentCell = DataGridViewFileManager.Rows[DataGridViewFileManager.Rows.Count - 1].Cells[1];
            DataGridViewFileManager.BeginEdit(true);
        }

        public void RenameFileOrFolderInDataGrid(ref string currentPath, DataGridViewCellEventArgs e, bool showHiddenFilesAndFolders = false)
        {
            if (DataGridViewFileManager[1, e.RowIndex].Value.ToString() == new DirectoryInfo(ListVisualisedItems[e.RowIndex - 1]).Name ||
               DataGridViewFileManager[1, e.RowIndex].Value.ToString() == new FileInfo(ListVisualisedItems[e.RowIndex - 1]).Name)
                return;
            if (Directory.Exists(Path.Combine(currentPath, DataGridViewFileManager[e.ColumnIndex, e.RowIndex].Value.ToString())) || File.Exists(Path.Combine(currentPath, DataGridViewFileManager[e.ColumnIndex, e.RowIndex].Value.ToString()))) 
            {
                MessageBox.Show($"Файл або папка з іменем {DataGridViewFileManager[e.ColumnIndex, e.RowIndex].Value} вже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
                return;
            }
            RenameFolderOfFile(ListVisualisedItems[e.RowIndex - 1], Path.Combine(currentPath, DataGridViewFileManager[e.ColumnIndex, e.RowIndex].Value.ToString()));
        }
    }
}
