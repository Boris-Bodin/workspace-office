using System.Linq;
using Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using Workspace.Properties;

namespace Workspace
{
    public partial class MyRibbon
    {
        private Microsoft.Office.Core.FileDialog folderDialog;

        private void MyRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            this.openPanel.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
            this.autoOpenPanel.Checked = Settings.Default.AutoExpand;

            this.folderDialog = Globals.ThisAddIn.Application.get_FileDialog(MsoFileDialogType.msoFileDialogFolderPicker);
            if (Settings.Default.RootDir != "")
            {
                this.folderDialog.InitialFileName = Settings.Default.RootDir.Substring(0, Settings.Default.RootDir.LastIndexOf('\\'));
            }
        }

        private void openPanel_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ToggleTaskPane();
        }

        private void autoOpenPanel_Click(object sender, RibbonControlEventArgs e)
        {
            Settings.Default.AutoExpand = this.autoOpenPanel.Checked;
            Settings.Default.Save();
        }

        private void selectRoot_Click(object sender, RibbonControlEventArgs e)
        {
            int result = this.folderDialog.Show();
            if (result == -1)
            {
                var selectedFolders = this.folderDialog.SelectedItems.Cast<string>().ToArray();
                if (selectedFolders.Length > 0)
                {
                    Settings.Default.RootDir = selectedFolders[0];
                    Settings.Default.Save();
                    this.folderDialog.InitialFileName = Settings.Default.RootDir.Substring(0, Settings.Default.RootDir.LastIndexOf('\\'));
                    WorkspaceService.Instance().Init();
                }
            }
        }

        private void refresh_Click(object sender, RibbonControlEventArgs e)
        {
            WorkspaceService.Instance().Init();
        }
    }
}
