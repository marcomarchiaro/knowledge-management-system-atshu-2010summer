using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL
{
    public interface ITagAnalyzer
    {
        IEnumerable<string> Analyze(string input);
    }
}
