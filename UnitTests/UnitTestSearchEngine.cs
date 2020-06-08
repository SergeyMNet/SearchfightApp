using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.SearchProviders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Moq;
using SearchEngine;
using System.Linq;
using UnitTests.Helpers;

namespace UnitTests
{
    [TestClass]
    public class UnitTestSearchEngine
    {
        [TestMethod]
        public void exist_engines()
        {
            // arrange
            var factory = new SearchEngineFactory();
            var expectedEngines = new string[] { "Bing", "Google" };
            
            // act
            var existEngines = factory.GetSearchEngines()
                .Keys.Select(k => k);

            // assert
            Assert.IsTrue(existEngines.SequenceEqual(expectedEngines));
        }

        [TestMethod]
        public void cached_top_result()
        {
            // arrange
            var engine = new TestSearchEngine();
            engine.SetTestCachedResults("Test1", 1);
            engine.SetTestCachedResults("Test2", 2);
            engine.SetTestCachedResults("Test3", 3);
            var expectedResult = "Test3";

            // act
            var result = engine.GetTopResult();

            // assert
            Assert.IsTrue(expectedResult == result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void exception_top_result()
        {
            // arrange
            var engine = new TestSearchEngine();

            // act
            var result = engine.GetTopResult();

            // assert - Expects exception
        }

        [TestMethod]
        public void cached_all_result()
        {
            // arrange
            var engine = new TestSearchEngine();
            engine.SetTestCachedResults("Test1", 1);
            engine.SetTestCachedResults("Test2", 2);
            engine.SetTestCachedResults("Test3", 3);
            var expectedResult = new Dictionary<string, ulong>();
            expectedResult.Add("Test1", 1);
            expectedResult.Add("Test2", 2);
            expectedResult.Add("Test3", 3);

            // act
            var result = engine.GetAllResult();

            // assert
            Assert.IsTrue(result.SequenceEqual(result));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void exception_all_result()
        {
            // arrange
            var engine = new TestSearchEngine();

            // act
            var result = engine.GetAllResult();

            // assert - Expects exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void exception_missing_params_for_search()
        {
            // arrange
            var engine = new TestSearchEngine();

            // act
            var result = engine.Search("");

            // assert - Expects exception
        }
    }
}
