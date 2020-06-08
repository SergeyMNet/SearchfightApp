using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SearchEngine.SearchProviders
{
    public class Bing : BaseSearchEngine
    {
        private readonly string _searchUrl = "https://www.bing.com/";
        private readonly string _inputElemName = "q";
        private readonly string _resultElementId = "sb_count";

        protected override void OpenSearchPage()
        {
            var navigate = _chrome.Navigate();
            navigate.GoToUrl(_searchUrl);
            Thread.Sleep(1000);
        }

        protected override void InsertSearchParams(string searchText)
        {
            var inputEl = _chrome.FindElement(By.Name(_inputElemName));
            inputEl.SendKeys(searchText);
            Thread.Sleep(500);
            inputEl.Submit();
        }

        protected override ulong ParseResults()
        {
            var resultText = _chrome.FindElement(By.ClassName(_resultElementId))
                .Text.Replace(" ", "").Replace(",", "");
            var val = Regex.Match(resultText, @"\d+\.*\d*").Value;
            UInt32.TryParse(val, out uint r);
            return r;
        }
    }
}
