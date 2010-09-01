using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Common;
using System.Collections.Specialized;

namespace KMS.Presentation.Knowledge
{
    public class MultiMediaRender : IMultiMediaRender
    {
        public MultiMediaRender()
        {
            renders.Add(new ImageRender());
        }

        public bool IsSupported(string MIME)
        {
            foreach (var r in renders)
            {
                if (r.IsSupported(MIME))
                    return true;
            }
            return false;
        }

        public string Render(string URL, string MIME, NameValueCollection options)
        {
            foreach (var r in renders)
            {
                if (r.IsSupported(MIME))
                    return r.Render(URL, MIME, options);
            }
            throw new MIMENotSupportedException();
        }

        private IList<IMultiMediaRender> renders = new List<IMultiMediaRender>();
    }
}
