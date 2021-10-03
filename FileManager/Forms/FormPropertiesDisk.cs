using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using FileManager.Core;

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

        public void PaintInDarkTheme()
        {
            this.BackColor = Color.FromArgb(36, 47, 61);
            textBoxName.BackColor = Color.FromArgb(36, 47, 61);
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            labelFormat.BackColor = Color.FromArgb(36, 47, 61);
            textBoxType.BackColor = Color.FromArgb(36, 47, 61);
            labelUsingSpace.BackColor = Color.FromArgb(36, 47, 61);
            textBoxUsingSpace.BackColor = Color.FromArgb(36, 47, 61);
            labelTotalFreeSpace.BackColor = Color.FromArgb(36, 47, 61);
            textBoxTotalFreeSpace.BackColor = Color.FromArgb(36, 47, 61);
            labelTotalSize.BackColor = Color.FromArgb(36, 47, 61);
            textBoxTotalSize.BackColor = Color.FromArgb(36, 47, 61);
            panelTotalSpace.BackColor = Color.FromArgb(36, 47, 61);
            panelSmallSquad.BackColor = Color.FromArgb(36, 47, 61);

            textBoxName.ForeColor = Color.White;
            labelFormat.ForeColor = Color.White;
            textBoxType.ForeColor = Color.White;
            labelUsingSpace.ForeColor = Color.White;
            textBoxUsingSpace.ForeColor = Color.White;
            labelTotalFreeSpace.ForeColor = Color.White;
            textBoxTotalFreeSpace.ForeColor = Color.White;
            labelTotalSize.ForeColor = Color.White;
            textBoxTotalSize.ForeColor = Color.White;
            panelTotalSpace.ForeColor = Color.White;
            panelSmallSquad.ForeColor = Color.White;
        }

        public void PaintInLightTheme()
        {
            this.BackColor = Color.FromArgb(235, 235, 235);
            textBoxName.BackColor = Color.FromArgb(235, 235, 235);
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            labelFormat.BackColor = Color.FromArgb(235, 235, 235);
            textBoxType.BackColor = Color.FromArgb(235, 235, 235);
            labelUsingSpace.BackColor = Color.FromArgb(235, 235, 235);
            textBoxUsingSpace.BackColor = Color.FromArgb(235, 235, 235);
            labelTotalFreeSpace.BackColor = Color.FromArgb(235, 235, 235);
            textBoxTotalFreeSpace.BackColor = Color.FromArgb(235, 235, 235);
            labelTotalSize.BackColor = Color.FromArgb(235, 235, 235);
            textBoxTotalSize.BackColor = Color.FromArgb(235, 235, 235);
            panelTotalSpace.BackColor = Color.FromArgb(235, 235, 235);
            panelSmallSquad.BackColor = Color.FromArgb(235, 235, 235);

            textBoxName.ForeColor = Color.Black;
            labelFormat.ForeColor = Color.Black;
            textBoxType.ForeColor = Color.Black;
            labelUsingSpace.ForeColor = Color.Black;
            textBoxUsingSpace.ForeColor = Color.Black;
            labelTotalFreeSpace.ForeColor = Color.Black;
            textBoxTotalFreeSpace.ForeColor = Color.Black;
            labelTotalSize.ForeColor = Color.Black;
            textBoxTotalSize.ForeColor = Color.Black;
            panelTotalSpace.ForeColor = Color.Black;
            panelSmallSquad.ForeColor = Color.Black;
        }
    }
}
