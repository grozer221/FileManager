using MyLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FileManager
{
    public partial class FormFileManager : Form
    {
        public FormFileManager()
        {
            InitializeComponent();
        }

        private DataGridViewVisualise dataGridViewVisualise;
        private string currentPath = null;
        private ContextMenuStripVisualise contextMenuFileManager;
        private ContextMenuStripVisualise contextMenuQuickAccess;
        private Point movePoint;
        private List<string> ListPathsToCopiedFoldersAndFiles;

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            dataGridViewVisualise = new DataGridViewVisualise(dataGridViewFileManager, dataGridViewQuickAccessFolders);
            contextMenuFileManager = new ContextMenuStripVisualise(contextMenuStripFileManager, dataGridViewFileManager);
            contextMenuQuickAccess = new ContextMenuStripVisualise(contextMenuStripQuickAccess, dataGridViewQuickAccessFolders);

            PaintFormFileManagerFromChoseTheme();
            dataGridViewVisualise.EnabledNightMode = Properties.Settings.Default.EnabledNightMode;

            ReloadToolStripMenuItem_Click(null, null);
            textBoxPath_TextChanged(null, null);
            dataGridViewVisualise.PrintQuickAccessFolders();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            movePoint = new Point(e.X, e.Y);
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - movePoint.X;
                this.Top += e.Y - movePoint.Y;
            }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.Red;
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(0, 31, 41, 54);
        }

        private void dataGridViewFileManager_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFileManager[1, e.RowIndex].IsInEditMode)
                return;
            dataGridViewVisualise.CellDoubleClick(e.RowIndex, ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
            textBoxPath.Text = currentPath;
            labelEnterTextBoxError.Visible = false;
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            dataGridViewVisualise.IsEnableSearchMode = false;
            if (currentPath != null)
                pictureBoxStepBack.Enabled = true;
            if (currentPath == null)
                pictureBoxStepBack.Enabled = false;
        }

        private void pictureBoxStepBack_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.ClearDataGridView();
            pictureBoxStopSearchFiles_Click(null, null);
            if (dataGridViewVisualise.IsEnableSearchMode)
            {
                dataGridViewVisualise.IsEnableSearchMode = false;
                if (currentPath == null) { 
                    dataGridViewVisualise.PrintDisks();
                    pictureBoxStepBack.Enabled = false;
                }
                else
                    dataGridViewVisualise.PrintFilesAndFolder(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
                return;
            }
            dataGridViewVisualise.StepBack(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
            contextMenuFileManager.VisualiseContextMenuForFileManagerNoneCellClick(dataGridViewFileManager, currentPath, ListPathsToCopiedFoldersAndFiles, dataGridViewVisualise.IsEnableSearchMode);
            textBoxPath.Text = currentPath;
            labelEnterTextBoxError.Visible = false;
        }

        private void pictureBoxOpenByPath_Click(object sender, EventArgs e)
        {
            if (textBoxPath.Text == "")
            {
                dataGridViewVisualise.PrintDisks();
                currentPath = textBoxPath.Text;
                labelEnterTextBoxError.Visible = false;
                return;
            }

            string tmpCurrentPath = textBoxPath.Text;
            try
            {
                dataGridViewVisualise.SearchDirectory(ref tmpCurrentPath, Properties.Settings.Default.ShowHiddenFiles);
            }
            catch
            {
                labelEnterTextBoxError.Visible = true;
                return;
            }
            currentPath = tmpCurrentPath;
            textBoxPath.Text = currentPath;
            labelEnterTextBoxError.Visible = false;
        }

        private void dataGridViewFileManager_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridViewFileManager.EndEdit();

            if (e.Button == MouseButtons.Right)
                contextMenuFileManager.VisualiseContextMenuForFileManagerNoneCellClick(dataGridViewFileManager, currentPath, ListPathsToCopiedFoldersAndFiles, dataGridViewVisualise.IsEnableSearchMode);
        }

        private void dataGridViewFileManager_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!dataGridViewFileManager.Rows[e.RowIndex].Selected)
                    dataGridViewFileManager.ClearSelection();
                dataGridViewFileManager.Rows[e.RowIndex].Selected = true;

                contextMenuFileManager.VisualiseContextMenuForFileManagerCellClick(dataGridViewFileManager, currentPath, ListPathsToCopiedFoldersAndFiles, dataGridViewVisualise.IsEnableSearchMode);
            }
        }

        private void dataGridViewQuickAccessFolders_MouseDown(object sender, MouseEventArgs e)
        {
            dataGridViewQuickAccessFolders.ClearSelection();
        }

        private void dataGridViewQuickAccessFolders_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewVisualise.dataGridQuickAccessCellMouseClick(e, ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
            textBoxPath.Text = currentPath;
            labelEnterTextBoxError.Visible = false;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListPathsToCopiedFoldersAndFiles = dataGridViewVisualise.GetSelectedFilesInDataGrid(currentPath);
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.PasteCopiedFoldersAndFile(currentPath, ListPathsToCopiedFoldersAndFiles);
            ReloadToolStripMenuItem_Click(null, null);
        }

        private void AddToQuickAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.AddQuickAccessFolderToList(Path.Combine(currentPath, dataGridViewFileManager[1, dataGridViewFileManager.SelectedRows[0].Index].Value.ToString()));
            dataGridViewVisualise.PrintQuickAccessFolders();
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridViewVisualise.IsEnableSearchMode)
                pictureBoxStopSearchFiles_Click(null, null);

            dataGridViewVisualise.ClearDataGridView();

            if (currentPath == null)
                dataGridViewVisualise.PrintDisks();
            else
                dataGridViewVisualise.PrintFilesAndFolder(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.RemoveQuickAccessFolder(dataGridViewQuickAccessFolders.SelectedRows[0].Index - 1);
            dataGridViewVisualise.PrintQuickAccessFolders();
        }

        private void dataGridViewQuickAccessFolders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridViewQuickAccessFolders.Rows[e.RowIndex].Selected = true;
                contextMenuQuickAccess.VisualiseContextMenuForQuickAccess(e);
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Ви впевнені, що хочете видалити ?", "Попередження", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            List<string> listSelectedFiles = dataGridViewVisualise.GetSelectedFilesInDataGrid(currentPath);
            ClassFileManager.DeleteFiles(listSelectedFiles);
            ReloadToolStripMenuItem_Click(null, null);
        }

        private void NewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.AddNewRowForNewFolder(currentPath, Properties.Settings.Default.ShowHiddenFiles);
        }

        private void dataGridViewFileManager_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //create new folder
            if (dataGridViewFileManager[2, dataGridViewFileManager.SelectedRows[0].Index].Value == null)
            {
                if (dataGridViewFileManager[1, dataGridViewFileManager.Rows.Count - 1].Value == null)
                {
                    dataGridViewVisualise.PrintFilesAndFolder(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
                    return;
                }
                dataGridViewVisualise.CreateNewFolder(currentPath, dataGridViewFileManager[1, dataGridViewFileManager.Rows.Count - 1].Value.ToString());
            }
            //rename file of folder
            else
            {
                dataGridViewVisualise.RenameFileOrFolderInDataGrid(ref currentPath, e, Properties.Settings.Default.ShowHiddenFiles);
            }
            dataGridViewVisualise.PrintFilesAndFolder(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
        }

        private void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewFileManager.CurrentCell = dataGridViewFileManager.Rows[dataGridViewFileManager.SelectedRows[0].Index].Cells[1];
            dataGridViewFileManager.BeginEdit(true);
        }

        private void dataGridViewFileManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (dataGridViewFileManager.SelectedRows.Count == 1)
                {
                    dataGridViewVisualise.CellDoubleClick(dataGridViewFileManager.SelectedRows[0].Index, ref currentPath);
                    textBoxPath.Text = currentPath;
                }
            }

            if (e.KeyCode == Keys.Delete)
                DeleteToolStripMenuItem_Click(sender, e);

            if (e.Control && e.KeyCode == Keys.C)
                if (dataGridViewFileManager.SelectedRows.Count != 0 && currentPath != null)
                    CopyToolStripMenuItem_Click(sender, e);

            if (e.Control && e.KeyCode == Keys.V)
            {
                if (ListPathsToCopiedFoldersAndFiles == null)
                    return;
                if (currentPath != null)
                    PasteToolStripMenuItem_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.Left)
                if (currentPath != null)
                    pictureBoxStepBack_Click(sender, e);

            if (e.Control && e.KeyCode == Keys.R)
                ReloadToolStripMenuItem_Click(sender, null);
        }

        private void dataGridViewFileManager_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && textBoxPath.Text != "")
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void dataGridViewFileManager_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                foreach (string line in (string[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (Directory.Exists(line))
                        dataGridViewVisualise.PasteFolderOrFile(line, $@"{textBoxPath.Text}\{new DirectoryInfo(line).Name}");
                    else if (File.Exists(line))
                        dataGridViewVisualise.PasteFolderOrFile(line, $@"{textBoxPath.Text}\{new FileInfo(line).Name}");
                    else
                        MessageBox.Show("Невідома помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dataGridViewVisualise.PrintFilesAndFolder(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
            }
        }

        private void textBoxPath_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pictureBoxOpenByPath_Click(sender, e);
        }

        private void textBoxPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
                e.SuppressKeyPress = true;
        }

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.checkBoxShowHiddenFilesAndFolders.Checked = Properties.Settings.Default.ShowHiddenFiles;
            formSettings.checkBoxNightMode.Checked = Properties.Settings.Default.EnabledNightMode;
            if (formSettings.checkBoxNightMode.Checked)
                formSettings.PaintInDarkTheme();
            else
                formSettings.PaintInLightTheme();
            formSettings.ShowDialog();
            if (formSettings.IsPresedButtonCancel)
                return;
            Properties.Settings.Default.ShowHiddenFiles = formSettings.checkBoxShowHiddenFilesAndFolders.Checked;
            Properties.Settings.Default.EnabledNightMode = formSettings.checkBoxNightMode.Checked;
            Properties.Settings.Default.Save();
            PaintFormFileManagerFromChoseTheme();
            dataGridViewVisualise.EnabledNightMode = Properties.Settings.Default.EnabledNightMode;

            if (currentPath == null)
                dataGridViewVisualise.PrintDisks();
            else
                dataGridViewVisualise.PrintFilesAndFolder(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
            dataGridViewVisualise.PrintQuickAccessFolders();
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pathFileOfFolder = dataGridViewVisualise.ListVisualisedItems[dataGridViewFileManager.SelectedRows[0].Index - 1];
            FormProperties formProperties = new FormProperties(pathFileOfFolder);
            formProperties.EnabledNightMode = Properties.Settings.Default.EnabledNightMode;
            if (formProperties.EnabledNightMode)
                formProperties.PaintInDarkTheme();
            else
                formProperties.PaintInLightTheme();
            formProperties.ShowDialog();

            if (currentPath != null)
                dataGridViewVisualise.PrintFilesAndFolder(ref currentPath, Properties.Settings.Default.ShowHiddenFiles);
        }

        private void ArchivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> ListSelectedFile = dataGridViewVisualise.GetSelectedFilesInDataGrid(currentPath);
            FormCreateArchive formCreateArchive = new FormCreateArchive(ListSelectedFile.Count == 1 ? File.Exists(ListSelectedFile[0]) ? new FileInfo(ListSelectedFile[0]).Name : new DirectoryInfo(ListSelectedFile[0]).Name : null);
            formCreateArchive.ShowDialog();
            if (!formCreateArchive.OkOrCancel)
                return;
            string archiveName = Directory.GetParent(ListSelectedFile[0]).FullName + "\\" + formCreateArchive.textBoxArchiveName.Text + ".rar";
            Thread thread = new Thread(() =>
            {
                ClassFileManager.CompressFiles(ListSelectedFile, archiveName);
                ReloadToolStripMenuItem_Click(null, null);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void UnArchivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                ClassFileManager.DecompressFiles(dataGridViewVisualise.ListVisualisedItems[dataGridViewFileManager.SelectedRows[0].Index - 1]);
                dataGridViewFileManager.Invoke(new Action(() => ReloadToolStripMenuItem_Click(null, null)));
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void EncryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> listSelectedFiles = dataGridViewVisualise.GetSelectedFilesInDataGrid(currentPath);
            foreach(string file in listSelectedFiles)
            {
                if (Directory.Exists(file))
                {
                    MessageBox.Show("Диреторію шифрувати не можливо", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }
                if(new Regex(@"\.crypt").IsMatch(file))
                {
                    MessageBox.Show($"Файл {new FileInfo(file).Name} зашифрований");
                    continue;
                }
                if(File.Exists(file + ".crypt"))
                    if (MessageBox.Show($"Файл {new FileInfo(file + ".crypt").Name} в данній директорії уже існує" + Environment.NewLine + "Замінити?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        continue;
                ClassFileManager.EncryptFile(file, "HR$2pIjHR$2pIj12");
            }
            ReloadToolStripMenuItem_Click(null, null);
        }

        private void DecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> listSelectedFiles = dataGridViewVisualise.GetSelectedFilesInDataGrid(currentPath);
            foreach (string file in listSelectedFiles)
            {
                if (Directory.Exists(file))
                {
                    MessageBox.Show("Диреторію розшифрувати не можливо", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }
                if (!new Regex(@"\.crypt").IsMatch(file))
                {
                    MessageBox.Show($"Файл {new FileInfo(file).Name} не зашифрований");
                    continue;
                }
                if (File.Exists(file.Replace(".crypt", "")))
                    if (MessageBox.Show($"Файл {new FileInfo(file.Replace(".crypt", "")).Name} в данній директорії уже існує" + Environment.NewLine + "Замінити?", "Питання", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        continue;
                ClassFileManager.DecryptFile(file, "HR$2pIjHR$2pIj12");
            }
            ReloadToolStripMenuItem_Click(null, null);
        }

        private void CreateShortcutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> listSelectedFiles = dataGridViewVisualise.GetSelectedFilesInDataGrid(currentPath);
            foreach(string file in listSelectedFiles)
            {
                try {
                    if (File.Exists(file))
                        ClassFileManager.CreateShortcut(file, file.Replace(new FileInfo(file).Extension, "") + ".lnk"); 
                    else
                        ClassFileManager.CreateShortcut(file, file + ".lnk");
                }
                catch { MessageBox.Show("Невідома помилка при створенні ярлика", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            ReloadToolStripMenuItem_Click(null, null);
        }

        private void pictureBoxSearchFiles_Click(object sender, EventArgs e)
        {
            if (textBoxSearchFiles.Text == "" || textBoxSearchFiles.Text == null)
                return;

            dataGridViewVisualise.ClearDataGridView();
            dataGridViewVisualise.PrintSearchedFilesAsync(currentPath, textBoxSearchFiles.Text, Properties.Settings.Default.ShowHiddenFiles);
            pictureBoxStepBack.Enabled = true;
        }

        private void pictureBoxStopSearchFiles_Click(object sender, EventArgs e)
        {
            dataGridViewVisualise.StopPrintSearchedFiles();
            textBoxSearchFiles.Text = null;
        }

        private void textBoxSearchFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pictureBoxSearchFiles_Click(null, null);
        }

        private void textBoxSearchFiles_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchFiles.Text == "")
                pictureBoxSearchFiles.Enabled = false;
            else
                pictureBoxSearchFiles.Enabled = true;
        }

        private void PaintFormFileManagerFromChoseTheme()
        {
            if (Properties.Settings.Default.EnabledNightMode)//balck theme
            {
                panelTop.BackColor = Color.FromArgb(31, 41, 54);
                panelFileManager.BackColor = Color.FromArgb(14, 22, 33);
                textBoxPath.BackColor = Color.FromArgb(14, 22, 33);
                textBoxPath.ForeColor = Color.White;

                dataGridViewFileManager.BackgroundColor = Color.FromArgb(14, 22, 33);
                dataGridViewFileManager.DefaultCellStyle.BackColor = Color.FromArgb(14, 22, 33);
                dataGridViewFileManager.DefaultCellStyle.ForeColor = Color.White;
                dataGridViewFileManager.DefaultCellStyle.SelectionBackColor = Color.FromArgb(23, 33, 43);
                dataGridViewFileManager.DefaultCellStyle.SelectionForeColor = Color.White;

                panelQuickAccess.BackColor = Color.FromArgb(23, 33, 43);
                textBoxSearchFiles.BackColor = Color.FromArgb(23, 33, 43);
                textBoxSearchFiles.ForeColor = Color.White;

                dataGridViewQuickAccessFolders.BackgroundColor = Color.FromArgb(23, 33, 43);
                dataGridViewQuickAccessFolders.DefaultCellStyle.BackColor = Color.FromArgb(23, 33, 43);
                dataGridViewQuickAccessFolders.DefaultCellStyle.ForeColor = Color.White;
                dataGridViewQuickAccessFolders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(14, 22, 33);
                dataGridViewQuickAccessFolders.DefaultCellStyle.SelectionForeColor = Color.White;

                panelUndertextBoxSearchFiles.BackColor = Color.White;
                panelUnderTextBoxPath.BackColor = Color.White;

                buttonClose.ForeColor = Color.White;
                buttonHide.ForeColor = Color.White;
                labelTitle.ForeColor = Color.White;
            }
            else//white theme
            {
                panelTop.BackColor = Color.FromArgb(241, 241, 241);
                panelFileManager.BackColor = Color.FromArgb(230, 230, 230);
                textBoxPath.BackColor = Color.FromArgb(230, 230, 230);
                textBoxPath.ForeColor = Color.Black;

                dataGridViewFileManager.BackgroundColor = Color.FromArgb(230, 230, 230);
                dataGridViewFileManager.DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);
                dataGridViewFileManager.DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewFileManager.DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridViewFileManager.DefaultCellStyle.SelectionForeColor = Color.Black;

                panelQuickAccess.BackColor = Color.White;
                textBoxSearchFiles.BackColor = Color.White;
                textBoxSearchFiles.ForeColor = Color.Black;

                dataGridViewQuickAccessFolders.BackgroundColor = Color.White;
                dataGridViewQuickAccessFolders.DefaultCellStyle.BackColor = Color.White;
                dataGridViewQuickAccessFolders.DefaultCellStyle.ForeColor = Color.Black;
                dataGridViewQuickAccessFolders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 240, 240);
                dataGridViewQuickAccessFolders.DefaultCellStyle.SelectionForeColor = Color.Black;

                panelUndertextBoxSearchFiles.BackColor = Color.Black;
                panelUnderTextBoxPath.BackColor = Color.Black;

                buttonClose.ForeColor = Color.Black;
                buttonHide.ForeColor = Color.Black;
                labelTitle.ForeColor = Color.Black;
            }
        }
    }
}
