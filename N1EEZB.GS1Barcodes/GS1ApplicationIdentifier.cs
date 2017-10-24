using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.GS1Barcodes
{
    /// <summary>
    /// GS1 Application Identifier class
    /// </summary>
    public class GS1ApplicationIdentifier
    {
        #region Properties
        /// <summary>
        /// Application Identifier
        /// </summary>
        public string AI { get; private set; }

        /// <summary>
        /// The content of the field
        /// </summary>
        public string DataContent { get; private set; }

        /// <summary>
        /// The format of data
        /// </summary>
        public GS1ApplicationIdentifierFormat Format { get; private set; }

        /// <summary>
        /// Minimum length of data
        /// </summary>
        public int MinLength { get; private set; }

        /// <summary>
        /// Maximum length of data
        /// </summary>
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
