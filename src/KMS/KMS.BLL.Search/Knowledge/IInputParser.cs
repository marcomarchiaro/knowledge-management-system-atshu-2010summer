using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL.Search.Knowledge
{
    public interface IInputParser
    {
        string GetContent(string input, string tag);
    }
}
