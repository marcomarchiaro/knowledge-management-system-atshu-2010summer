using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace KMS.Presentation.Knowledge
{
    public interface IMultiMediaRender
    {
        bool IsSupported(string MIME);
        string Render(string URL, string MIME, NameValueCollection options);
    }
}
