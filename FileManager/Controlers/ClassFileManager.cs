using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyLibrary
{
    public class ClassFileManager
    {
        private List<string> ListQuickAccessFolders = new List<string>();
        private List<string> ListPathsToCopiedFoldersAndFiles;

        public List<ModelFileManager> GetDisksInListOfObj(ref List<string> listVisualisedItems)
        {
            listVisualisedItems.Clear();
            List<ModelFileManager> listDisks = new List<ModelFileManager>();
            listDisks.Add(new ModelFileManager { Image = GetEmptyImage(Color.FromArgb(14, 22, 33)), Name = "Назва", FormatOrDateLastChanged = "Формат", TotalFreeSpaceOrType = "Вільного місця", TotalSize = "Повний об`єм" });
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                string driveName;
                if (drive.DriveType == DriveType.Removable)
                    driveName = $"Зовнішній диск ({drive.Name.Substring(0, drive.Name.Length - 1)})";
                else
                    driveName = $"Локальний диск ({drive.Name.Substring(0, drive.Name.Length - 1)})";
                listDisks.Add(new ModelFileManager { Image = new Bitmap(FileManager.Properties.Resources.hard_drive_29228, 25, 25), Name = driveName, FormatOrDateLastChanged = drive.DriveFormat, TotalFreeSpaceOrType = GetSizeInPropertyType(drive.TotalFreeSpace), TotalSize = GetSizeInPropertyType(drive.TotalSize) });
                listVisualisedItems.Add(drive.Name);
            }
            return listDisks;
        }

        public List<string> GetCollectionPathsToCopiedFoldersAndFiles() { return ListPathsToCopiedFoldersAndFiles; }
        public List<ModelFileManager> GetFilesAndFoldersInListOfObj(string currentPath, ref List<string> listVisualisedItems, string args = null, bool showHiddenFilesAndFolders = false)
        {
            listVisualisedItems.Clear();
            List<ModelFileManager> listFilesAndFolders = new List<ModelFileManager>();
            DirectoryInfo dirInfo = new DirectoryInfo(currentPath);
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            FileInfo[] files = dirInfo.GetFiles();
            listFilesAndFolders.Add(new ModelFileManager { Image = GetEmptyImage(Color.FromArgb(14, 22, 33)), Name = "Назва", FormatOrDateLastChanged = "Дата зміни", TotalFreeSpaceOrType = "Тип", TotalSize = "Розмір" });
            foreach (DirectoryInfo dir in dirs)
            {
                if (dir.Attributes.HasFlag(FileAttributes.System))
                    continue;

                if (!showHiddenFilesAndFolders && dir.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;

                Bitmap bitmap;
                if (dir.Attributes.HasFlag(FileAttributes.Hidden))
                    bitmap = new Bitmap(FileManager.Properties.Resources.folderWithOpacity, 20, 20);
                else
                    bitmap = new Bitmap(FileManager.Properties.Resources.documents_folder_18875, 20, 20);
                listFilesAndFolders.Add(new ModelFileManager { Image = bitmap, Name = dir.Name, FormatOrDateLastChanged = dir.LastWriteTime.ToString(), TotalFreeSpaceOrType = "Папка", TotalSize = "" });
                listVisualisedItems.Add(dir.FullName);
            }
            foreach (FileInfo file in files)
            {
                if (file.Attributes.HasFlag(FileAttributes.System))
                    continue;

                if (!showHiddenFilesAndFolders && file.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                listFilesAndFolders.Add(new ModelFileManager { Image = new Bitmap(Icon.ExtractAssociatedIcon(file.FullName).ToBitmap(), 20, 20), Name = file.Name, FormatOrDateLastChanged = file.LastWriteTime.ToString(), TotalFreeSpaceOrType = "Файл", TotalSize = GetSizeInPropertyType(file.Length) });
                listVisualisedItems.Add(file.FullName);
            }

            if(args == "CreateNewFolder")
                listFilesAndFolders.Add(new ModelFileManager { Image = new Bitmap(FileManager.Properties.Resources.documents_folder_18875, 20, 20) });

            return listFilesAndFolders;
        }

        public Bitmap GetEmptyImage(Color color)
        {
            var bmp = new Bitmap(25, 25);
            using (var g = Graphics.FromImage(bmp))
                g.Clear(color);
            return bmp;
        }

        public static string GetSizeInPropertyType(long fileLength)
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

        public List<ModelQuickAccess> GetQuickAccessFoldersInObjs()
        {
            List<ModelQuickAccess> listQuickAccessFoldersInObj = new List<ModelQuickAccess>();
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = "Швидкий доступ" });
            foreach (string quickAccessFolder in ListQuickAccessFolders)
                listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = new Bitmap(FileManager.Properties.Resources.documents_folder_18875, 20, 20), Name = new DirectoryInfo(quickAccessFolder).Name });
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = null});
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = new Bitmap(FileManager.Properties.Resources.mypc, 20, 20), Name = "Мій комп'ютер" });
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = new Bitmap(FileManager.Properties.Resources.PluberGame, 20, 20), Name = "Пломбір" });
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
            ListPathsToCopiedFoldersAndFiles = new List<string>();
            for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
            {
                if (dataGridView.SelectedRows[i].Index == 0)
                    continue;
                ListPathsToCopiedFoldersAndFiles.Add(Path.Combine(currenPath, dataGridView[1, dataGridView.SelectedRows[i].Index].Value.ToString()));
            }
        }

        public void PasteCopiedFoldersAndFile(string currentPath)
        {
            for (int i = 0; i < ListPathsToCopiedFoldersAndFiles.Count; i++)
            {
                try
                {
                    if (new DirectoryInfo(ListPathsToCopiedFoldersAndFiles[i]).FullName == currentPath)
                    {
                        MessageBox.Show($"Скопійована папка {new DirectoryInfo(ListPathsToCopiedFoldersAndFiles[i]).Name} є субпапкою вибраної", "Перервана дія", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                    if (Directory.Exists(ListPathsToCopiedFoldersAndFiles[i]))
                        PasteFolderOrFile(ListPathsToCopiedFoldersAndFiles[i], $@"{currentPath}\{new DirectoryInfo(ListPathsToCopiedFoldersAndFiles[i]).Name}");
                    else
                        PasteFolderOrFile(ListPathsToCopiedFoldersAndFiles[i], $@"{currentPath}\{new FileInfo(ListPathsToCopiedFoldersAndFiles[i]).Name}");
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

        public static void SetAttributesHidden(string path, bool recursive)
        {
            File.SetAttributes(path, FileAttributes.Hidden);
            if (recursive)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                DirectoryInfo[] dirs;
                FileInfo[] files;
                try
                {
                    dirs = dirInfo.GetDirectories();
                    files = dirInfo.GetFiles();
                }
                catch { return; }
                foreach (DirectoryInfo dir in dirs)
                {
                    File.SetAttributes(dir.FullName, FileAttributes.Hidden);
                    SetAttributesHidden(dir.FullName, recursive);
                }
                foreach (FileInfo file in files)
                    File.SetAttributes(file.FullName, FileAttributes.Hidden);
            }
        }

        public static void DeleteAttributesHidden(string path, bool recursive)
        {
            File.SetAttributes(path, FileAttributes.Normal);
            if (recursive)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                DirectoryInfo[] dirs;
                FileInfo[] files;
                try
                {
                    dirs = dirInfo.GetDirectories();
                    files = dirInfo.GetFiles();
                }
                catch { return; }
                foreach (DirectoryInfo dir in dirs)
                {
                    File.SetAttributes(dir.FullName, FileAttributes.Normal);
                    DeleteAttributesHidden(dir.FullName, recursive);
                }
                foreach (FileInfo file in files)
                    File.SetAttributes(file.FullName, FileAttributes.Normal);
            }
        }
    }
}
