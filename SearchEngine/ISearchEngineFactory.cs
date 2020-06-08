using System.Collections.Generic;

namespace SearchEngine
{
    public interface ISearchEngineFactory
    {
        /// <summary>
        /// Get all registered search engines
        /// </summary>
        /// <returns></returns>
        Dictionary<string, ISearchEngine> GetSearchEngines();
    }
}