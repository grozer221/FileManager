using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FileManager.Core;

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

        public void PaintInDarkTheme()
        {
            this.BackColor = Color.FromArgb(36, 47, 61);
            textBoxName.BackColor = Color.FromArgb(36, 47, 61);
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White;
            textBoxType.BackColor = Color.FromArgb(36, 47, 61);
            labelType.BackColor = Color.FromArgb(36, 47, 61);
            textBoxPath.BackColor = Color.FromArgb(36, 47, 61);
            labelPath.BackColor = Color.FromArgb(36, 47, 61);
            textBoxSize.BackColor = Color.FromArgb(36, 47, 61);
            labelSize.BackColor = Color.FromArgb(36, 47, 61);
            labelLastTimeChanged.BackColor = Color.FromArgb(36, 47, 61);
            textBoxLastTimeChanged.BackColor = Color.FromArgb(36, 47, 61);
            textBoxCreated.BackColor = Color.FromArgb(36, 47, 61);
            labelCreated.BackColor = Color.FromArgb(36, 47, 61);

            textBoxName.ForeColor = Color.White;
            textBoxType.ForeColor = Color.White;
            labelType.ForeColor = Color.White;
            textBoxPath.ForeColor = Color.White;
            labelPath.ForeColor = Color.White;
            textBoxSize.ForeColor = Color.White;
            labelSize.ForeColor = Color.White;
            labelLastTimeChanged.ForeColor = Color.White;
            textBoxLastTimeChanged.ForeColor = Color.White;
            textBoxCreated.ForeColor = Color.White;
            labelCreated.ForeColor = Color.White;
            checkBoxMakeHidden.ForeColor = Color.White;
            labelMakeHidden.ForeColor = Color.White;
        }

        public void PaintInLightTheme()
        {
            this.BackColor = Color.FromArgb(235, 235, 235);
            textBoxName.BackColor = Color.FromArgb(235, 235, 235);
            panel1.BackColor = Color.Black;
            panel2.BackColor = Color.Black;
            panel3.BackColor = Color.Black;
            textBoxType.BackColor = Color.FromArgb(235, 235, 235);
            labelType.BackColor = Color.FromArgb(235, 235, 235);
            textBoxPath.BackColor = Color.FromArgb(235, 235, 235);
            labelPath.BackColor = Color.FromArgb(235, 235, 235);
            textBoxSize.BackColor = Color.FromArgb(235, 235, 235);
            labelSize.BackColor = Color.FromArgb(235, 235, 235);
            labelLastTimeChanged.BackColor = Color.FromArgb(235, 235, 235);
            textBoxLastTimeChanged.BackColor = Color.FromArgb(235, 235, 235);
            textBoxCreated.BackColor = Color.FromArgb(235, 235, 235);
            labelCreated.BackColor = Color.FromArgb(235, 235, 235);

            textBoxName.ForeColor = Color.Black;
            textBoxType.ForeColor = Color.Black;
            labelType.ForeColor = Color.Black;
            textBoxPath.ForeColor = Color.Black;
            labelPath.ForeColor = Color.Black;
            textBoxSize.ForeColor = Color.Black;
            labelSize.ForeColor = Color.Black;
            labelLastTimeChanged.ForeColor = Color.Black;
            textBoxLastTimeChanged.ForeColor = Color.Black;
            textBoxCreated.ForeColor = Color.Black;
            labelCreated.ForeColor = Color.Black;
            checkBoxMakeHidden.ForeColor = Color.Black;
            labelMakeHidden.ForeColor = Color.Black;
        }
    }
}
