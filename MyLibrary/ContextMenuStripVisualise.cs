using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private byte NumberMenuNewFolder = 5;
        private byte NumberMenuRename = 6;


        public ContextMenuStripVisualise(ContextMenuStrip ContextMenu, DataGridView DataGrid) 
        {
            this.ContextMenu = ContextMenu;
            this.DataGrid = DataGrid;
            menuItem = this.ContextMenu.Items;
        }

        public void VisualiseContextMenuForFileManagerCellClick(DataGridViewCellMouseEventArgs e, string currentPath, string[] collectionPathsToCopiedFoldersAndFiles)
        {
            if (currentPath == null)
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = false;
            }
            else
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = true;
            }

            if (currentPath != null && collectionPathsToCopiedFoldersAndFiles == null)
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;


            if (currentPath != null)
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = true;
            }
        }

        public void VisualiseContextMenuForFileManagerNoneCellClick(string currentPath, string[] collectionPathsToCopiedFoldersAndFiles)
        {
            if (currentPath == null)
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = false;
            }
            else
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuNewFolder].Name].Enabled = true;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = true;
            }

            if (currentPath != null && collectionPathsToCopiedFoldersAndFiles == null)
                ContextMenu.Items[menuItem[NumberMenuPaste].Name].Enabled = false;

            if (currentPath != null)
            {
                ContextMenu.Items[menuItem[NumberMenuCopy].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuDelete].Name].Enabled = false;
                ContextMenu.Items[menuItem[NumberMenuRename].Name].Enabled = false;
            }

        }
        
        public void VisualiseContextMenuForQuickAccess(DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex == 0 || DataGrid.RowCount - 1 == e.RowIndex || DataGrid.RowCount - 2 == e.RowIndex)
                ContextMenu.Items[menuItem[0].Name].Enabled = false;
            else
                ContextMenu.Items[menuItem[0].Name].Enabled = true;
        }
    }
}
