using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using KMS.Common;

namespace KMS.Presentation.Knowledge
{
    public class ImageRender : IMultiMediaRender
    {
        public string Render(string URL, string MIME, NameValueCollection options)
        {
            if (!IsSupported(MIME))
                throw new MIMENotSupportedException();
            string attrs = generateAttrs(options);
            string tag = string.Format(@"<img src='{0}' {1}/>", URL, attrs);
            return tag;
        }

        private string generateAttrs(NameValueCollection options)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in options.AllKeys)
                sb.Append(string.Format("{0}='{1}' ", key, options[key]));
            return sb.ToString();
        }

        public bool IsSupported(string MIME)
        {
            if (supportedMIME.Contains(MIME))
                return true;
            return false;
        }

        private string[] supportedMIME = new string[] { "image/gif", "image/jpeg", "image/bmp" };
    }
}
