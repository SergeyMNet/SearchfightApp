using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SearchEngine
{
    public abstract class BaseSearchEngine : ISearchEngine
    {
        private ChromeOptions _options;
        protected IWebDriver _chrome;

        protected Dictionary<string, ulong> _cachedResults = new Dictionary<string, ulong>();

        public BaseSearchEngine()
        {
            _options = new ChromeOptions();
            _options.AddArguments("--disable-gpu");
#if !DEBUG
            _options.AddArguments("--headless"); // hide UI
#endif
        }

        public ulong Search(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
                throw new ArgumentException("Can't run a search engine without parameters.");

            var key = searchText;
            if (_cachedResults.ContainsKey(key))
            {
                return _cachedResults[key];
            }
            else
            {
                using (_chrome = new ChromeDriver(_options))
                {
                    OpenSearchPage();
                    Thread.Sleep(1000);
                    InsertSearchParams(searchText);
                    Thread.Sleep(1000);
                    var resCount = ParseResults();
                    _cachedResults.Add(key, resCount);

                    return resCount;
                }
            }
        }

        public string GetTopResult()
        {
            if(_cachedResults.Count > 0)
            {
                return _cachedResults.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            }
            else
            {
                throw new Exception("There is nothing to show, you should run 'Search' before getting Top result.");
            }
        }

        public Dictionary<string, ulong> GetAllResult()
        {
            if (_cachedResults.Count > 0)
            {
                return _cachedResults;
            }
            else
            {
                throw new Exception("There is nothing to show, you should run 'Search' before getting Top result.");
            }
        }


        protected abstract void OpenSearchPage();
        protected abstract void InsertSearchParams(string searchText);
        protected abstract ulong ParseResults();
    }
}
