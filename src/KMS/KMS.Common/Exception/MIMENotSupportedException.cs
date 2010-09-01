using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Common
{
    public class MIMENotSupportedException : Exception
    {
        public MIMENotSupportedException() : base() { }
        public MIMENotSupportedException(string msg) : base(msg) { }
    }
}
