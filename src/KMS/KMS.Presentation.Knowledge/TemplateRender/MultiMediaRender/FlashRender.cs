using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using KMS.Common;

namespace KMS.Presentation.Knowledge
{
    public class FlashRender : IMultiMediaRender
    {
        /*<embed src="http://player.youku.com/player.php/sid/XMjAzMDQ2NjQ0/v.swf" 
         * quality="high" width="480" height="400" align="middle" 
         * allowScriptAccess="sameDomain" type="application/x-shockwave-flash"></embed>*/
        public bool IsSupported(string MIME)
        {
            if (supportedMIME.Contains(MIME))
                return true;
            return false;
        }

        private string generateAttrs(NameValueCollection options)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var key in options.AllKeys)
                sb.Append(string.Format("{0}='{1}' ", key, options[key]));
            return sb.ToString();
        }

        public string Render(string URL, string MIME, NameValueCollection options)
        {
            if (!IsSupported(MIME))
                throw new MIMENotSupportedException();
            string attrs = generateAttrs(options);
            string tag = string.Format(@"<embed src='{0}' {1}/>", URL, attrs);
            return tag;
        }
        private string[] supportedMIME = new string[] { "flv-application/octet-stream", "application/x-shockwave-flash", "video/x-flv" };
    }
}
