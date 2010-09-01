using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public class FlashRender : IMultiMediaRender
    {
        public bool IsSupported(string MIME)
        {
            throw new NotImplementedException();
        }

        public string Render(string URL, string MIME, System.Collections.Specialized.NameValueCollection options)
        {
            throw new NotImplementedException();
        }
    }
}
