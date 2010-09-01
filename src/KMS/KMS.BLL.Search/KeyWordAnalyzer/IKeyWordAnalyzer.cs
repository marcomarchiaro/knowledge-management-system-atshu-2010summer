using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL.Search
{
    public interface IKeyWordAnalyzer
    {
        IEnumerable<string> DoAnalyze(IEnumerable<string> input);
    }
}
