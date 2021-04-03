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

        public List<StructureTableFileManager> GetFilesAndFoldersInObj(string currentPath, ref List<string> listVisualisedItems)
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

        public List<string> GetListQuickAccessFoldersFromFile()
        {
            List<string> listQuickAccessFolders = new List<string>();
            using (FileStream fs = new FileStream(Path.Combine(Environment.CurrentDirectory, "ListQuickAccessFolders.txt"), FileMode.OpenOrCreate))
                using (StreamReader stream = new StreamReader(fs))
                    while (!stream.EndOfStream)
                       listQuickAccessFolders.Add(stream.ReadLine());
            return listQuickAccessFolders;
        }

        public List<StructureQuickAccessFolders> GetQuickAccessFoldersInObjs(List<string> listQuickAccessFolders)
        {
            List<StructureQuickAccessFolders> listQuickAccessFoldersInObj = new List<StructureQuickAccessFolders>();
            listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = "Швидкий доступ" });
            foreach (string quickAccessFolder in listQuickAccessFolders)
                listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = new Bitmap(Properties.Resources.documents_folder_18875, 20, 20), Name = new DirectoryInfo(quickAccessFolder).Name });
            listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = GetEmptyImage(Color.FromArgb(23, 33, 43)), Name = null});
            listQuickAccessFoldersInObj.Add(new StructureQuickAccessFolders { Image = new Bitmap(Properties.Resources.mypc, 20, 20), Name = "Мій комп'ютер" });
            return listQuickAccessFoldersInObj;
        }




    }
}
