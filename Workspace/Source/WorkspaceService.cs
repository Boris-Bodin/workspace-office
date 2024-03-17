using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Workspace.Properties;

namespace Workspace
{
    class WorkspaceService
    {
        private static WorkspaceService _instance;
        private TreeNode root;
        private TreeView myTreeView;

        static public WorkspaceService Instance()
        {
            if (WorkspaceService._instance == null)
                WorkspaceService._instance = new WorkspaceService();
            return WorkspaceService._instance;
        }

        public void Init(TreeView _myTreeView)
        {
            myTreeView = _myTreeView;
            Init();
        }

        public void Init()
        {
            if (!String.IsNullOrEmpty(Settings.Default.RootDir))
            {
                var rootDir = Settings.Default.RootDir;
                root = new TreeNode(rootDir.Substring(rootDir.LastIndexOf("\\") + 1));
                root.ImageKey = ("folder");
                myTreeView.Nodes.Clear();
                myTreeView.Nodes.Add(root);
                UpdateCollection();
                root.Expand();
            }
            else
            {
                root = new TreeNode("Root Empty");
            }
        }

        public void UpdateCollection()
        {
            this.Sync(root, GetFullPathOf(root));
          //  root.ExpandAll();
        }

        private void Sync(TreeNode root, string rootDir)
        {
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(rootDir));
            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir));

            var node = root.FirstNode;
            while(node != null)
            {
                var tmp = node;
                node = node.NextNode;
                if (!dirs.Contains(GetFullPathOf(tmp)) && !files.Contains(GetFullPathOf(tmp)))
                {
                    tmp.Remove();
                }
            }

            foreach (var dir in dirs)
            {
                var dirName = dir.Substring(dir.LastIndexOf("\\") + 1);
                node = Find(root, dirName);
                if(node != null)
                {
                    Sync(node, GetFullPathOf(node));
                }
                else
                {
                    var child = new TreeNode(dirName);
                    child.ImageKey = ("folder");
                    root.Nodes.Add(child);
                    Sync(child, GetFullPathOf(child));
                    child.Expand();
                }
            }
            
            foreach (var file in files)
            {
                var fileName = file.Substring(file.LastIndexOf("\\") + 1);
                if (!fileName.StartsWith("~$") && fileName.EndsWith(".docx"))
                {
                    node = Find(root, fileName);
                    if (node == null)
                    {
                        var child = new TreeNode(fileName);
                        child.ImageKey = ("file");
                        child.SelectedImageKey = ("file");
                        root.Nodes.Add(child);
                    }
                }
            }
        }

        private TreeNode Find(TreeNode root, string dirName)
        {
            var node = root.FirstNode;
            while (node != null)
            {
                if (node.Text == dirName) return node;
                node = node.NextNode;
            }
            return null;
        }

        public void Delete(TreeNode contextNode)
        {
            if(contextNode != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    try
                    {
                        if (contextNode.FirstNode == null)
                        {
                            File.Delete(GetFullPathOf(contextNode));
                        }
                        else
                        {
                            Directory.Delete(GetFullPathOf(contextNode), true);
                        }
                    } catch (Exception e)
                    {
                        return;
                    }
                    contextNode.Remove();
                }
            }
        }

        public void NewFileIn(TreeNode contextNode)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Choose a Name ?", "New File", "File Name.docx");
            if (name == "") return;
            if(!name.EndsWith(".docx"))
            {
                name += ".docx";
            }
            Globals.ThisAddIn.New(GetFullPathOf(contextNode) + "\\" + name);
        }

        public void NewFolderIn(TreeNode contextNode)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Choose a Name ?", "New Folder", "Folder Name");
            if (name == "") return;
            Directory.CreateDirectory(GetFullPathOf(contextNode) + '\\' + name);
            var tmp = new TreeNode(name);
            tmp.ImageKey = "folder";
            contextNode.Nodes.Add(tmp);
        }

        public TreeNode GetRoot()
        {
            return this.root;
        }

        public string GetFullPathOf(TreeNode node)
        {
            var rootDir = Settings.Default.RootDir;
            return rootDir.Substring(0, rootDir.LastIndexOf("\\") + 1) + node.FullPath;
        }

        private TreeNode[] Parcours(string rootDir)
        {
            List<TreeNode> children = new List<TreeNode>();

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(rootDir));

            foreach (var dir in dirs)
            {
                var dirName = dir.Substring(dir.LastIndexOf("\\") + 1);
                var tmpChildren = Parcours(dir);
                if (tmpChildren.Any())
                {
                    var child = new TreeNode(dirName, tmpChildren);
                    child.ImageKey = ("folder");
                    children.Add(child);
                }
            }

            List<string> files = new List<string>(Directory.EnumerateFiles(rootDir));

            foreach (var file in files)
            {
                var fileName = file.Substring(file.LastIndexOf("\\") + 1);
                if (fileName.EndsWith(".docx") && !fileName.StartsWith("~$"))
                {
                    var child = new TreeNode(fileName);
                    child.ImageKey = ("file");
                    child.SelectedImageKey = ("file");
                    children.Add(child);
                }
            }

            return children.ToArray();
        }
    }
}
