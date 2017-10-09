using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.GS1Barcodes
{
    public class GS1ApplicationIdentifier
    {
        #region Properties
        public string AI { get; private set; }
        public string DataContent { get; private set; }
        public GS1ApplicationIdentifierFormat Format { get; private set; }
        public int MinLength { get; private set; }
        public int MaxLength { get; private set; }
        #endregion

        #region Constructors
        public GS1ApplicationIdentifier(
            string ai,
            string dataContent,
            GS1ApplicationIdentifierFormat format,
            int minLength,
            int maxLength)
        {
            this.AI = ai;
            this.DataContent = dataContent;
            this.Format = format;
            this.MinLength = minLength;
            this.MaxLength = maxLength;
        }
        #endregion
    }
}
