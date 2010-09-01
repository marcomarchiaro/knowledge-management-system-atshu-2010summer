using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public interface IMultiMediaRender
    {
        bool IsSupport(string MIME);
        string RenderHTML(string URL, string MIME, object options);
    }
}
