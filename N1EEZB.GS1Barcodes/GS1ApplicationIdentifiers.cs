using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.GS1Barcodes
{
    public class GS1ApplicationIdentifiers
    {
        #region Private fields
        private List<GS1ApplicationIdentifier> applicationIdentifiers;
        #endregion

        #region Constructors
        public GS1ApplicationIdentifiers()
        {
            applicationIdentifiers = new List<GS1ApplicationIdentifier>();

            CreateApplicationIdentifiers();
        }
        #endregion

        #region Private methods
        private void CreateApplicationIdentifiers()
        {
            applicationIdentifiers.Add(new GS1ApplicationIdentifier(
                "01",
                "Global Trade Item Number",
                GS1ApplicationIdentifierFormat.NumericDigit,
                14,
                14));

            applicationIdentifiers.Add(new GS1ApplicationIdentifier(
                "10",
                "Batch or Lot Number",
                GS1ApplicationIdentifierFormat.AnyCharacter,
                1,
                20));

            applicationIdentifiers.Add(new GS1ApplicationIdentifier(
                "13",
                "Packaging Date",
                GS1ApplicationIdentifierFormat.DateYYMMDD,
                6,
                6));

            applicationIdentifiers.Add(new GS1ApplicationIdentifier(
                "15",
                "Best Before Date",
                GS1ApplicationIdentifierFormat.DateYYMMDD,
                6,
                6));

            applicationIdentifiers.Add(new GS1ApplicationIdentifier(
                "17",
                "Expiration Date",
                GS1ApplicationIdentifierFormat.DateYYMMDD,
                6,
                6));

            applicationIdentifiers.Add(new GS1ApplicationIdentifier(
                "422",
                "Country of Origin of a Trade Item",
                GS1ApplicationIdentifierFormat.NumericDigit,
                3,
                3));
        }
        #endregion

        #region Public methods
        public GS1ApplicationIdentifier GetApplicationIdentifier(string ai)
        {
            var result =
                from a in applicationIdentifiers
                where a.AI == ai
                select a;

            if (result.Any())
            {
                return result.First();
            }
            else
            {
                throw new GS1ApplicationIdentifierNotFoundException();
            }
        }
        #endregion
    }
}
