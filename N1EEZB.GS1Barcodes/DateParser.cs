using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.GS1Barcodes
{
    public static class DateParser
    {
        public static DateTime ParseString(string data)
        {
            return DateTime.ParseExact(data, "yyMMdd", null, DateTimeStyles.None);
        }
    }
}
