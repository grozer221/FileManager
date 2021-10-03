using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileManager.Core
{
    public class ContextMenuStripVisualise
    {
        private ContextMenuStrip ContextMenu;
        private DataGridView DataGrid;
        private ToolStripItemCollection menuItem;
        enum menu//пункти меню
        {
            NumberMenuCopy = 0,
            NumberMenuPaste = 1,
            NumberMenuAddQuickAccess = 2,
            NumberMenuDelete = 4,
            NumberMenuArchivate = 5,
            NumberMenuUnArchivate = 6,
            NumberMenuEncrypt = 7,
            NumberMenuDecrypt = 8,
            NumberMenuCreateShortcut = 9,
            NumberMenuNewFolder = 10,
            NumberMenuRename = 11,
            NumberMenuProperties = 12
        }

        public ContextMenuStripVisualise(ContextMenuStrip ContextMenu, DataGridView DataGrid)//конструктор 
        {
            this.ContextMenu = ContextMenu;
            this.DataGrid = DataGrid;
            menuItem = this.ContextMenu.Items;
        }

        public void VisualiseContextMenuForFileManagerCellClick(DataGridView dataGridView, string currentPath, List<string> listPathsToCopiedFoldersAndFiles, bool isEnableSearchMode)//відображення пунктів контекстного меню після кліку по комірці
        {
            ContextMenu.Items[menuItem[(int)menu.NumberMenuProperties].Name].Enabled = true;

            if (currentPath == null)
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuCopy].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDelete].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuEncrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDecrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuCreateShortcut].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuRename].Name].Enabled = false;
            }
            else
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuCopy].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuAddQuickAccess].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDelete].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuEncrypt].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDecrypt].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuCreateShortcut].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuNewFolder].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuRename].Name].Enabled = true;
            }

            if (currentPath != null && listPathsToCopiedFoldersAndFiles == null)
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = false;

            if(dataGridView.SelectedRows.Count > 1)
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuRename].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuProperties].Name].Enabled = false;
            }

            if (DataGrid.SelectedRows.Count == 1 && dataGridView.SelectedRows[0].Index == 0)
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuCopy].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuAddQuickAccess].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDelete].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuEncrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDecrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuRename].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuProperties].Name].Enabled = false;
            }

            try
            {
                string extension = new FileInfo(currentPath + "\\" + dataGridView[1, dataGridView.SelectedRows[0].Index].Value).Extension;
                if (extension != ".rar" && extension != ".zip")
                    ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
            }
            catch { }

            try
            {
                if (!Directory.Exists(Path.Combine(currentPath, dataGridView[1, dataGridView.SelectedRows[0].Index].Value.ToString())))
                    ContextMenu.Items[menuItem[(int)menu.NumberMenuAddQuickAccess].Name].Enabled = false;
            }
            catch { }

            if (isEnableSearchMode)
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuEncrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDecrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuCreateShortcut].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuProperties].Name].Enabled = false;
            }
        }

        public void VisualiseContextMenuForFileManagerNoneCellClick(DataGridView dataGridView, string currentPath, List<string> listPathsToCopiedFoldersAndFiles, bool isEnableSearchMode)//відображення пунктів контекстного меню після кліку не по комірці
        {
            ContextMenu.Items[menuItem[(int)menu.NumberMenuCopy].Name].Enabled = false;
            ContextMenu.Items[menuItem[(int)menu.NumberMenuAddQuickAccess].Name].Enabled = false;
            ContextMenu.Items[menuItem[(int)menu.NumberMenuDelete].Name].Enabled = false;
            ContextMenu.Items[menuItem[(int)menu.NumberMenuCreateShortcut].Name].Enabled = false;
            ContextMenu.Items[menuItem[(int)menu.NumberMenuRename].Name].Enabled = false;
            ContextMenu.Items[menuItem[(int)menu.NumberMenuProperties].Name].Enabled = false;

            if (currentPath == null)
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
            }
            else
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuNewFolder].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = true;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = true;
            }

            if (currentPath != null && listPathsToCopiedFoldersAndFiles == null)
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = false;

            if (dataGridView.SelectedRows.Count == 0)
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
            }

            if (isEnableSearchMode)
            {
                ContextMenu.Items[menuItem[(int)menu.NumberMenuPaste].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuUnArchivate].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuEncrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuDecrypt].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuCreateShortcut].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuNewFolder].Name].Enabled = false;
                ContextMenu.Items[menuItem[(int)menu.NumberMenuProperties].Name].Enabled = false;
            }
        }

        public void VisualiseContextMenuForQuickAccess(int rowIndex)//відображення пунктів контекстного меню для папко швидкого доступу
        {
            if(rowIndex == 0 || rowIndex >= DataGrid.RowCount - 3)
                ContextMenu.Items[menuItem[0].Name].Enabled = false;
            else
                ContextMenu.Items[menuItem[0].Name].Enabled = true;
        }
    }
}
