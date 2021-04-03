using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public class DataGridViewVisualise : ClassFileManager
    {

        private DataGridView DataGridViewFileManager;
        List<string> listVisualisedItems = new List<string>();

        public DataGridViewVisualise(DataGridView DataGridViewFileManager)
        {
            this.DataGridViewFileManager = DataGridViewFileManager;
        }

        public void PrintDisks()
        {
            DataGridViewFileManager.DataSource = GetDisksInObj(ref listVisualisedItems);
            SetSizeForDataGrid();
            SetReadOnlyForDisks();
        }

        public void PrintFilesAndFolder(ref string currentPath)
        {
            try
            {
                DataGridViewFileManager.DataSource = GetFilesAndFoldersInObj(currentPath, ref listVisualisedItems);
            }
            catch
            {
                MessageBox.Show("Доступ заборонено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentPath = Directory.GetParent(currentPath).ToString();
                PrintFilesAndFolder(ref currentPath);
            }
            SetSizeForDataGrid();
            SetReadOnlyForFilesAndFolders();
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
            DataGridViewFileManager.Columns[3].Width = 100;
            DataGridViewFileManager.Columns[4].Width = 100;
            DataGridViewFileManager.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void CellDoubleClick(DataGridViewCellEventArgs e, ref string currentPath)
        {
            try
            {
                if (Directory.Exists(listVisualisedItems[e.RowIndex - 1]))
                {
                    currentPath = listVisualisedItems[e.RowIndex - 1];
                    PrintFilesAndFolder(ref currentPath);
                }
                else if (File.Exists(listVisualisedItems[e.RowIndex - 1]))
                    Process.Start(listVisualisedItems[e.RowIndex - 1]);
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
    }
}
