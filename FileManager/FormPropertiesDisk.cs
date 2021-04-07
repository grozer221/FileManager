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
using MyLibrary;

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
            textBoxUsingSpace.Text = ClassFileManager.GetSizeInPropertyType(usingSpace).ToString();
            textBoxTotalFreeSpace.Text = ClassFileManager.GetSizeInPropertyType(driveInfo.TotalFreeSpace).ToString();
            textBoxTotalSize.Text = ClassFileManager.GetSizeInPropertyType(driveInfo.TotalSize).ToString();
            panelUsingSpace.Width = Convert.ToInt32(panelTotalSpace.Width * usingSpace * Math.Pow(driveInfo.TotalSize, -1));
        }
    }
}
