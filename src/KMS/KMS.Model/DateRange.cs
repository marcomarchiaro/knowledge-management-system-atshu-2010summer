using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Model
{
    public struct DateRange
    {
        public DateRange(DateTime begin, DateTime end)
        {
            this.Begin = begin;
            this.End = end;
        }

        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
    }
}
