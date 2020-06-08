using SearchEngine;
using SearchEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchfightApp
{
    public class ClientApp
    {
        ISearchEngineFactory _engineFactory;

        public ClientApp(ISearchEngineFactory engineFactory)
        {
            _engineFactory = engineFactory;
        }

        public void Run(string[] args)
        {
            args = StringParser.NormalizeInputStrings(args);

            this.Calculate(args);
            this.PrintResults(args);
        }

        public void Calculate(string[] args)
        {
            foreach (var engine in _engineFactory.GetSearchEngines())
            {
                foreach (var item in args)
                {
                    engine.Value.Search(item);
                }
            }
        }

        public void PrintResults(string[] args)
        {
            Console.WriteLine("=============================================");

            // total results
            PrintTotalResults(args);

            // winner by Engine
            PrintWinnerByEngine();

            // total winner
            PrintTotalWinner(args);
        }

        private void PrintTotalWinner(string[] args)
        {
            var all = new Dictionary<string, ulong>();
            foreach (var item in args)
            {
                all.Add(item, 0);
            }
            foreach (var engine in _engineFactory.GetSearchEngines())
            {
                foreach (var val in engine.Value.GetAllResult())
                {
                    all[val.Key] += val.Value;
                }
            }
            var winner = all.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            Console.WriteLine($"Total winner: {winner}");
        }

        private void PrintWinnerByEngine()
        {
            foreach (var engine in _engineFactory.GetSearchEngines())
            {
                Console.WriteLine($"{engine.Key} winner: {engine.Value.GetTopResult()}");
            }
        }

        private void PrintTotalResults(string[] args)
        {
            foreach (var item in args)
            {
                Console.Write($"{item}: ");
                foreach (var engine in _engineFactory.GetSearchEngines())
                {
                    Console.Write($"{engine.Key}: {engine.Value.Search(item)} ");
                }
                Console.WriteLine();
            }
        }
    }
}
