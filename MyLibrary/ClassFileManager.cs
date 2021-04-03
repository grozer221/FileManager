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
    public class ClassFileManager : StructureTable
    {
        public List<StructureTable> GetDisksInObj(ref List<string> listVisualisedItems)
        {
            listVisualisedItems.Clear();
            List<StructureTable> listDisks = new List<StructureTable>();
            listDisks.Add(new StructureTable { Image = GetPropertyImage("none"), Name = "Назва", FormatOrDateLastChanged = "Формат", TotalFreeSpaceOrType = "Вільного місця", TotalSize = "Повний об`єм" });
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                listDisks.Add(new StructureTable { Image = GetPropertyImage("disk"), Name = drive.Name, FormatOrDateLastChanged = drive.DriveFormat, TotalFreeSpaceOrType = GetSizeInPropertyType(drive.TotalFreeSpace), TotalSize = GetSizeInPropertyType(drive.TotalSize) });
                listVisualisedItems.Add(drive.Name);
            }
            return listDisks;
        }

        public List<StructureTable> GetFilesAndFoldersInObj(string path, ref List<string> listVisualisedItems)
        {
            listVisualisedItems.Clear();
            List<StructureTable> listFilesAndFolders = new List<StructureTable>();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo[] dirs = dirInfo.GetDirectories();
            FileInfo[] files = dirInfo.GetFiles();
            listFilesAndFolders.Add(new StructureTable { Image = GetPropertyImage("none"), Name = "Назва", FormatOrDateLastChanged = "Дата зміни", TotalFreeSpaceOrType = "Тип", TotalSize = "Розмір" });
            foreach (DirectoryInfo dir in dirs)
            {
                listFilesAndFolders.Add(new StructureTable { Image = GetPropertyImage("folder"), Name = dir.Name, FormatOrDateLastChanged = dir.LastWriteTime.ToString(), TotalFreeSpaceOrType = "Папка", TotalSize = "" });
                listVisualisedItems.Add(dir.FullName);
            }
            foreach (FileInfo file in files)
            {
                listFilesAndFolders.Add(new StructureTable { Image = GetPropertyImage("none"), Name = file.Name, FormatOrDateLastChanged = file.LastWriteTime.ToString(), TotalFreeSpaceOrType = "Файл", TotalSize = GetSizeInPropertyType(file.Length) });
                listVisualisedItems.Add(file.FullName);
            }
            return listFilesAndFolders;
        }

        public Bitmap GetPropertyImage(string e)
        {
            switch (e)
            {
                case "disk":
                    return new Bitmap(Properties.Resources.hard_drive_29228, 25, 25);

                case "folder":
                    return new Bitmap(Properties.Resources.documents_folder_18875, 20, 20);

                case "none":
                    var bmp = new Bitmap(25, 25);
                    using (var g = Graphics.FromImage(bmp))
                        g.Clear(Color.FromArgb(14, 22, 33));
                    return bmp;

                default:
                    return null;
            }
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




    }
}
