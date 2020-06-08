using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class UnitTestHelpers
    {
        [TestMethod]
        public void test_string_parser()
        {
            // arrange
            var inputArray = new string[] { "java", "'java", "script'", "'java'" };
            var expectedArray = new string[] { "java", "java script", "java" };

            // act
            var result = StringParser.NormalizeInputStrings(inputArray);

            // assert
            Assert.IsTrue(expectedArray.SequenceEqual(result));
        }
    }
}
