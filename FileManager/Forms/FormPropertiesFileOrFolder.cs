using MyLibrary;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FormPropertiesFileOrFolder : Form
    {
        public string PathFileOrFolder;
        public bool IsHideRecursive = false;

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
                textBoxSize.Text = "0 Б";
                Thread thread = new Thread(() =>
                {
                    GetDirectorySizeAndPrintInTxtBox(dirInfo.FullName);
                    textBoxSize.Text = ClassFileManager.GetSizeInPropertyType(DirectorySize);
                });
                thread.IsBackground = true;
                thread.Start();
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
                textBoxSize.Text = ClassFileManager.GetSizeInPropertyType(fileInfo.Length);
                textBoxLastTimeChanged.Text = fileInfo.LastWriteTime.ToString();
                textBoxCreated.Text = fileInfo.CreationTime.ToString();
                checkBoxMakeHidden.Checked = fileInfo.Attributes.HasFlag(FileAttributes.Hidden);
            }
            else
                MessageBox.Show($"Файла або папки не існує", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private long DirectorySize = 0;
        public void GetDirectorySizeAndPrintInTxtBox(string path)
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
                GetDirectorySizeAndPrintInTxtBox(dir.FullName);
            foreach (FileInfo file in files)
                DirectorySize += file.Length;

            textBoxSize.Invoke(new Action(() => {
                textBoxSize.Text = ClassFileManager.GetSizeInPropertyType(DirectorySize);
            }));
        }

        private void checkBoxMakeHidden_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBoxMakeHidden.Checked && Directory.Exists(PathFileOrFolder))
                if (MessageBox.Show("Приховувати вкладені папки та файли?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    IsHideRecursive = true;
        }
    }
}
