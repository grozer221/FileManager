using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FormPropertiesFileOrFolder : Form
    {
        public string PathFileOrFolder;

        public FormPropertiesFileOrFolder(string PathFileOrFolder)
        {
            InitializeComponent();
            this.PathFileOrFolder = PathFileOrFolder;
        }

        public void PrintProperties()
        {
            if (Directory.Exists(PathFileOrFolder))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(PathFileOrFolder);
                pictureBoxFileOrFolder.Image = Properties.Resources.folder;
                textBoxName.Text = dirInfo.Name;
                textBoxType.Text = "Папка";
                textBoxPath.Text = dirInfo.FullName;
                textBoxSize.Text = "1";
                textBoxLastTimeChanged.Text = dirInfo.LastWriteTime.ToString();
                textBoxCreated.Text = dirInfo.CreationTime.ToString();
                checkBoxMakeHidden.Checked = dirInfo.Attributes.HasFlag(FileAttributes.Hidden);
            }
            else if (File.Exists(PathFileOrFolder))
            {
                FileInfo fileInfo = new FileInfo(PathFileOrFolder);
                pictureBoxFileOrFolder.Image = Icon.ExtractAssociatedIcon(fileInfo.FullName).ToBitmap();
                textBoxName.Text = fileInfo.Name;
                textBoxType.Text = "Файл";
                textBoxPath.Text = fileInfo.FullName;
                textBoxSize.Text = GetSizeInPropertyType(fileInfo.Length);
                textBoxLastTimeChanged.Text = fileInfo.LastWriteTime.ToString();
                textBoxCreated.Text = fileInfo.CreationTime.ToString();
                checkBoxMakeHidden.Checked = fileInfo.Attributes.HasFlag(FileAttributes.Hidden);
            }
            else
                MessageBox.Show($"Файла або папки не існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
