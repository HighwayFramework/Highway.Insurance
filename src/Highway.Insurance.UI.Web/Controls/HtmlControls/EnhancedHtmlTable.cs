using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Highway.Insurance.UI.Web.Controls.HtmlControls
{
    public enum EnhancedHtmlTableSearchOptions
    {
        Normal,
        NormalTight,
        Greedy,
        StartsWith,
        EndsWith
    }

    public class EnhancedHtmlTable : EnhancedHtmlControl<HtmlTable>
    {
        public EnhancedHtmlTable() : base() { }
        public EnhancedHtmlTable(string searchParameters) : base(searchParameters) { }
        public EnhancedHtmlTable(WebPage page, string selector) : base(page, selector) { }
        public int ColumnCount
        {
            get
            {
                this._control.WaitForControlReady();
                return this._control.ColumnCount;
            }
        }

        public int RowCount
        {
            get {
                this._control.WaitForControlReady();
                return this._control.Rows.Count; 
            }
        }

        public void FindRowAndClick(int iCol, string sValueToSearch)
        {
            int iRow = FindRow(iCol, sValueToSearch, EnhancedHtmlTableSearchOptions.Normal);
            FindCellAndClick(iRow, iCol);
        }

        public void FindRowAndClick(int iCol, string sValueToSearch, EnhancedHtmlTableSearchOptions option)
        {
            int iRow = FindRow(iCol, sValueToSearch, option);
            FindCellAndClick(iRow, iCol);
        }

        public void FindRowAndDoubleClick(int iCol, string sValueToSearch)
        {
            int iRow = FindRow(iCol, sValueToSearch, EnhancedHtmlTableSearchOptions.Normal);
            FindCellAndDoubleClick(iRow, iCol);
        }

        public void FindRowAndDoubleClick(int iCol, string sValueToSearch, EnhancedHtmlTableSearchOptions option)
        {
            int iRow = FindRow(iCol, sValueToSearch, option);
            FindCellAndDoubleClick(iRow, iCol);
        }

        public void FindHeaderAndClick(int iRow, int iCol)
        {
            this.GetHeader(iRow, iCol).Click();
        }

        public void FindCellAndClick(int iRow, int iCol)
        {
            this.GetCell<EnhancedHtmlControl<HtmlControl>>(iRow, iCol).Click();
        }

        public void FindCellAndDoubleClick(int iRow, int iCol)
        {
            this.GetCell(iRow, iCol).DoubleClick();
        }

        public int FindRow(int iCol, string sValueToSearch, EnhancedHtmlTableSearchOptions option)
        {
            this._control.WaitForControlReady();
            int iRow = -1;
            int rowCount = -1;

            foreach (HtmlControl control in this._control.Rows)
            {
                 //control could be of ControlType.RowHeader or ControlType.Row

                rowCount++;

                int colCount = -1;

                foreach (HtmlControl cell in control.GetChildren()) //Cells could be a collection of HtmlCell and HtmlHeaderCell controls
                {
                    colCount++;
                    bool bSearchOptionResult = false;
                    if (colCount == iCol)
                    {
                        if (option == EnhancedHtmlTableSearchOptions.Normal)
                        {
                            bSearchOptionResult = (sValueToSearch == cell.InnerText);
                        }
                        else if (option == EnhancedHtmlTableSearchOptions.NormalTight)
                        {
                            bSearchOptionResult = (sValueToSearch == cell.InnerText.Trim());
                        }
                        else if (option == EnhancedHtmlTableSearchOptions.StartsWith)
                        {
                            bSearchOptionResult = cell.InnerText.StartsWith(sValueToSearch);
                        }
                        else if (option == EnhancedHtmlTableSearchOptions.EndsWith)
                        {
                            bSearchOptionResult = cell.InnerText.EndsWith(sValueToSearch);
                        }
                        else if (option == EnhancedHtmlTableSearchOptions.Greedy)
                        {
                            bSearchOptionResult = (cell.InnerText.IndexOf(sValueToSearch) > -1);
                        }
                        if (bSearchOptionResult == true)
                        {
                            iRow = rowCount;
                            break;
                        }
                    }
                }
                if (iRow > -1) break;
            }
            return iRow;
        }

        public string GetCellValue(int iRow, int iCol)
        {
            return GetCellValue<EnhancedHtmlCell>(iRow, iCol);
        }

        public string GetHeaderCellValue(int iRow, int iCol)
        {
            return GetCellValue<EnhancedHtmlHeaderCell>(iRow, iCol);
        }

        private string GetCellValue<T>(int iRow, int iCol) where T : IEnhancedHtmlControl
        {
            string innerText = "";
            T htmlCell = this.GetCell<T>(iRow, iCol);
            if (htmlCell != null)
            {
                innerText = htmlCell.InnerText;
            }

            return innerText;
        }

        public EnhancedHtmlCheckBox GetEmbeddedCheckBox(int iRow, int iCol)
        {
            string sSearchProperties = "";
            mshtml.IHTMLElement td = (mshtml.IHTMLElement)GetCell(iRow, iCol).UnWrap().NativeElement;
            mshtml.IHTMLElement check = GetEmbeddedCheckBoxNativeElement(td);
            string sOuterHTML = check.outerHTML.Replace("<", "").Replace(">", "").Trim();
            string[] saTemp = sOuterHTML.Split(' ');
            HtmlCheckBox chk = new HtmlCheckBox(this._control.Container);
            foreach (string sTemp in saTemp)
            {
                if (sTemp.IndexOf('=') > 0)
                {
                    string[] saKeyValue = sTemp.Split('=');
                    string sValue = saKeyValue[1];
                    if (saKeyValue[0].ToLower() == "name")
                    {
                        sSearchProperties += ";Name=" + sValue;
                        chk.SearchProperties.Add(HtmlControl.PropertyNames.Name, sValue);
                    }
                    if (saKeyValue[0].ToLower() == "id")
                    {
                        sSearchProperties += ";Id=" + sValue;
                        chk.SearchProperties.Add(HtmlControl.PropertyNames.Id, sValue);
                    }
                    if (saKeyValue[0].ToLower() == "class")
                    {
                        sSearchProperties += ";Class=" + sValue;
                        chk.SearchProperties.Add(HtmlControl.PropertyNames.Class, sValue);
                    }
                }
            }

            if (sSearchProperties.Length > 1)
            {
                sSearchProperties = sSearchProperties.Substring(1);
            }
            EnhancedHtmlCheckBox retChk = new EnhancedHtmlCheckBox(sSearchProperties);
            retChk.Wrap(chk);
            return retChk;
        }

        /// <summary>
        /// Gets the column headers of the html table.
        /// </summary>
        /// <returns>string array</returns>
        public string[] GetColumnHeaders()
        {
            string[] retArray;
            UITestControlCollection rows = this._control.Rows;
            if ((rows != null) && (rows.Count > 0))
            {
                if ((rows[0] != null) && (rows[0].ControlType == ControlType.RowHeader))
                {
                    var headers = rows[0].GetChildren();
                    retArray = new string[headers.Count];
                    for (int i = 0; i < retArray.Length; i++)
                    {
                        retArray[i] = (string)headers[i].GetProperty("Value");
                    }
                    return retArray;
                }
            }
            return null;
        }

        public EnhancedHtmlHeaderCell GetHeader(int iRow, int iCol)
        {
            return GetCell<EnhancedHtmlHeaderCell>(iRow, iCol);
        }

        public EnhancedHtmlCell GetCell(int iRow, int iCol)
        {
            return GetCell<EnhancedHtmlCell>(iRow, iCol);
        }

        private T GetCell<T>(int iRow, int iCol) where T : IEnhancedHtmlControl
        {
            this._control.WaitForControlReady();
            HtmlControl htmlCell = null;
            int rowCount = -1;

            foreach (HtmlControl control in this._control.Rows)
            {
                //control could be of ControlType.RowHeader or ControlType.Row

                rowCount++;
                if (rowCount != iRow)
                {
                    continue;
                }

                int colCount = -1;

                foreach (HtmlControl cell in control.GetChildren()) //Cells could be a collection of HtmlCell and HtmlHeaderCell controls
                {
                    colCount++;
                    if (colCount != iCol)
                    {
                        continue;
                    }

                    htmlCell = cell;
                    break;
                }

                if (htmlCell != null)
                {
                    break;
                }
            }

            Type t = typeof(T);
            ConstructorInfo ctor = t.GetConstructor(new Type[] { typeof(HtmlControl) });
            return (T)ctor.Invoke(new object[] { htmlCell }); // call constructor
        }

        private mshtml.IHTMLElement GetEmbeddedCheckBoxNativeElement(mshtml.IHTMLElement parent)
        {
            while (true)
            {
                foreach (mshtml.IHTMLElement ele2 in parent.children)
                {
                    if (ele2.tagName.ToUpper() == "INPUT")
                    {
                        string sType = ele2.getAttribute("type");
                        if (sType.ToLower() == "checkbox")
                        {
                            return ele2;
                        }
                    }
                    else
                    {
                        if (ele2.children != null)
                        {
                            parent = ele2;
                        }
                    }
                }
            }
        }
    }
}
