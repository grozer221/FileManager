
namespace FileManager
{
    partial class Form1
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelQuickAccess = new System.Windows.Forms.Panel();
            this.dataGridViewQuickAccessFolders = new System.Windows.Forms.DataGridView();
            this.panelFileManager = new System.Windows.Forms.Panel();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.pictureBoxStepBack = new System.Windows.Forms.PictureBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.dataGridViewFileManager = new System.Windows.Forms.DataGridView();
            this.contextMenuStripFileManager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.копіюватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиВШвидкийДоступToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оновитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаПапкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейменуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTop.SuspendLayout();
            this.panelQuickAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuickAccessFolders)).BeginInit();
            this.panelFileManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStepBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFileManager)).BeginInit();
            this.contextMenuStripFileManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.panelTop.Controls.Add(this.buttonHide);
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(943, 22);
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
            this.buttonHide.Location = new System.Drawing.Point(889, 0);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(27, 22);
            this.buttonHide.TabIndex = 1;
            this.buttonHide.Text = "-";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(916, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(27, 22);
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
            this.panelQuickAccess.Controls.Add(this.dataGridViewQuickAccessFolders);
            this.panelQuickAccess.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelQuickAccess.Location = new System.Drawing.Point(0, 22);
            this.panelQuickAccess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelQuickAccess.Name = "panelQuickAccess";
            this.panelQuickAccess.Size = new System.Drawing.Size(205, 659);
            this.panelQuickAccess.TabIndex = 1;
            // 
            // dataGridViewQuickAccessFolders
            // 
            this.dataGridViewQuickAccessFolders.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.dataGridViewQuickAccessFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuickAccessFolders.Location = new System.Drawing.Point(27, 98);
            this.dataGridViewQuickAccessFolders.Name = "dataGridViewQuickAccessFolders";
            this.dataGridViewQuickAccessFolders.Size = new System.Drawing.Size(206, 531);
            this.dataGridViewQuickAccessFolders.TabIndex = 0;
            // 
            // panelFileManager
            // 
            this.panelFileManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.panelFileManager.Controls.Add(this.pictureBoxSearch);
            this.panelFileManager.Controls.Add(this.pictureBoxStepBack);
            this.panelFileManager.Controls.Add(this.textBoxPath);
            this.panelFileManager.Controls.Add(this.dataGridViewFileManager);
            this.panelFileManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFileManager.Location = new System.Drawing.Point(205, 22);
            this.panelFileManager.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelFileManager.Name = "panelFileManager";
            this.panelFileManager.Size = new System.Drawing.Size(738, 659);
            this.panelFileManager.TabIndex = 2;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Image = global::FileManager.Properties.Resources.searchzoomflat_106031;
            this.pictureBoxSearch.Location = new System.Drawing.Point(698, 32);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(24, 22);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSearch.TabIndex = 3;
            this.pictureBoxSearch.TabStop = false;
            // 
            // pictureBoxStepBack
            // 
            this.pictureBoxStepBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxStepBack.Image = global::FileManager.Properties.Resources._1486564726_undo_back_81536;
            this.pictureBoxStepBack.Location = new System.Drawing.Point(1, 31);
            this.pictureBoxStepBack.Name = "pictureBoxStepBack";
            this.pictureBoxStepBack.Size = new System.Drawing.Size(29, 21);
            this.pictureBoxStepBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStepBack.TabIndex = 2;
            this.pictureBoxStepBack.TabStop = false;
            this.pictureBoxStepBack.Click += new System.EventHandler(this.pictureBoxStepBack_Click);
            // 
            // textBoxPath
            // 
            this.textBoxPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPath.ForeColor = System.Drawing.Color.White;
            this.textBoxPath.Location = new System.Drawing.Point(34, 31);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(650, 22);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFileManager.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFileManager.Location = new System.Drawing.Point(34, 98);
            this.dataGridViewFileManager.Name = "dataGridViewFileManager";
            this.dataGridViewFileManager.RowHeadersVisible = false;
            this.dataGridViewFileManager.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewFileManager.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFileManager.Size = new System.Drawing.Size(662, 531);
            this.dataGridViewFileManager.TabIndex = 0;
            this.dataGridViewFileManager.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFileManager_CellDoubleClick);
            // 
            // contextMenuStripFileManager
            // 
            this.contextMenuStripFileManager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.копіюватиToolStripMenuItem,
            this.вставитиToolStripMenuItem,
            this.додатиВШвидкийДоступToolStripMenuItem,
            this.оновитиToolStripMenuItem,
            this.видалитиToolStripMenuItem,
            this.новаПапкаToolStripMenuItem,
            this.перейменуватиToolStripMenuItem});
            this.contextMenuStripFileManager.Name = "contextMenuStripFileManager";
            this.contextMenuStripFileManager.Size = new System.Drawing.Size(216, 158);
            // 
            // копіюватиToolStripMenuItem
            // 
            this.копіюватиToolStripMenuItem.Name = "копіюватиToolStripMenuItem";
            this.копіюватиToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.копіюватиToolStripMenuItem.Text = "Копіювати";
            // 
            // вставитиToolStripMenuItem
            // 
            this.вставитиToolStripMenuItem.Name = "вставитиToolStripMenuItem";
            this.вставитиToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.вставитиToolStripMenuItem.Text = "Вставити";
            // 
            // додатиВШвидкийДоступToolStripMenuItem
            // 
            this.додатиВШвидкийДоступToolStripMenuItem.Name = "додатиВШвидкийДоступToolStripMenuItem";
            this.додатиВШвидкийДоступToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.додатиВШвидкийДоступToolStripMenuItem.Text = "Додати в швидкий доступ";
            // 
            // оновитиToolStripMenuItem
            // 
            this.оновитиToolStripMenuItem.Name = "оновитиToolStripMenuItem";
            this.оновитиToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.оновитиToolStripMenuItem.Text = "Оновити";
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.видалитиToolStripMenuItem.Text = "Видалити";
            // 
            // новаПапкаToolStripMenuItem
            // 
            this.новаПапкаToolStripMenuItem.Name = "новаПапкаToolStripMenuItem";
            this.новаПапкаToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.новаПапкаToolStripMenuItem.Text = "Нова папка";
            // 
            // перейменуватиToolStripMenuItem
            // 
            this.перейменуватиToolStripMenuItem.Name = "перейменуватиToolStripMenuItem";
            this.перейменуватиToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.перейменуватиToolStripMenuItem.Text = "Перейменувати";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 681);
            this.Controls.Add(this.panelFileManager);
            this.Controls.Add(this.panelQuickAccess);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager by Grozer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            this.panelQuickAccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuickAccessFolders)).EndInit();
            this.panelFileManager.ResumeLayout(false);
            this.panelFileManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.PictureBox pictureBoxStepBack;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.DataGridView dataGridViewFileManager;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFileManager;
        private System.Windows.Forms.ToolStripMenuItem копіюватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиВШвидкийДоступToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оновитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаПапкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейменуватиToolStripMenuItem;
    }
}

