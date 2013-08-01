using Microsoft.VisualStudio.TestTools.UITesting;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public class WebDialog : WebPage
    {
        public WebDialog()
        {
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = GetCurrentBrowser().DialogClassName;
            this.WindowTitles.Add(this.sWindowTitle);
        }

        //public new void ((BrowserWindow)Control.TopParent).ExecuteScript(string sCode)
        //{
        //    HtmlDocument document = new HtmlDocument(this);
        //    mshtml.IHTMLBodyElement idoc = (mshtml.IHTMLBodyElement)document.NativeElement;
        //    idoc.parentWindow.execScript(sCode);
        //}
    }
}
