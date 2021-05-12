using FileManager;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MyLibrary
{
    public class ContextMenuStripVisualise
    {
        private ContextMenuStrip ContextMenu;
        private DataGridView DataGrid;
        private ToolStripItemCollection menuItem;
        private byte NumberMenuCopy = 0;
        private byte NumberMenuPaste = 1;
        private byte NumberMenuAddQuickAccess = 2;
        private byte NumberMenuDelete = 4;
        private byte NumberMenuArchivate = 5;
        private byte NumberMenuUnArchivate = 6;
        private byte NumberMenuEncrypt = 7;
        private byte NumberMenuDecrypt = 8;
        private byte NumberMenuNewFolder = 9;
        private byte NumberMenuRename = 10;
        private byte NumberMenuProperties = 11;


        public ContextMenuStripVisualise(ContextMenuStrip ContextMenu, DataGridView DataGrid) 
        {
            this.ContextMenu = ContextMenu;
            this.DataGrid = DataGrid;
            menuItem = this.ContextMenu.Items;
        }

        public void VisualiseContextMenuForFileManagerCellClick(DataGridView dataGridView, string currentPath, List<string> listPathsToCopiedFoldersAndFiles)
        {
            ContextMenu.Items[menuItem[NumberMenuProperties].Name].Enabled = true;

            if (currentPath == null)
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuEncrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuDecrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = false;
            }
            else
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuArchivate].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuEncrypt].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuDecrypt].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = true;
            }

            if (currentPath != null && listPathsToCopiedFoldersAndFiles == null)
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;

            if(dataGridView.SelectedRows.Count > 1)
            {
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuProperties].Name].Enabled = false;
            }

            if (DataGrid.SelectedRows.Count == 1 && dataGridView.SelectedRows[0].Index == 0)
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuEncrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuDecrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuProperties].Name].Enabled = false;
            }

            try
            {
                string extension = new FileInfo(currentPath + "\\" + dataGridView[1, dataGridView.SelectedRows[0].Index].Value).Extension;
                if (extension != ".rar" && extension != ".zip")
                    ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = false;
            }
            catch { }

            try
            {
                if (!Directory.Exists(Path.Combine(currentPath, dataGridView[1, dataGridView.SelectedRows[0].Index].Value.ToString())))
                    ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
            }
            catch { }
        }

        public void VisualiseContextMenuForFileManagerNoneCellClick(DataGridView dataGridView, string currentPath, List<string> listPathsToCopiedFoldersAndFiles)
        {
            ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = false;
            ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
            ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = false;
            ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = false;
            ContextMenu.Items[menuItem[NumberMenuProperties].Name].Enabled = false;

            if (currentPath == null)
            {
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = false;
            }
            else
            {
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuArchivate].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = true;
            }

            if (currentPath != null && listPathsToCopiedFoldersAndFiles == null)
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;

            if (dataGridView.SelectedRows.Count == 0)
            {
                ContextMenu.Items[menuItem[NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuUnArchivate].Name].Enabled = false;
            }
        }

        public void VisualiseContextMenuForQuickAccess(DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == 0 || e.RowIndex >= DataGrid.RowCount - 3)
                ContextMenu.Items[menuItem[0].Name].Enabled = false;
            else
                ContextMenu.Items[menuItem[0].Name].Enabled = true;
        }
    }
}
