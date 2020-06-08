using SearchEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Helpers
{
    public class TestSearchEngine : BaseSearchEngine
    {
        public void SetTestCachedResults(string key, ulong value)
        {
            this._cachedResults.Add(key, value);
        }


        protected override void InsertSearchParams(string searchText)
        {
            throw new NotImplementedException();
        }

        protected override void OpenSearchPage()
        {
            throw new NotImplementedException();
        }

        protected override ulong ParseResults()
        {
            throw new NotImplementedException();
        }
    }
}
