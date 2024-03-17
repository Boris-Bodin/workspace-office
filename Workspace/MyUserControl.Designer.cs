namespace Workspace
{
    partial class MyUserControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myTreeView = new System.Windows.Forms.TreeView();
            this.newDocument = new System.Windows.Forms.Button();
            this.contextFileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFolderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextFileMenu.SuspendLayout();
            this.contextFolderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTreeView
            // 
            this.myTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.myTreeView.Location = new System.Drawing.Point(4, 4);
            this.myTreeView.Name = "myTreeView";
            this.myTreeView.Size = new System.Drawing.Size(246, 290);
            this.myTreeView.TabIndex = 0;
            this.myTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.myTreeView_NodeMouseClick);
            // 
            // newDocument
            // 
            this.newDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newDocument.Location = new System.Drawing.Point(4, 300);
            this.newDocument.Name = "newDocument";
            this.newDocument.Size = new System.Drawing.Size(246, 23);
            this.newDocument.TabIndex = 1;
            this.newDocument.Text = "New Document";
            this.newDocument.UseVisualStyleBackColor = true;
            this.newDocument.Click += new System.EventHandler(this.newDocument_Click);
            // 
            // contextFileMenu
            // 
            this.contextFileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteFileMenuItem});
            this.contextFileMenu.Name = "contextMenu";
            this.contextFileMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // deleteFileMenuItem
            // 
            this.deleteFileMenuItem.Name = "deleteFileMenuItem";
            this.deleteFileMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteFileMenuItem.Text = "Delete";
            this.deleteFileMenuItem.Click += new System.EventHandler(this.deleteFileMenuItem_Click);
            // 
            // contextFolderMenu
            // 
            this.contextFolderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteFolderMenuItem,
            this.newFolderMenuItem,
            this.newFileMenuItem});
            this.contextFolderMenu.Name = "contextFolderMenu";
            this.contextFolderMenu.Size = new System.Drawing.Size(135, 70);
            // 
            // deleteFolderMenuItem
            // 
            this.deleteFolderMenuItem.Name = "deleteFolderMenuItem";
            this.deleteFolderMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteFolderMenuItem.Text = "Delete";
            this.deleteFolderMenuItem.Click += new System.EventHandler(this.deleteFolderMenuItem_Click);
            // 
            // newFolderMenuItem
            // 
            this.newFolderMenuItem.Name = "newFolderMenuItem";
            this.newFolderMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newFolderMenuItem.Text = "New Folder";
            this.newFolderMenuItem.Click += new System.EventHandler(this.newFolderMenuItem_Click);
            // 
            // newFileMenuItem
            // 
            this.newFileMenuItem.Name = "newFileMenuItem";
            this.newFileMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newFileMenuItem.Text = "New File";
            this.newFileMenuItem.Click += new System.EventHandler(this.newFileMenuItem_Click);
            // 
            // MyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newDocument);
            this.Controls.Add(this.myTreeView);
            this.Name = "MyUserControl";
            this.Size = new System.Drawing.Size(253, 326);
            this.contextFileMenu.ResumeLayout(false);
            this.contextFolderMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView myTreeView;
        private System.Windows.Forms.Button newDocument;
        private System.Windows.Forms.ContextMenuStrip contextFileMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteFileMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextFolderMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileMenuItem;
    }
}
