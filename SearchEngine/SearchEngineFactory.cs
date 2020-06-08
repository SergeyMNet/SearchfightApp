using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SearchEngine
{
    public class SearchEngineFactory : ISearchEngineFactory
    {
        private static Dictionary<string, ISearchEngine> Engines = new Dictionary<string, ISearchEngine>();

        public SearchEngineFactory()
        {
            GetEngines();
        }

        /// <summary>
        /// Get all registered search engines
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, ISearchEngine> GetSearchEngines()
        {
            return Engines;
        }

        private void GetEngines()
        {
            if (Engines == null || !Engines.Any())
            {
                var a = this.GetType().GetTypeInfo().Assembly;
                LoadTypesFromAssembly(a);
            }
        }

        private void LoadTypesFromAssembly(Assembly a)
        {
            var type = typeof(ISearchEngine);
            var types = a.GetTypes()
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

            foreach (var t in types)
            {
                Engines.Add(t.Name, (ISearchEngine)Activator.CreateInstance(t));
            }
        }
    }
}
