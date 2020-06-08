using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine
{
    public interface ISearchEngine
    {
        /// <summary>
        /// Search and check how many results returned
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        ulong Search(string searchText);

        /// <summary>
        /// Get top result for the current engine
        /// </summary>
        /// <returns></returns>
        string GetTopResult();

        /// <summary>
        /// Get all results
        /// </summary>
        /// <returns></returns>
        Dictionary<string, ulong> GetAllResult();
    }
}
