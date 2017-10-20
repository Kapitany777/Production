using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.GS1Barcodes
{
    public class GS1ApplicationIdentifierNotFoundException : Exception
    {
        public GS1ApplicationIdentifierNotFoundException() { }
        public GS1ApplicationIdentifierNotFoundException(string message) : base(message) { }
        public GS1ApplicationIdentifierNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GS1FieldLengthException : Exception
    {
        public GS1FieldLengthException() { }
        public GS1FieldLengthException(string message) : base(message) { }
        public GS1FieldLengthException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GS1NumberFormatException : Exception
    {
        public GS1NumberFormatException() { }
        public GS1NumberFormatException(string message) : base(message) { }
        public GS1NumberFormatException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GS1DateFormatException : Exception
    {
        public GS1DateFormatException() { }
        public GS1DateFormatException(string message) : base(message) { }
        public GS1DateFormatException(string message, Exception innerException) : base(message, innerException) { }
    }
}
