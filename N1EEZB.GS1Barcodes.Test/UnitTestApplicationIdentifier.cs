using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace N1EEZB.GS1Barcodes.Test
{
    [TestClass]
    public class UnitTestApplicationIdentifier
    {
        [TestMethod]
        [TestCategory("Application Identifier")]
        [Owner("Viktor")]
        public void TestCreateGTIN()
        {
            GS1ApplicationIdentifier applicationIdentifier = new GS1ApplicationIdentifier(
                "01",
                "Global Trade Item Number",
                GS1ApplicationIdentifierFormat.NumericDigit,
                14,
                14);

            Assert.AreEqual(applicationIdentifier.AI, "01");
            Assert.AreEqual(applicationIdentifier.DataContent, "Global Trade Item Number");
            Assert.AreEqual(applicationIdentifier.Format, GS1ApplicationIdentifierFormat.NumericDigit);
            Assert.AreEqual(applicationIdentifier.MinLength, 14);
            Assert.AreEqual(applicationIdentifier.MaxLength, 14);
        }

        [TestMethod]
        [TestCategory("Application Identifier")]
        [Owner("Viktor")]
        public void TestCreateLotNumber()
        {
            GS1ApplicationIdentifier applicationIdentifier = new GS1ApplicationIdentifier(
                "10",
                "Batch or Lot Number",
                GS1ApplicationIdentifierFormat.AnyCharacter,
                1,
                20);

            Assert.AreEqual(applicationIdentifier.AI, "10");
            Assert.AreEqual(applicationIdentifier.DataContent, "Batch or Lot Number");
            Assert.AreEqual(applicationIdentifier.Format, GS1ApplicationIdentifierFormat.AnyCharacter);
            Assert.AreEqual(applicationIdentifier.MinLength, 1);
            Assert.AreEqual(applicationIdentifier.MaxLength, 20);
        }

        [TestMethod]
        [TestCategory("Application Identifier")]
        [Owner("Viktor")]
        public void TestCreateBestBeforeDate()
        {
            GS1ApplicationIdentifier applicationIdentifier = new GS1ApplicationIdentifier(
                "15",
                "Best Before Date",
                GS1ApplicationIdentifierFormat.DateYYMMDD,
                6,
                6);

            Assert.AreEqual(applicationIdentifier.AI, "15");
            Assert.AreEqual(applicationIdentifier.DataContent, "Best Before Date");
            Assert.AreEqual(applicationIdentifier.Format, GS1ApplicationIdentifierFormat.DateYYMMDD);
            Assert.AreEqual(applicationIdentifier.MinLength, 6);
            Assert.AreEqual(applicationIdentifier.MaxLength, 6);
        }

    }
}
