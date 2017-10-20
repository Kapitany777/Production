using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.GS1Barcodes
{
    public class GS1Barcode
    {
        #region Properties
        public string Barcode { get; private set; }
        public string GlobalTradeItemNumber { get; private set; }
        public string BatchOrLotNumber { get; private set; }
        public DateTime PackagingDate { get; private set; }
        public DateTime BestBeforeDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string CountryOfOrigin { get; private set; }
        #endregion

        #region Constructors
        public GS1Barcode(string barcode)
        {
            this.Barcode = barcode;

            ParseBarcode();
        }
        #endregion

        #region Private methods
        private void SetStringField(GS1ApplicationIdentifier applicationIdentifier, string data)
        {
            switch (applicationIdentifier.AI)
            {
                case "10":
                    this.BatchOrLotNumber = data;
                    break;

                default:
                    break;
            }
        }

        private void SetNumericField(GS1ApplicationIdentifier applicationIdentifier, string data)
        {
            try
            {
                decimal dec = decimal.Parse(data);
            }
            catch (FormatException)
            {
                throw new GS1NumberFormatException();
            }

            switch (applicationIdentifier.AI)
            {
                case "01":
                    this.GlobalTradeItemNumber = data;
                    break;

                case "422":
                    this.CountryOfOrigin = data;
                    break;

                default:
                    break;
            }
        }

        private void SetDateField(GS1ApplicationIdentifier applicationIdentifier, string data)
        {
            DateTime date;

            try
            {
                date = DateParser.ParseString(data);
            }
            catch (FormatException)
            {
                throw new GS1DateFormatException();
            }

            switch (applicationIdentifier.AI)
            {
                case "13":
                    this.PackagingDate = date;
                    break;

                case "15":
                    this.BestBeforeDate = date;
                    break;

                case "17":
                    this.ExpirationDate = date;
                    break;

                default:
                    break;
            }
        }

        private void SetField(GS1ApplicationIdentifier applicationIdentifier, string data)
        {
            switch (applicationIdentifier.Format)
            {
                case GS1ApplicationIdentifierFormat.AnyCharacter:
                    SetStringField(applicationIdentifier, data);
                    break;

                case GS1ApplicationIdentifierFormat.NumericDigit:
                    SetNumericField(applicationIdentifier, data);
                    break;

                case GS1ApplicationIdentifierFormat.DateYYMMDD:
                    SetDateField(applicationIdentifier, data);
                    break;
            }
        }

        private void ParseBarcode()
        {
            GS1ApplicationIdentifiers applicationIdentifiers = new GS1ApplicationIdentifiers();
            StringBuilder sbApplicationIdentifier = new StringBuilder();
            StringBuilder sbBarcodeData = new StringBuilder();

            int pos = 0;

            while (pos < Barcode.Length)
            {
                sbApplicationIdentifier.Append(Barcode[pos]);

                try
                {
                    GS1ApplicationIdentifier applicationIdentifier = applicationIdentifiers.GetApplicationIdentifier(sbApplicationIdentifier.ToString());

                    for (int i = 0; i < applicationIdentifier.MaxLength && pos < Barcode.Length - 1; i++)
                    {
                        char c = Barcode[++pos];

                        if (c != ' ')
                        {
                            sbBarcodeData.Append(c);
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (sbBarcodeData.ToString().Length < applicationIdentifier.MinLength ||
                        sbBarcodeData.ToString().Length > applicationIdentifier.MaxLength)
                    {
                        throw new GS1FieldLengthException();
                    }

                    SetField(applicationIdentifier, sbBarcodeData.ToString());

                    sbApplicationIdentifier.Clear();
                    sbBarcodeData.Clear();
                }
                catch (GS1ApplicationIdentifierNotFoundException) { }
                catch (IndexOutOfRangeException)
                {
                    throw;
                }
                catch (FormatException)
                {
                    throw;
                }

                pos++;
            }

            if (sbApplicationIdentifier.Length != 0)
            {
                throw new GS1ApplicationIdentifierNotFoundException();
            }
        }
        #endregion
    }
}
