using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.GS1Barcodes
{
    /// <summary>
    /// Date parser functions
    /// </summary>
    public static class DateParser
    {
        /// <summary>
        /// Converts yymmdd format string to DateTime
        /// </summary>
        /// <param name="data">yymmdd format string</param>
        /// <returns>DateTime value</returns>
        public static DateTime ParseString(string data)
        {
            return DateTime.ParseExact(data, "yyMMdd", null, DateTimeStyles.None);
        }
    }
}
