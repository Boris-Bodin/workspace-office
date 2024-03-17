using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Tools;
using System.Threading;
using Workspace.Properties;

namespace Workspace
{
    public partial class ThisAddIn
    {
        private MyUserControl myUserControl;
        private CustomTaskPane myCustomTaskPane;
     //   private WordSaveHandler wordSaveHandler;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            myUserControl = new MyUserControl();
            myCustomTaskPane = this.CustomTaskPanes.Add(myUserControl, "Workspace");

            this.Application.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(Application_DocumentOpen);
            ((Word.ApplicationEvents4_Event)this.Application).NewDocument += new Word.ApplicationEvents4_NewDocumentEventHandler(Application_NewDocument);

            //    wordSaveHandler = new WordSaveHandler(Application);
            //    wordSaveHandler.AfterSaveEvent += new WordSaveHandler.AfterSaveDelegate(AfterSave);
        }

        private void AfterSave(Word.Document doc, bool isClosed)
        {
        //    WorkspaceService.Instance().UpdateCollection();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void Application_DocumentOpen(Word.Document Doc)
        {
            if (Settings.Default.AutoExpand)
            {
                this.myCustomTaskPane.Visible = true;
            }
        }

        private void Application_NewDocument(Word.Document Doc)
        {
            if (Settings.Default.AutoExpand)
            {
                this.myCustomTaskPane.Visible = true;
            }
        }

        public void Open(String filePath)
        {
            if(this.Application.ActiveDocument != null)
            {
                this.Application.Documents.Save();
                this.Application.Documents.Close();
            }
            this.Application.Documents.Open(filePath);

            WorkspaceService.Instance().UpdateCollection();
        }

        internal void New()
        {
            if (this.Application.ActiveDocument != null)
            {
                this.Application.Documents.Save();
                this.Application.Documents.Close();
            }
            this.Application.Documents.Add();

            WorkspaceService.Instance().UpdateCollection();
        }
        
        public void New(string path)
        {
            if (this.Application.ActiveDocument != null)
            {
                this.Application.Documents.Save();
                this.Application.Documents.Close();
            }
            this.Application.Documents.Add().SaveAs2(path);

            WorkspaceService.Instance().UpdateCollection();
        }

        public void ToggleTaskPane()
        {
            myCustomTaskPane.Visible = !myCustomTaskPane.Visible;
        }
        
        #region Code généré par VSTO

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
