using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace N1EEZB.GS1Barcodes.Test
{
    [TestClass]
    public class UnitTestDateParser
    {
        [TestMethod]
        [TestCategory("String -> Date Parser")]
        [Owner("Viktor")]
        public void TestGoodDate1900()
        {
            DateTime dt = DateParser.ParseString("971231");

            Assert.AreEqual(dt.Year, 1997);
            Assert.AreEqual(dt.Month, 12);
            Assert.AreEqual(dt.Day, 31);
        }

        [TestMethod]
        [TestCategory("String -> Date Parser")]
        [Owner("Viktor")]
        public void TestGoodDate2000()
        {
            DateTime dt = DateParser.ParseString("171231");

            Assert.AreEqual(dt.Year, 2017);
            Assert.AreEqual(dt.Month, 12);
            Assert.AreEqual(dt.Day, 31);
        }

        [TestMethod]
        [TestCategory("String -> Date Parser")]
        [Owner("Viktor")]
        [ExpectedException(typeof(System.FormatException))]
        public void TestDateFormatException()
        {
            DateTime dt = DateParser.ParseString("171232");
        }
    }
}
