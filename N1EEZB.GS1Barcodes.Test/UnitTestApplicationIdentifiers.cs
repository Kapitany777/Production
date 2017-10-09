using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace N1EEZB.GS1Barcodes.Test
{
    [TestClass]
    public class UnitTestApplicationIdentifiers
    {
        [TestMethod]
        [TestCategory("Application Identifiers")]
        [Owner("Viktor")]
        public void TestApplicationIdentifier01Found()
        {
            GS1ApplicationIdentifiers ais = new GS1ApplicationIdentifiers();

            GS1ApplicationIdentifier applicationIdentifier = ais.GetApplicationIdentifier("01");

            Assert.IsNotNull(applicationIdentifier);
            Assert.AreEqual(applicationIdentifier.AI, "01");
            Assert.AreEqual(applicationIdentifier.DataContent, "Global Trade Item Number");
            Assert.AreEqual(applicationIdentifier.Format, GS1ApplicationIdentifierFormat.NumericDigit);
            Assert.AreEqual(applicationIdentifier.MinLength, 14);
            Assert.AreEqual(applicationIdentifier.MaxLength, 14);
        }

        [TestMethod]
        [TestCategory("Application Identifiers")]
        [Owner("Viktor")]
        [ExpectedException(typeof(GS1ApplicationIdentifierNotFound))]
        public void TestApplicationIdentifierNotFound()
        {
            GS1ApplicationIdentifiers ais = new GS1ApplicationIdentifiers();

            ais.GetApplicationIdentifier("100");
        }
    }
}
