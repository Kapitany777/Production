using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace N1EEZB.GS1Barcodes.Test
{
    [TestClass]
    public class UnitTestBarcode
    {
        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        public void TestBarcodeGTIN()
        {
            GS1Barcode barcode = new GS1Barcode("0105991234500013");

            Assert.AreEqual(barcode.GlobalTradeItemNumber, "05991234500013");
        }

        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        public void TestBarcodeGTINAndBestBeforeDate()
        {
            GS1Barcode barcode = new GS1Barcode("010599123450001315171231");

            Assert.AreEqual(barcode.GlobalTradeItemNumber, "05991234500013");
            Assert.AreEqual(barcode.BestBeforeDate, DateTime.ParseExact("20171231", "yyyyMMdd", null, DateTimeStyles.None));
        }

        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        public void TestBarcodeGTINAndExpirationDate()
        {
            GS1Barcode barcode = new GS1Barcode("010599123450001317171231");

            Assert.AreEqual(barcode.GlobalTradeItemNumber, "05991234500013");
            Assert.AreEqual(barcode.ExpirationDate, DateTime.ParseExact("20171231", "yyyyMMdd", null, DateTimeStyles.None));
        }

        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        public void TestBarcodeGTINAndExpirationDateAndLotNumber()
        {
            GS1Barcode barcode = new GS1Barcode("01059912345000131717123110123456789");

            Assert.AreEqual(barcode.GlobalTradeItemNumber, "05991234500013");
            Assert.AreEqual(barcode.ExpirationDate, DateTime.ParseExact("20171231", "yyyyMMdd", null, DateTimeStyles.None));
            Assert.AreEqual(barcode.BatchOrLotNumber, "123456789");
        }

        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        [ExpectedException(typeof(GS1ApplicationIdentifierNotFoundException))]
        public void TestBarcodeInvalidIdentifierException()
        {
            GS1Barcode barcode = new GS1Barcode("0105991234500013XX17123110123456789");
        }

        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        [ExpectedException(typeof(GS1FieldLengthException))]
        public void TestBarcodeFieldLengthExeception()
        {
            GS1Barcode barcode = new GS1Barcode("01059912345000131717123110");
        }

        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        [ExpectedException(typeof(GS1NumberFormatException))]
        public void TestBarcodeNumberFormatException()
        {
            GS1Barcode barcode = new GS1Barcode("01X5991234500013171712311012345");
        }

        [TestMethod]
        [TestCategory("GS1-128 Barcodes")]
        [Owner("Viktor")]
        [ExpectedException(typeof(GS1DateFormatException))]
        public void TestBarcodeDateFormatException()
        {
            GS1Barcode barcode = new GS1Barcode("0105991234500013171712881012345");
        }
    }
}
