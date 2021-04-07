using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileManager
{
    public partial class FormPropertiesDisk : Form
    {
        private string Disk;
        public FormPropertiesDisk(string Disk)
        {
            InitializeComponent();
            this.Disk = Disk;
        }

        public void PrintProperties()
        {
            DriveInfo driveInfo = new DriveInfo(Disk);
            pictureBoxDisk.Image = Properties.Resources.hard_drive_29228;
            textBoxType.Text = driveInfo.DriveFormat.ToString();
            textBoxName.Text = $"Локальний диск ({driveInfo.Name.Substring(0, driveInfo.Name.Length - 1)})";
            long usingSpace = driveInfo.TotalSize - driveInfo.TotalFreeSpace;
            textBoxUsingSpace.Text = GetSizeInPropertyType(usingSpace).ToString();
            textBoxTotalFreeSpace.Text = GetSizeInPropertyType(driveInfo.TotalFreeSpace).ToString();
            textBoxTotalSize.Text = GetSizeInPropertyType(driveInfo.TotalSize).ToString();
            panelUsingSpace.Width = Convert.ToInt32(panelTotalSpace.Width * usingSpace * Math.Pow(driveInfo.TotalSize, -1));
        }
        private string GetSizeInPropertyType(long fileLength)
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
