using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public interface IMultiMediaRender
    {
        IEnumerable<string> SupportedMIME { get; }
        string RenderHTML(string URL, string MIME, object options);
    }
}
