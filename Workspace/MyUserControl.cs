using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Workspace.Properties;
using System.IO;

namespace Workspace
{
    public partial class MyUserControl : UserControl
    {
        private TreeNode root;
        private TreeNode ContextNode;
        private TreeNode nodeSelected;

        public MyUserControl()
        {
            InitializeComponent();
            myTreeView.ImageList = new ImageList();
            myTreeView.ImageList.Images.Add("folder", Properties.Resources.Folder);
            myTreeView.ImageList.Images.Add("file", Properties.Resources.File);

            WorkspaceService.Instance().Init(myTreeView);

            myTreeView.Nodes.Clear();
            myTreeView.Nodes.Add(WorkspaceService.Instance().GetRoot());
        }

        private void newDocument_Click(object sender, EventArgs e)
        {
            Globals.ThisAddIn.New();
        }

        private void myTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                myTreeView.SelectedNode =e.Node;
                this.ContextNode = e.Node;
                if (e.Node.Text.EndsWith(".docx"))
                {
                    contextFileMenu.Show(this, new Point(e.Location.X, e.Location.Y));
                }
                else
                {
                    contextFolderMenu.Show(this, new Point(e.Location.X, e.Location.Y));
                }
            }
            else if(e.Button == MouseButtons.Left)
            {
                myTreeView.SelectedNode = e.Node;
                if (e.Node.Text.EndsWith(".docx"))
                {
                    if (this.nodeSelected != e.Node)
                    {
                        Globals.ThisAddIn.Open(WorkspaceService.Instance().GetFullPathOf(e.Node));
                    }
                }
                this.nodeSelected = e.Node;
            }
        }

        private void deleteFolderMenuItem_Click(object sender, EventArgs e)
        {
            WorkspaceService.Instance().Delete(this.ContextNode);
        }

        private void newFolderMenuItem_Click(object sender, EventArgs e)
        {
            WorkspaceService.Instance().NewFolderIn(this.ContextNode);
        }

        private void newFileMenuItem_Click(object sender, EventArgs e)
        {
            WorkspaceService.Instance().NewFileIn(this.ContextNode);
        }

        private void deleteFileMenuItem_Click(object sender, EventArgs e)
        {
            WorkspaceService.Instance().Delete(this.ContextNode);
        }
    }
}
