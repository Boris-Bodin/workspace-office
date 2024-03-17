namespace Workspace
{
    partial class MyRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MyRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.myTab = this.Factory.CreateRibbonTab();
            this.hierarchieGroup = this.Factory.CreateRibbonGroup();
            this.autoOpenPanel = this.Factory.CreateRibbonCheckBox();
            this.refresh = this.Factory.CreateRibbonButton();
            this.openPanel = this.Factory.CreateRibbonButton();
            this.selectRoot = this.Factory.CreateRibbonButton();
            this.myTab.SuspendLayout();
            this.hierarchieGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // myTab
            // 
            this.myTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.myTab.Groups.Add(this.hierarchieGroup);
            this.myTab.Label = "TabAddIns";
            this.myTab.Name = "myTab";
            // 
            // hierarchieGroup
            // 
            this.hierarchieGroup.Items.Add(this.openPanel);
            this.hierarchieGroup.Items.Add(this.autoOpenPanel);
            this.hierarchieGroup.Items.Add(this.selectRoot);
            this.hierarchieGroup.Items.Add(this.refresh);
            this.hierarchieGroup.Label = "Hierarchie";
            this.hierarchieGroup.Name = "hierarchieGroup";
            // 
            // autoOpenPanel
            // 
            this.autoOpenPanel.Label = "Auto Show Panel";
            this.autoOpenPanel.Name = "autoOpenPanel";
            this.autoOpenPanel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.autoOpenPanel_Click);
            // 
            // refresh
            // 
            this.refresh.Image = global::Workspace.Properties.Resources.Refresh;
            this.refresh.Label = "Refresh";
            this.refresh.Name = "refresh";
            this.refresh.ShowImage = true;
            this.refresh.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.refresh_Click);
            // 
            // openPanel
            // 
            this.openPanel.Image = global::Workspace.Properties.Resources.TreeFolder;
            this.openPanel.Label = " Show Panel";
            this.openPanel.Name = "openPanel";
            this.openPanel.ShowImage = true;
            this.openPanel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openPanel_Click);
            // 
            // selectRoot
            // 
            this.selectRoot.Image = global::Workspace.Properties.Resources.Folder;
            this.selectRoot.Label = "Select Root";
            this.selectRoot.Name = "selectRoot";
            this.selectRoot.ShowImage = true;
            this.selectRoot.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.selectRoot_Click);
            // 
            // MyRibbon
            // 
            this.Name = "MyRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.myTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MyRibbon_Load);
            this.myTab.ResumeLayout(false);
            this.myTab.PerformLayout();
            this.hierarchieGroup.ResumeLayout(false);
            this.hierarchieGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab myTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup hierarchieGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openPanel;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox autoOpenPanel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton selectRoot;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton refresh;
    }

    partial class ThisRibbonCollection
    {
        internal MyRibbon MyRibbon
        {
            get { return this.GetRibbon<MyRibbon>(); }
        }
    }
}
