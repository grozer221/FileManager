using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public class ClassFileManager : IStructureTableFileManager, IStructureQuickAccessFolders
    {
        private List<string> ListQuickAccessFolders = new List<string>();
        private string[] CollectionPathsToCopiedFoldersAndFiles;

        public List<StructureTableFileManager> GetDisksInObj(ref List<string> listVisualisedItems)
        {
            listVisualisedItems.Clear();
            List<StructureTableFileManager> listDisks = new List<StructureTableFileManager>();
            listDisks.Add(new StructureTableFileManager { Image = GetEmptyImage(Color.FromArgb(14, 22, 33)), Name = "Назва", FormatOrDateLastChanged = "Формат", TotalFreeSpaceOrType = "Вільного місця", TotalSize = "Повний об`єм" });
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                listDisks.Add(new StructureTableFileManager { Image = new Bitmap(Properties.Resources.hard_drive_29228, 25, 25), Name = drive.Name, FormatOrDateLastChanged = drive.DriveFormat, TotalFreeSpaceOrType = GetSizeInPropertyType(drive.TotalFreeSpace), TotalSize = GetSizeInPropertyType(drive.TotalSize) });
                listVisualisedItems.Add(drive.Name);
            }
            return listDisks;
        }

        public string[] GetCollectionPathsToCopiedFoldersAndFiles() { return CollectionPathsToCopiedFoldersAndFiles; }
        public List<StructureTableFileManager> GetFilesAndFoldersInObj(string currentPath, ref List<string> listVisualisedItems,string args = null)
        {
            listVisualisedItems.Clear();
            List<StructureTableFileManager> listFilesAndFolders = new List<StructureTableFileManager>();
            DirectoryInfo dirInfo = new DirectoryInfo(currentPath);
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            FileInfo[] files = dirInfo.GetFiles();
            listFilesAndFolders.Add(new StructureTableFileManager { Image = GetEmptyImage(Color.FromArgb(14, 22, 33)), Name = "Назва", FormatOrDateLastChanged = "Дата зміни", TotalFreeSpaceOrType = "Тип", TotalSize = "Розмір" });
            foreach (DirectoryInfo dir in dirs)
            {
                listFilesAndFolders.Add(new StructureTableFileManager { Image = new Bitmap(Properties.Resources.documents_folder_18875, 20, 20), Name = dir.Name, FormatOrDateLastChanged = dir.LastWriteTime.ToString(), TotalFreeSpaceOrType = "Папка", TotalSize = "" });
                listVisualisedItems.Add(dir.FullName);
            }
            foreach (FileInfo file in files)
            {
                listFilesAndFolders.Add(new StructureTableFileManager { Image = new Bitmap(Icon.ExtractAssociatedIcon(file.FullName).ToBitmap(), 20, 20), Name = file.Name, FormatOrDateLastChanged = file.LastWriteTime.ToString(), TotalFreeSpaceOrType = "Файл", TotalSize = GetSizeInPropertyType(file.Length) });
                listVisualisedItems.Add(file.FullName);
            }

            if(args == "CreateNewFolder")
                listFilesAndFolders.Add(new StructureTableFileManager { Image = new Bitmap(Properties.Resources.documents_folder_18875, 20, 20) });

            return listFilesAndFolders;
        }

        public Bitmap GetEmptyImage(Color color)
        {
            var bmp = new Bitmap(25, 25);
            using (var g = Graphics.FromImage(bmp))
                g.Clear(color);
            return bmp;
        }

        public string GetSizeInPropertyType(long fileLength)
        {
            if (fileLength / 1000000000 > 1)
                return fileLength / 1000000000 + " ГБ";
            else if (fileLength / 1000000 > 1)
                return fileLength / 1000000 + " МБ";
            else if (fileLength / 1000 > 1)
                return fileLength / 1000 + " КБ";
            else
                return fileLength + " Б";
        }

        public List<string> GetListQuickAccessFolders()
        {
            return ListQuickAccessFolders;
        }

        public void GetListQuickAccessFoldersFromFile()
        {
            using (FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, "ListQuickAccessFolders.txt"), FileMode.OpenOrCreate))
                using (StreamReader stream = new StreamReader(fs))
                    while (!stream.EndOfStream)
                       ListQuickAccessFolders.Add(stream.ReadLine());
        }

        public List<StructureQuickAccessFolders> GetQuickAccessFoldersInObjs()
        {
            List<StructureQuickAccessFolders> listQuickAccessFoldersInObj = new List<StructureQuickAccessFolders>();
            listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = "Швидкий доступ" });
            foreach (string quickAccessFolder in ListQuickAccessFolders)
                listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = new Bitmap(Properties.Resources.documents_folder_18875, 20, 20), Name = new DirectoryInfo(quickAccessFolder).Name });
            listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = null});
            listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = new Bitmap(Properties.Resources.mypc, 20, 20), Name = "Мій комп'ютер" });
            return listQuickAccessFoldersInObj;
        }



        public void AddQuickAccessFolderToList(string pathSelectedFolder)
        {
            foreach (string folder in ListQuickAccessFolders)
            {
                if (folder == pathSelectedFolder)
                {
                    MessageBox.Show($"Дана папка в швидкому доступі уже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            using (StreamWriter stream = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "ListQuickAccessFolders.txt"), true))
                stream.WriteLine(pathSelectedFolder);
            ListQuickAccessFolders.Add(pathSelectedFolder);
        }

        public void RemoveQuickAccessFolder(int selectedRowIndex)
        {
            ListQuickAccessFolders.RemoveAt(selectedRowIndex);
            using (StreamWriter stream = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "ListQuickAccessFolders.txt"), false))
                foreach (string folder in ListQuickAccessFolders)
                    stream.WriteLine(folder);
        }


        public void GetFilesAndFolderForCopyFromDataGrid(string currenPath, DataGridView dataGridView)
        {
            int selectedRowsCount = dataGridView.SelectedRows.Count;
            CollectionPathsToCopiedFoldersAndFiles = new string[selectedRowsCount];
            int j = 0;
            for (int i = 0; i < selectedRowsCount; i++)
            {
                if (dataGridView.SelectedRows[j].Index == 0)
                    j++;
                CollectionPathsToCopiedFoldersAndFiles[i] = $@"{currenPath}\{dataGridView[1, dataGridView.SelectedRows[j].Index].Value}";
                j++;
            }
        }

        public void PasteCopiedFoldersAndFile(string currentPath)
        {
            for (int i = 0; i < CollectionPathsToCopiedFoldersAndFiles.Length; i++)
            {
                try
                {
                    if (new DirectoryInfo(CollectionPathsToCopiedFoldersAndFiles[i]).FullName == currentPath)
                    {
                        MessageBox.Show($"Скопійована папка {new DirectoryInfo(CollectionPathsToCopiedFoldersAndFiles[i]).Name} є субпапкою вибраної", "Перервана дія", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                    if (Directory.Exists(CollectionPathsToCopiedFoldersAndFiles[i]))
                        PasteFolderOrFile(CollectionPathsToCopiedFoldersAndFiles[i], $@"{currentPath}\{new DirectoryInfo(CollectionPathsToCopiedFoldersAndFiles[i]).Name}");
                    else
                        PasteFolderOrFile(CollectionPathsToCopiedFoldersAndFiles[i], $@"{currentPath}\{new FileInfo(CollectionPathsToCopiedFoldersAndFiles[i]).Name}");
                }
                catch { MessageBox.Show("Невідома помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        public void PasteFolderOrFile(string sourcePath, string destPath)
        {
            while (Directory.Exists(destPath))
                destPath += " - Copy";

            while (File.Exists(destPath))
            {
                FileInfo fileinfo = new FileInfo(destPath);
                destPath = destPath.Replace(fileinfo.Extension, "");
                destPath += $" - Copy{fileinfo.Extension}";
            }

            if (File.Exists(sourcePath))
                File.Copy(sourcePath, destPath, true);
            else if (Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(destPath);
                CopyDirectory(sourcePath, destPath);
            }
            else
                MessageBox.Show("Невідома помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CopyDirectory(string sourceFileName, string destFileName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(sourceFileName);
            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                if (Directory.Exists(destFileName + "\\" + dir.Name) != true)
                {
                    Directory.CreateDirectory(destFileName + "\\" + dir.Name);
                }
                //Рекурсия (перебираем вложенные папки и делаем для них то-же самое).
                CopyDirectory(dir.FullName, destFileName + "\\" + dir.Name);
            }
            foreach (string file in Directory.GetFiles(sourceFileName))
            {
                string fileName = file.Substring(file.LastIndexOf('\\'), file.Length - file.LastIndexOf('\\'));
                File.Copy(file, destFileName + fileName, true);
            }
        }

        public void DeleteDirectoryOrFileFromDataGrid(string currentPath, DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
            {
                try
                {
                    if (File.Exists($@"{currentPath}\{dataGridView[1, dataGridView.SelectedRows[i].Index].Value}"))
                        File.Delete($@"{currentPath}\{dataGridView[1, dataGridView.SelectedRows[i].Index].Value}");
                    else if (Directory.Exists($@"{currentPath}\{dataGridView[1, dataGridView.SelectedRows[i].Index].Value}"))
                        Directory.Delete($@"{currentPath}\{dataGridView[1, dataGridView.SelectedRows[i].Index].Value}", true);
                }
                catch
                {
                    MessageBox.Show($"Недостатньо прав для " + Path.GetFileName($@"{currentPath}\{dataGridView[1, dataGridView.SelectedRows[i].Index].Value}"), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CreateNewFolder(string currentPath, string folderName)
        {
            if (folderName == "" || folderName == null)
                return;
            if (Directory.Exists(Path.Combine(currentPath, folderName)))
            {
                MessageBox.Show($"Файл або папка з іменем {folderName} вже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Directory.CreateDirectory(Path.Combine(currentPath, folderName));
        }

        public void RenameFolderOfFile(string pathFolderOrFile, string pathNewFolderOrFile)
        {
            if (pathNewFolderOrFile == null || pathNewFolderOrFile == "")
                return;

            if (Directory.Exists(pathFolderOrFile))
                Directory.Move(pathFolderOrFile, pathNewFolderOrFile);
            else if (File.Exists(pathFolderOrFile))
                File.Move(pathFolderOrFile, pathNewFolderOrFile);
            else
                MessageBox.Show("Невідома помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }





    }
}
