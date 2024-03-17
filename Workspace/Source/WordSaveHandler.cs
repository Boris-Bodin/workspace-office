using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Tools;
using Workspace.Properties;
using System.Threading;

namespace Workspace
{
    public class WordSaveHandler
    {
        public delegate void AfterSaveDelegate(Word.Document doc, bool isClosed);

        // public events
        public event AfterSaveDelegate AfterUiSaveEvent;
        public event AfterSaveDelegate AfterAutoSaveEvent;
        public event AfterSaveDelegate AfterSaveEvent;

        // module level
        private bool preserveBackgroundSave;
        string closedFilename = string.Empty;
        private Word.Application Application;

        public WordSaveHandler(Word.Application _application)
        {
            this.Application = _application;
            this.Application.DocumentBeforeSave += new Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(AfterSaveHandler);
        }

        private void AfterSaveHandler(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            this.preserveBackgroundSave = this.Application.Options.BackgroundSave;
            this.Application.Options.BackgroundSave = true;
            bool UiSave = SaveAsUI;
            new Thread(() =>
            {
                Handle_WaitForAfterSave(Doc, UiSave);
            }).Start();
        }

        private void Handle_WaitForAfterSave(Word.Document Doc, bool UiSave)
        {
            try
            {
                if (UiSave)
                {
                    while (isBusy())
                        Thread.Sleep(1);
                }

                while (this.Application.BackgroundSavingStatus > 0)
                    Thread.Sleep(1);
            }
            catch (ThreadAbortException)
            {
                if (UiSave)
                {
                    AfterUiSaveEvent(null, true);
                }
                else
                {
                    AfterSaveEvent(null, true);
                }
            }
            catch
            {
                this.Application.Options.BackgroundSave = preserveBackgroundSave;
                return;
            }

            try
            {
                if (UiSave)
                {
                    try
                    {
                        if (Doc.Saved == true)
                        {
                            AfterUiSaveEvent(Doc, false);
                        }
                    }
                    catch
                    {
                        AfterUiSaveEvent(null, true);
                    }
                }
                else
                {
                    try
                    {
                        if (Doc.Saved == false)
                            AfterAutoSaveEvent(Doc, false);
                        else
                            AfterSaveEvent(Doc, false);
                    }
                    catch
                    {
                        AfterSaveEvent(null, true);
                    }
                }
            }
            catch { }
            finally
            {
                this.Application.Options.BackgroundSave = preserveBackgroundSave;
            }
        }

        private bool isBusy()
        {
            try
            {
                object o = this.Application.ActiveDocument.Application;
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
