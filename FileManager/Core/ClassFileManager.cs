using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using IWshRuntimeLibrary;

namespace MyLibrary
{
    public class ClassFileManager
    {

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

                Bitmap bitmap;
                if (file.Attributes.HasFlag(FileAttributes.Hidden))
                    bitmap = ToDarkerColor(new Bitmap(Icon.ExtractAssociatedIcon(file.FullName).ToBitmap(), 20, 20));
                else
                    bitmap = new Bitmap(Icon.ExtractAssociatedIcon(file.FullName).ToBitmap(), 20, 20);
                listFilesAndFolders.Add(new ModelFileManager { Image = bitmap, Name = file.Name, FormatOrDateLastChanged = file.LastWriteTime.ToString(), TotalFreeSpaceOrType = "Файл", TotalSize = GetSizeInPropertyType(file.Length) });
                listVisualisedItems.Add(file.FullName);
            }

            if (args == "CreateNewFolder")
                listFilesAndFolders.Add(new ModelFileManager { Image = new Bitmap(FileManager.Properties.Resources.documents_folder_18875, 20, 20) });

            return listFilesAndFolders;
        }

        public Bitmap ToDarkerColor(Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb(pixel.A, pixel.R > 60 ? pixel.R - 60 : 0, pixel.G > 60 ? pixel.G - 60 : 0, pixel.B > 60 ? pixel.B - 60 : 0));
                }
            return bitmap;
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

        public List<ModelQuickAccess> GetQuickAccessFoldersInObjs()
        {
            List<ModelQuickAccess> listQuickAccessFoldersInObj = new List<ModelQuickAccess>();
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = "Швидкий доступ" });
            if (FileManager.Properties.Settings.Default.ListQuickAccessFolder != null)
                foreach (string quickAccessFolder in FileManager.Properties.Settings.Default.ListQuickAccessFolder)
                    listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = new Bitmap(FileManager.Properties.Resources.documents_folder_18875, 20, 20), Name = new DirectoryInfo(quickAccessFolder).Name });
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = null });
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = new Bitmap(FileManager.Properties.Resources.mypc, 20, 20), Name = "Мій комп'ютер" });
            listQuickAccessFoldersInObj.Add(new ModelQuickAccess { Image = new Bitmap(FileManager.Properties.Resources.PluberGame, 20, 20), Name = "Пломбір" });
            return listQuickAccessFoldersInObj;
        }

        public void AddQuickAccessFolderToList(string pathSelectedFolder)
        {
            if (FileManager.Properties.Settings.Default.ListQuickAccessFolder != null)
                foreach (string folder in FileManager.Properties.Settings.Default.ListQuickAccessFolder)
                {
                    if (folder == pathSelectedFolder)
                    {
                        MessageBox.Show($"Дана папка в швидкому доступі уже існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            else
                FileManager.Properties.Settings.Default.ListQuickAccessFolder = new List<string>();
            FileManager.Properties.Settings.Default.ListQuickAccessFolder.Add(pathSelectedFolder);
            FileManager.Properties.Settings.Default.Save();
        }

        public void RemoveQuickAccessFolder(int selectedRowIndex)
        {
            FileManager.Properties.Settings.Default.ListQuickAccessFolder.RemoveAt(selectedRowIndex);
            FileManager.Properties.Settings.Default.Save();
        }

        public void PasteCopiedFoldersAndFile(string currentPath, List<string> ListPathsToCopiedFoldersAndFiles)
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

            while (System.IO.File.Exists(destPath))
            {
                FileInfo fileinfo = new FileInfo(destPath);
                destPath = destPath.Replace(fileinfo.Extension, "");
                destPath += $" - Copy{fileinfo.Extension}";
            }

            if (System.IO.File.Exists(sourcePath))
                System.IO.File.Copy(sourcePath, destPath, true);
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
                System.IO.File.Copy(file, destFileName + fileName, true);
            }
        }

        public static void DeleteFiles(List<string> listFiles)
        {
            foreach(string file in listFiles)
            {
                try
                {
                    if (System.IO.File.Exists(file))
                        System.IO.File.Delete(file);
                    else if (Directory.Exists(file))
                        Directory.Delete(file, true);
                }
                catch
                {
                    MessageBox.Show($"Недостатньо прав для " + Path.GetFileName(file), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if (System.IO.File.Exists(pathFolderOrFile))
                System.IO.File.Move(pathFolderOrFile, pathNewFolderOrFile);
            else
                MessageBox.Show("Невідома помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void SetAttributesHidden(string path, bool recursive)
        {
            System.IO.File.SetAttributes(path, FileAttributes.Hidden);
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
                    System.IO.File.SetAttributes(dir.FullName, FileAttributes.Hidden);
                    SetAttributesHidden(dir.FullName, recursive);
                }
                foreach (FileInfo file in files)
                    System.IO.File.SetAttributes(file.FullName, FileAttributes.Hidden);
            }
        }

        public static void DeleteAttributesHidden(string path, bool recursive)
        {
            System.IO.File.SetAttributes(path, FileAttributes.Normal);
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
                    System.IO.File.SetAttributes(dir.FullName, FileAttributes.Normal);
                    DeleteAttributesHidden(dir.FullName, recursive);
                }
                foreach (FileInfo file in files)
                    System.IO.File.SetAttributes(file.FullName, FileAttributes.Normal);
            }
        }

        public static void CompressFiles(List<string> listSourceFiles, string archivePath)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.Always;
                zip.AlternateEncoding = Encoding.UTF8;
                foreach (string file in listSourceFiles)
                {
                    if (System.IO.File.Exists(file))
                        zip.AddFile(file, "");
                    else
                        zip.AddDirectory(file, new DirectoryInfo(file).Name);
                }
                zip.Save(archivePath);
            }
        }

        public static void DecompressFiles(string archivePath)
        {
            using (ZipFile zip = ZipFile.Read(archivePath))
            {
                foreach (ZipEntry e in zip)
                {
                    string filePath = Directory.GetParent(archivePath) + "\\" + e.FileName;
                    if (System.IO.File.Exists(filePath) || Directory.Exists(filePath))
                        if (MessageBox.Show($"Файл {e.FileName} в даній директорії вже існує. {Environment.NewLine}Замінити?", "Попередження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            continue;
                    e.Extract(Directory.GetParent(archivePath).FullName, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static void EncryptFile(string path, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
                    using (FileStream fsCrypt = new FileStream(path + ".crypt", FileMode.Create))
                        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV))
                            using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write))
                                using (FileStream fsIn = new FileStream(path, FileMode.Open))
                                {
                                    int data;
                                    while ((data = fsIn.ReadByte()) != -1)
                                        cs.WriteByte((byte)data);
                                }
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        public static void DecryptFile(string path, string skey)
        {
            try
            {
                using (RijndaelManaged aes = new RijndaelManaged())
                {
                    byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
                    byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);
                    using (FileStream fsCrypt = new FileStream(path, FileMode.Open))
                        using (FileStream fsOut = new FileStream(path.Replace(".crypt", ""), FileMode.Create))
                            using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV))
                                using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read))
                                {
                                    int data;
                                    while ((data = cs.ReadByte()) != -1)
                                        fsOut.WriteByte((byte)data);
                                }
                }
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }

        public static void CreateShortcut(string filePath, string shortcutPath)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = filePath;
            shortcut.Save();
        }
    }
}
