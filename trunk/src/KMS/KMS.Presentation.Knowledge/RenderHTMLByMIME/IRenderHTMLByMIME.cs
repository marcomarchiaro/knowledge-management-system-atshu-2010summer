using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public interface IRenderHTMLByMIME
    {
        string RenderHTML(string MIME);
    }
}
