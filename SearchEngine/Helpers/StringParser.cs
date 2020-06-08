using System;
using System.Collections.Generic;
using System.Text;

namespace SearchEngine.Helpers
{
    public static class StringParser
    {
        /// <summary>
        /// Combine strings with quotation marks
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string[] NormalizeInputStrings(string[] args)
        {
            var result = new List<string>();
            var index = 0;
            var join = false;
            foreach (var item in args)
            {   
                var tempLine = item;

                if (tempLine.StartsWith("'") || tempLine.StartsWith("\""))
                {
                    tempLine = tempLine.Substring(1);
                    join = true;
                    if (tempLine.EndsWith("'") || tempLine.EndsWith("\""))
                    {
                        join = false;
                        tempLine = tempLine.Substring(0, tempLine.Length - 1);
                    }
                }
                else if ((tempLine.EndsWith("'") || tempLine.EndsWith("\"")) && index > 0)
                {
                    tempLine = tempLine.Substring(0, tempLine.Length - 1);
                    result[result.Count - 1] += (" " + tempLine);
                    tempLine = "";
                    join = false;
                } 
                else if (join == true)
                {
                    result[result.Count - 1] += (" " + tempLine);
                    tempLine = "";
                }

                if (tempLine.Length > 0)
                {
                    result.Add(tempLine);
                }

                index++;
            }

            return result.ToArray();
        }
    }
}
