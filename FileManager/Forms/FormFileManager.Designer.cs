
namespace FileManager
{
    partial class FormFileManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFileManager));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonHide = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelQuickAccess = new System.Windows.Forms.Panel();
            this.pictureBoxStopSearchFiles = new System.Windows.Forms.PictureBox();
            this.pictureBoxSearchFiles = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSearchFiles = new System.Windows.Forms.TextBox();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
            this.dataGridViewQuickAccessFolders = new System.Windows.Forms.DataGridView();
            this.contextMenuStripQuickAccess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFileManager = new System.Windows.Forms.Panel();
            this.labelEnterTextBoxError = new System.Windows.Forms.Label();
            this.panelUnderTextBoxPath = new System.Windows.Forms.Panel();
            this.pictureBoxOpenByPath = new System.Windows.Forms.PictureBox();
            this.pictureBoxStepBack = new System.Windows.Forms.PictureBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.dataGridViewFileManager = new System.Windows.Forms.DataGridView();
            this.contextMenuStripFileManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddToQuickAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ArchivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UnArchivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EncryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateShortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop.SuspendLayout();
            this.panelQuickAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStopSearchFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuickAccessFolders)).BeginInit();
            this.contextMenuStripQuickAccess.SuspendLayout();
            this.panelFileManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenByPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStepBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileManager)).BeginInit();
            this.contextMenuStripFileManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.panelTop.Controls.Add(this.buttonHide);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1019, 24);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // buttonHide
            // 
            this.buttonHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonHide.FlatAppearance.BorderSize = 0;
            this.buttonHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHide.ForeColor = System.Drawing.Color.White;
            this.buttonHide.Location = new System.Drawing.Point(959, 0);
            this.buttonHide.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(30, 24);
            this.buttonHide.TabIndex = 1;
            this.buttonHide.Text = "-";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "FileManager";
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(989, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 24);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            // 
            // panelQuickAccess
            // 
            this.panelQuickAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.panelQuickAccess.Controls.Add(this.pictureBoxStopSearchFiles);
            this.panelQuickAccess.Controls.Add(this.pictureBoxSearchFiles);
            this.panelQuickAccess.Controls.Add(this.panel1);
            this.panelQuickAccess.Controls.Add(this.textBoxSearchFiles);
            this.panelQuickAccess.Controls.Add(this.pictureBoxSettings);
            this.panelQuickAccess.Controls.Add(this.dataGridViewQuickAccessFolders);
            this.panelQuickAccess.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelQuickAccess.Location = new System.Drawing.Point(0, 24);
            this.panelQuickAccess.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelQuickAccess.Name = "panelQuickAccess";
            this.panelQuickAccess.Size = new System.Drawing.Size(223, 644);
            this.panelQuickAccess.TabIndex = 1;
            // 
            // pictureBoxStopSearchFiles
            // 
            this.pictureBoxStopSearchFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxStopSearchFiles.Image = global::FileManager.Properties.Resources.cross;
            this.pictureBoxStopSearchFiles.Location = new System.Drawing.Point(23, 60);
            this.pictureBoxStopSearchFiles.Name = "pictureBoxStopSearchFiles";
            this.pictureBoxStopSearchFiles.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxStopSearchFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStopSearchFiles.TabIndex = 4;
            this.pictureBoxStopSearchFiles.TabStop = false;
            this.pictureBoxStopSearchFiles.Click += new System.EventHandler(this.pictureBoxStopSearchFiles_Click);
            // 
            // pictureBoxSearchFiles
            // 
            this.pictureBoxSearchFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSearchFiles.Image = global::FileManager.Properties.Resources.searchzoomflat_106031;
            this.pictureBoxSearchFiles.Location = new System.Drawing.Point(175, 59);
            this.pictureBoxSearchFiles.Name = "pictureBoxSearchFiles";
            this.pictureBoxSearchFiles.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxSearchFiles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSearchFiles.TabIndex = 4;
            this.pictureBoxSearchFiles.TabStop = false;
            this.pictureBoxSearchFiles.Click += new System.EventHandler(this.pictureBoxSearchFiles_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(23, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 1);
            this.panel1.TabIndex = 3;
            // 
            // textBoxSearchFiles
            // 
            this.textBoxSearchFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.textBoxSearchFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearchFiles.ForeColor = System.Drawing.Color.White;
            this.textBoxSearchFiles.Location = new System.Drawing.Point(50, 64);
            this.textBoxSearchFiles.Name = "textBoxSearchFiles";
            this.textBoxSearchFiles.Size = new System.Drawing.Size(123, 20);
            this.textBoxSearchFiles.TabIndex = 2;
            this.textBoxSearchFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearchFiles_KeyUp);
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSettings.Image = global::FileManager.Properties.Resources.settings;
            this.pictureBoxSettings.Location = new System.Drawing.Point(23, 607);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSettings.TabIndex = 1;
            this.pictureBoxSettings.TabStop = false;
            this.pictureBoxSettings.Click += new System.EventHandler(this.pictureBoxSettings_Click);
            // 
            // dataGridViewQuickAccessFolders
            // 
            this.dataGridViewQuickAccessFolders.AllowUserToAddRows = false;
            this.dataGridViewQuickAccessFolders.AllowUserToDeleteRows = false;
            this.dataGridViewQuickAccessFolders.AllowUserToResizeColumns = false;
            this.dataGridViewQuickAccessFolders.AllowUserToResizeRows = false;
            this.dataGridViewQuickAccessFolders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.dataGridViewQuickAccessFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewQuickAccessFolders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewQuickAccessFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuickAccessFolders.ColumnHeadersVisible = false;
            this.dataGridViewQuickAccessFolders.ContextMenuStrip = this.contextMenuStripQuickAccess;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewQuickAccessFolders.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewQuickAccessFolders.Location = new System.Drawing.Point(23, 131);
            this.dataGridViewQuickAccessFolders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewQuickAccessFolders.MultiSelect = false;
            this.dataGridViewQuickAccessFolders.Name = "dataGridViewQuickAccessFolders";
            this.dataGridViewQuickAccessFolders.ReadOnly = true;
            this.dataGridViewQuickAccessFolders.RowHeadersVisible = false;
            this.dataGridViewQuickAccessFolders.RowHeadersWidth = 51;
            this.dataGridViewQuickAccessFolders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewQuickAccessFolders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewQuickAccessFolders.Size = new System.Drawing.Size(197, 478);
            this.dataGridViewQuickAccessFolders.TabIndex = 0;
            this.dataGridViewQuickAccessFolders.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewQuickAccessFolders_CellMouseClick);
            this.dataGridViewQuickAccessFolders.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewQuickAccessFolders_CellMouseDown);
            this.dataGridViewQuickAccessFolders.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewQuickAccessFolders_MouseDown);
            // 
            // contextMenuStripQuickAccess
            // 
            this.contextMenuStripQuickAccess.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripQuickAccess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem1});
            this.contextMenuStripQuickAccess.Name = "contextMenuStripQuickAccess";
            this.contextMenuStripQuickAccess.Size = new System.Drawing.Size(127, 26);
            // 
            // DeleteToolStripMenuItem1
            // 
            this.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1";
            this.DeleteToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.DeleteToolStripMenuItem1.Text = "Видалити";
            this.DeleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1_Click);
            // 
            // panelFileManager
            // 
            this.panelFileManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.panelFileManager.Controls.Add(this.labelEnterTextBoxError);
            this.panelFileManager.Controls.Add(this.panelUnderTextBoxPath);
            this.panelFileManager.Controls.Add(this.pictureBoxOpenByPath);
            this.panelFileManager.Controls.Add(this.pictureBoxStepBack);
            this.panelFileManager.Controls.Add(this.textBoxPath);
            this.panelFileManager.Controls.Add(this.dataGridViewFileManager);
            this.panelFileManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileManager.Location = new System.Drawing.Point(223, 24);
            this.panelFileManager.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panelFileManager.Name = "panelFileManager";
            this.panelFileManager.Size = new System.Drawing.Size(796, 644);
            this.panelFileManager.TabIndex = 2;
            // 
            // labelEnterTextBoxError
            // 
            this.labelEnterTextBoxError.AutoSize = true;
            this.labelEnterTextBoxError.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterTextBoxError.ForeColor = System.Drawing.Color.Red;
            this.labelEnterTextBoxError.Location = new System.Drawing.Point(49, 88);
            this.labelEnterTextBoxError.Name = "labelEnterTextBoxError";
            this.labelEnterTextBoxError.Size = new System.Drawing.Size(143, 14);
            this.labelEnterTextBoxError.TabIndex = 5;
            this.labelEnterTextBoxError.Text = "Директорію не знайдено";
            this.labelEnterTextBoxError.Visible = false;
            // 
            // panelUnderTextBoxPath
            // 
            this.panelUnderTextBoxPath.BackColor = System.Drawing.Color.White;
            this.panelUnderTextBoxPath.Location = new System.Drawing.Point(38, 85);
            this.panelUnderTextBoxPath.Name = "panelUnderTextBoxPath";
            this.panelUnderTextBoxPath.Size = new System.Drawing.Size(675, 1);
            this.panelUnderTextBoxPath.TabIndex = 4;
            // 
            // pictureBoxOpenByPath
            // 
            this.pictureBoxOpenByPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOpenByPath.Image = global::FileManager.Properties.Resources.arrow;
            this.pictureBoxOpenByPath.Location = new System.Drawing.Point(683, 56);
            this.pictureBoxOpenByPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxOpenByPath.Name = "pictureBoxOpenByPath";
            this.pictureBoxOpenByPath.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxOpenByPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOpenByPath.TabIndex = 3;
            this.pictureBoxOpenByPath.TabStop = false;
            this.pictureBoxOpenByPath.Click += new System.EventHandler(this.pictureBoxOpenByPath_Click);
            // 
            // pictureBoxStepBack
            // 
            this.pictureBoxStepBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxStepBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStepBack.Image")));
            this.pictureBoxStepBack.Location = new System.Drawing.Point(38, 56);
            this.pictureBoxStepBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBoxStepBack.Name = "pictureBoxStepBack";
            this.pictureBoxStepBack.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxStepBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStepBack.TabIndex = 2;
            this.pictureBoxStepBack.TabStop = false;
            this.pictureBoxStepBack.Click += new System.EventHandler(this.pictureBoxStepBack_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPath.ForeColor = System.Drawing.Color.White;
            this.textBoxPath.Location = new System.Drawing.Point(74, 63);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(608, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            this.textBoxPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPath_KeyDown);
            this.textBoxPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxPath_KeyUp);
            // 
            // dataGridViewFileManager
            // 
            this.dataGridViewFileManager.AllowDrop = true;
            this.dataGridViewFileManager.AllowUserToAddRows = false;
            this.dataGridViewFileManager.AllowUserToResizeColumns = false;
            this.dataGridViewFileManager.AllowUserToResizeRows = false;
            this.dataGridViewFileManager.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.dataGridViewFileManager.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFileManager.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewFileManager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFileManager.ColumnHeadersVisible = false;
            this.dataGridViewFileManager.ContextMenuStrip = this.contextMenuStripFileManager;
            this.dataGridViewFileManager.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFileManager.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFileManager.Location = new System.Drawing.Point(38, 131);
            this.dataGridViewFileManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewFileManager.Name = "dataGridViewFileManager";
            this.dataGridViewFileManager.RowHeadersVisible = false;
            this.dataGridViewFileManager.RowHeadersWidth = 51;
            this.dataGridViewFileManager.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewFileManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFileManager.Size = new System.Drawing.Size(700, 478);
            this.dataGridViewFileManager.TabIndex = 0;
            this.dataGridViewFileManager.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFileManager_CellDoubleClick);
            this.dataGridViewFileManager.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFileManager_CellEndEdit);
            this.dataGridViewFileManager.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewFileManager_CellMouseDown);
            this.dataGridViewFileManager.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewFileManager_DragDrop);
            this.dataGridViewFileManager.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewFileManager_DragEnter);
            this.dataGridViewFileManager.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewFileManager_KeyDown);
            this.dataGridViewFileManager.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewFileManager_MouseDown);
            // 
            // contextMenuStripFileManager
            // 
            this.contextMenuStripFileManager.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripFileManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.AddToQuickAccessToolStripMenuItem,
            this.ReloadToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.ArchivateToolStripMenuItem,
            this.UnArchivateToolStripMenuItem,
            this.EncryptToolStripMenuItem,
            this.DecryptToolStripMenuItem,
            this.CreateShortcutToolStripMenuItem,
            this.NewFolderToolStripMenuItem,
            this.RenameToolStripMenuItem,
            this.PropertiesToolStripMenuItem});
            this.contextMenuStripFileManager.Name = "contextMenuStripFileManager";
            this.contextMenuStripFileManager.Size = new System.Drawing.Size(220, 342);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Image = global::FileManager.Properties.Resources.copy;
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.CopyToolStripMenuItem.Text = "Копіювати";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Image = global::FileManager.Properties.Resources.paste;
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.PasteToolStripMenuItem.Text = "Вставити";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // AddToQuickAccessToolStripMenuItem
            // 
            this.AddToQuickAccessToolStripMenuItem.Image = global::FileManager.Properties.Resources.folder;
            this.AddToQuickAccessToolStripMenuItem.Name = "AddToQuickAccessToolStripMenuItem";
            this.AddToQuickAccessToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.AddToQuickAccessToolStripMenuItem.Text = "Додати в швидкий доступ";
            this.AddToQuickAccessToolStripMenuItem.Click += new System.EventHandler(this.AddToQuickAccessToolStripMenuItem_Click);
            // 
            // ReloadToolStripMenuItem
            // 
            this.ReloadToolStripMenuItem.Image = global::FileManager.Properties.Resources.refresh;
            this.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem";
            this.ReloadToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.ReloadToolStripMenuItem.Text = "Оновити";
            this.ReloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Image = global::FileManager.Properties.Resources.delete;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.DeleteToolStripMenuItem.Text = "Видалити";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // ArchivateToolStripMenuItem
            // 
            this.ArchivateToolStripMenuItem.Image = global::FileManager.Properties.Resources.winrar;
            this.ArchivateToolStripMenuItem.Name = "ArchivateToolStripMenuItem";
            this.ArchivateToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.ArchivateToolStripMenuItem.Text = "Архівувати";
            this.ArchivateToolStripMenuItem.Click += new System.EventHandler(this.ArchivateToolStripMenuItem_Click);
            // 
            // UnArchivateToolStripMenuItem
            // 
            this.UnArchivateToolStripMenuItem.Image = global::FileManager.Properties.Resources.winrar;
            this.UnArchivateToolStripMenuItem.Name = "UnArchivateToolStripMenuItem";
            this.UnArchivateToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.UnArchivateToolStripMenuItem.Text = "Розархівувати";
            this.UnArchivateToolStripMenuItem.Click += new System.EventHandler(this.UnArchivateToolStripMenuItem_Click);
            // 
            // EncryptToolStripMenuItem
            // 
            this.EncryptToolStripMenuItem.Image = global::FileManager.Properties.Resources.crypt;
            this.EncryptToolStripMenuItem.Name = "EncryptToolStripMenuItem";
            this.EncryptToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.EncryptToolStripMenuItem.Text = "Шифрувати";
            this.EncryptToolStripMenuItem.Click += new System.EventHandler(this.EncryptToolStripMenuItem_Click);
            // 
            // DecryptToolStripMenuItem
            // 
            this.DecryptToolStripMenuItem.Image = global::FileManager.Properties.Resources.crypt;
            this.DecryptToolStripMenuItem.Name = "DecryptToolStripMenuItem";
            this.DecryptToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.DecryptToolStripMenuItem.Text = "Розшифрувати";
            this.DecryptToolStripMenuItem.Click += new System.EventHandler(this.DecryptToolStripMenuItem_Click);
            // 
            // CreateShortcutToolStripMenuItem
            // 
            this.CreateShortcutToolStripMenuItem.Image = global::FileManager.Properties.Resources.shortcut;
            this.CreateShortcutToolStripMenuItem.Name = "CreateShortcutToolStripMenuItem";
            this.CreateShortcutToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.CreateShortcutToolStripMenuItem.Text = "Створити ярлик";
            this.CreateShortcutToolStripMenuItem.Click += new System.EventHandler(this.CreateShortcutToolStripMenuItem_Click);
            // 
            // NewFolderToolStripMenuItem
            // 
            this.NewFolderToolStripMenuItem.Image = global::FileManager.Properties.Resources.folder;
            this.NewFolderToolStripMenuItem.Name = "NewFolderToolStripMenuItem";
            this.NewFolderToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.NewFolderToolStripMenuItem.Text = "Нова папка";
            this.NewFolderToolStripMenuItem.Click += new System.EventHandler(this.NewFolderToolStripMenuItem_Click);
            // 
            // RenameToolStripMenuItem
            // 
            this.RenameToolStripMenuItem.Image = global::FileManager.Properties.Resources.rename;
            this.RenameToolStripMenuItem.Name = "RenameToolStripMenuItem";
            this.RenameToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.RenameToolStripMenuItem.Text = "Перейменувати";
            this.RenameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // PropertiesToolStripMenuItem
            // 
            this.PropertiesToolStripMenuItem.Image = global::FileManager.Properties.Resources.properties;
            this.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem";
            this.PropertiesToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.PropertiesToolStripMenuItem.Text = "Властивості";
            this.PropertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItem_Click);
            // 
            // FormFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 668);
            this.Controls.Add(this.panelFileManager);
            this.Controls.Add(this.panelQuickAccess);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFileManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager by Grozer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelQuickAccess.ResumeLayout(false);
            this.panelQuickAccess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStopSearchFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuickAccessFolders)).EndInit();
            this.contextMenuStripQuickAccess.ResumeLayout(false);
            this.panelFileManager.ResumeLayout(false);
            this.panelFileManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpenByPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStepBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileManager)).EndInit();
            this.contextMenuStripFileManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelQuickAccess;
        private System.Windows.Forms.DataGridView dataGridViewQuickAccessFolders;
        private System.Windows.Forms.Panel panelFileManager;
        private System.Windows.Forms.PictureBox pictureBoxOpenByPath;
        private System.Windows.Forms.PictureBox pictureBoxStepBack;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.DataGridView dataGridViewFileManager;
        private System.Windows.Forms.ToolStripMenuItem CopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddToQuickAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripQuickAccess;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem1;
        private System.Windows.Forms.Panel panelUnderTextBoxPath;
        private System.Windows.Forms.Label labelEnterTextBoxError;
        private System.Windows.Forms.PictureBox pictureBoxSettings;
        private System.Windows.Forms.ToolStripMenuItem PropertiesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileManager;
        private System.Windows.Forms.ToolStripMenuItem ArchivateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UnArchivateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EncryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DecryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateShortcutToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxSearchFiles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxSearchFiles;
        private System.Windows.Forms.PictureBox pictureBoxStopSearchFiles;
    }
}

