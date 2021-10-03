using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Core
{
    public class DataGridViewVisualise : ClassFileManager
    {

        private DataGridView DataGridViewFileManager;
        private DataGridView DataGridViewQuickAccessFolders;
        public List<string> ListVisualisedItems = new List<string>();//список відображених дисків/папок/файлів
        public bool IsEnableSearchMode = false;//чи увімкнений режим пошуку

        public DataGridViewVisualise(DataGridView DataGridViewFileManager, DataGridView DataGridViewQuickAccessFolders)//конструктор1
        {
            this.DataGridViewFileManager = DataGridViewFileManager;
            this.DataGridViewQuickAccessFolders = DataGridViewQuickAccessFolders;
        }

        public DataGridViewVisualise(DataGridView DataGridViewFileManager)//конструктор
        {
            this.DataGridViewFileManager = DataGridViewFileManager;
        }

        public void ClearDataGridView()//очистити DatagridViewFileManager
        {
            if (DataGridViewFileManager.DataSource == null)
            {
                DataGridViewFileManager.Rows.Clear();
                DataGridViewFileManager.Columns.Clear();
            }
            else
                DataGridViewFileManager.DataSource = null;
        }

        public void PrintDisks()//відобразити диски в DataGridViewFileManager
        {
            DataGridViewFileManager.DataSource = GetDisksInListOfObj(ref ListVisualisedItems);
            SetSizeForDataGrid();
            SetReadOnlyForDisks();
            DataGridViewFileManager.SelectedRows[0].Selected = false;
        }

        public void PrintFilesAndFolder(ref string currentPath, bool showHiddenFilesAndFolders = false)//відобразити папки та файли
        {
            try
            {
                if(DataGridViewFileManager.DataSource == null)
                {
                    DataGridViewFileManager.Rows.Clear();
                    DataGridViewFileManager.Columns.Clear();
                }
                DataGridViewFileManager.DataSource = GetFilesAndFoldersInListOfObj(currentPath, ref ListVisualisedItems, null, showHiddenFilesAndFolders);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                try { currentPath = Directory.GetParent(currentPath).ToString(); }
                catch { return; }
                PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
            }
            SetSizeForDataGrid();
            SetReadOnlyForFilesAndFolders();
            DataGridViewFileManager.SelectedRows[0].Selected = false;
            DataGridViewFileManager[1, 0].ReadOnly = true;
        }

        public void SetReadOnlyForDisks()//встановлення для колонок дисків readonly
        {
            DataGridViewFileManager.Columns[0].ReadOnly = true;
            DataGridViewFileManager.Columns[1].ReadOnly = true;
            DataGridViewFileManager.Columns[2].ReadOnly = true;
            DataGridViewFileManager.Columns[3].ReadOnly = true;
            DataGridViewFileManager.Columns[4].ReadOnly = true;
        }

        public void SetReadOnlyForFilesAndFolders()//встановлення для колонок папок/файлів readonly
        {
            DataGridViewFileManager.Columns[0].ReadOnly = true;
            DataGridViewFileManager.Columns[1].ReadOnly = false;
            DataGridViewFileManager.Columns[2].ReadOnly = true;
            DataGridViewFileManager.Columns[3].ReadOnly = true;
            DataGridViewFileManager.Columns[4].ReadOnly = true;
        }

        public void SetSizeForDataGrid()//встановити розмір комірок 
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

        public void CellDoubleClick(int rowIndex, ref string currentPath, bool showHiddenFilesAndFolders = false)//після подійного кліку по комірці або відобразиться вміст директорії, або відкриється файл
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

        public void StepBack(ref string currentPath, bool showHiddenFilesAndFolders = false)//повернутися в батьківську директорію
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

        public void SelectPreviusChoseFolder(string currentFolderName)//виділити в батьківській директорії папки з якої поверулися
        {
            for (int i = 0; i < DataGridViewFileManager.Rows.Count; i++)
                if (DataGridViewFileManager[1, i].Value.ToString() == currentFolderName)
                    DataGridViewFileManager.Rows[i].Selected = true;
        }

        public void PrintQuickAccessFolders()//відобразити папки швидкого доступу
        {
            DataGridViewQuickAccessFolders.DataSource = GetQuickAccessFoldersInObjs();
            DataGridViewQuickAccessFolders.ClearSelection();
            DataGridViewQuickAccessFolders.Columns[0].Width = 25;
            DataGridViewQuickAccessFolders.Columns[1].Width = 150;
            for (int i = 0; i < DataGridViewQuickAccessFolders.RowCount; i++)
                DataGridViewQuickAccessFolders.Rows[i].Height = 25;
        }

        public void dataGridQuickAccessCellMouseClick(int rowIndex, ref string currentPath, bool showHiddenFilesAndFolders = false)//дії які дібдубуться після кліку по папці швидкого доступу
        {
            DataGridViewQuickAccessFolders.ClearSelection();
            if (rowIndex == 0 || DataGridViewQuickAccessFolders[1, rowIndex].Value == null)
                return;

            if (rowIndex == DataGridViewQuickAccessFolders.Rows.Count - 2)
            {
                currentPath = null;
                StopPrintSearchedFiles();
                ClearDataGridView();
                PrintDisks();
                return;
            }

            if (rowIndex == DataGridViewQuickAccessFolders.Rows.Count - 1)
            {
                try
                {
                    string pathToGame = "PlumberGame.exe";
                    using (FileStream fs = new FileStream(pathToGame, FileMode.OpenOrCreate))
                        fs.Write(FileManager.Properties.Resources.Plumber_Game, 0, FileManager.Properties.Resources.Plumber_Game.Length); 
                    using (FileStream fs = new FileStream("Newtonsoft.Json.dll", FileMode.OpenOrCreate))
                        fs.Write(FileManager.Properties.Resources.Newtonsoft_Json, 0, FileManager.Properties.Resources.Newtonsoft_Json.Length); 
                    Process.Start(pathToGame);
                }
                catch { }
                return;
            }

            if (!Directory.Exists(FileManager.Properties.Settings.Default.ListQuickAccessFolder[rowIndex - 1]))
            {
                if (MessageBox.Show("Дана папка була видалена.\nВидалили із швидкого доступу?", "Попередження", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    RemoveQuickAccessFolder(rowIndex - 1);
                    PrintQuickAccessFolders();
                }
                return;
            }

            currentPath = FileManager.Properties.Settings.Default.ListQuickAccessFolder[rowIndex - 1];
            PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
        }

        public void SearchDirectory(ref string currentPath, bool showHiddenFilesAndFolders = false)//відкрити директорію введену вручну
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

        public void AddNewRowForNewFolder(string currentPath, bool showHiddenFilesAndFolders)//додати новий рядок для створення папки
        {
            DataGridViewFileManager.DataSource = GetFilesAndFoldersInListOfObj(currentPath, ref ListVisualisedItems, "CreateNewFolder", showHiddenFilesAndFolders);
            SetSizeForDataGrid();
           
            DataGridViewFileManager.CurrentCell = DataGridViewFileManager.Rows[DataGridViewFileManager.Rows.Count - 1].Cells[1];
            DataGridViewFileManager.BeginEdit(true);
        }

        public void RenameFileOrFolderInDataGrid(ref string currentPath, int rowIndex, bool showHiddenFilesAndFolders = false)//перейменування папки
        {
            if (DataGridViewFileManager[1, rowIndex].Value.ToString() == new DirectoryInfo(ListVisualisedItems[rowIndex - 1]).Name ||
               DataGridViewFileManager[1, rowIndex].Value.ToString() == new FileInfo(ListVisualisedItems[rowIndex - 1]).Name)
                return;
            if (Directory.Exists(Path.Combine(currentPath, DataGridViewFileManager[1, rowIndex].Value.ToString())) || File.Exists(Path.Combine(currentPath, DataGridViewFileManager[1, rowIndex].Value.ToString()))) 
            {
                MessageBox.Show($"Файл або папка з іменем {DataGridViewFileManager[1, rowIndex].Value} вже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PrintFilesAndFolder(ref currentPath, showHiddenFilesAndFolders);
                return;
            }
            RenameFolderOfFile(ListVisualisedItems[rowIndex - 1], Path.Combine(currentPath, DataGridViewFileManager[1, rowIndex].Value.ToString()));
        }

        public List<string> GetSelectedFilesInDataGrid(string currenPath)//отримати список вибаних файлів
        {
            List<string> ListPathsToCopiedFoldersAndFiles = new List<string>();
            for (int i = 0; i < DataGridViewFileManager.SelectedRows.Count; i++)
            {
                if (DataGridViewFileManager.SelectedRows[i].Index == 0)
                    continue;
                ListPathsToCopiedFoldersAndFiles.Add(Path.Combine(currenPath, DataGridViewFileManager[1, DataGridViewFileManager.SelectedRows[i].Index].Value.ToString()));
            }
            return ListPathsToCopiedFoldersAndFiles;
        }


        private static CancellationTokenSource cts;
        private static CancellationToken token;

        public void StopPrintSearchedFiles()//зупинити пошук файлів по імені
        {
            try { cts.Cancel(); }
            catch { }
        }

        public async void PrintSearchedFilesAsync(string currentPath, string nameSearchedFile, bool showHiddenFilesAndFolders = false)//відобразити асинхронно найдені файли по імені
        {
            cts = new CancellationTokenSource();
            token = cts.Token;
            if (token.IsCancellationRequested)
                return;
            IsEnableSearchMode = true;
            DataGridViewFileManager.Columns.Add(new DataGridViewImageColumn());
            for(int i = 0; i < 4; i++)
                DataGridViewFileManager.Columns.Add(new DataGridViewTextBoxColumn());
            SetSizeForDataGrid();
            DataGridViewFileManager.Rows.Add(new Bitmap(GetEmptyImage(EnabledNightMode ? Color.FromArgb(14, 22, 33) : Color.FromArgb(230, 230, 230)), 25, 25), "Назва", "Шлях", "Тип", "Розмір");
            ListVisualisedItems.Clear();
            await Task.Run(() => PrintSearchedFiles(currentPath, nameSearchedFile, showHiddenFilesAndFolders));
        }

        public void PrintSearchedFiles(string currentPath, string nameSearchedFile, bool showHiddenFilesAndFolders = false)//відобразити знайдені файли по імені
        {
            if (token.IsCancellationRequested)
                return;

            if(currentPath == null)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                    PrintSearchedFiles(drive.Name, nameSearchedFile, showHiddenFilesAndFolders);
                return;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(currentPath);
            try
            {
                DirectoryInfo[] dirs = dirInfo.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    if (dir.Attributes.HasFlag(FileAttributes.System))
                        continue;

                    if (!showHiddenFilesAndFolders && dir.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;

                    PrintSearchedFiles(dir.FullName, nameSearchedFile, showHiddenFilesAndFolders);

                    Regex regex = new Regex($@"(.*)({nameSearchedFile})(.*)", RegexOptions.IgnoreCase);
                    if (regex.IsMatch(dir.Name))
                    {
                        DataGridViewFileManager.Invoke(new Action(() => {
                            Bitmap bitmap;
                            if (dir.Attributes.HasFlag(FileAttributes.Hidden))
                                bitmap = new Bitmap(FileManager.Properties.Resources.folderWithOpacity, 20, 20);
                            else
                                bitmap = new Bitmap(FileManager.Properties.Resources.documents_folder_18875, 20, 20);

                            Match match = regex.Match(dir.Name);
                            string dirName = match.Groups[1].Value + "(" + match.Groups[2].Value + ")" + match.Groups[3].Value;
                            DataGridViewFileManager.Rows.Add(bitmap, dirName, dir.FullName, "Папка", "");
                            ListVisualisedItems.Add(dir.FullName);
                        }));
                    }
                }
            }
            catch { }
            try
            {
                FileInfo[] files = dirInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Attributes.HasFlag(FileAttributes.System))
                        continue;

                    if (!showHiddenFilesAndFolders && file.Attributes.HasFlag(FileAttributes.Hidden))
                        continue;

                    Regex regex = new Regex($@"(.*)({nameSearchedFile})(.*)", RegexOptions.IgnoreCase);
                    if (regex.IsMatch(file.Name))
                    {
                        DataGridViewFileManager.Invoke(new Action(() =>
                        {
                            Bitmap bitmap;
                            if (file.Attributes.HasFlag(FileAttributes.Hidden))
                                bitmap = ToDarkerColor(new Bitmap(Icon.ExtractAssociatedIcon(file.FullName).ToBitmap(), 20, 20));
                            else
                                bitmap = new Bitmap(Icon.ExtractAssociatedIcon(file.FullName).ToBitmap(), 20, 20);

                            Match match = regex.Match(file.Name);
                            string fileName = match.Groups[1].Value + "(" + match.Groups[2].Value + ")" + match.Groups[3].Value;

                            DataGridViewFileManager.Rows.Add(bitmap, fileName, file.FullName, "Файл", GetSizeInPropertyType(file.Length));
                            ListVisualisedItems.Add(file.FullName);
                        }));
                    }
                }
            }
            catch { }
        }
    }
}
