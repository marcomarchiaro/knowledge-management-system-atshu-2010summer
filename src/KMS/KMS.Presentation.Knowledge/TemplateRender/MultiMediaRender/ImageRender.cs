using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public class ImageRender : IMultiMediaRender
    {
        public string RenderHTML(string URL, string MIME, object options)
        {
            if (supportedMIME.Contains(MIME))
            {
                string tag = string.Format(@"<img src='{0}'", URL);
                return tag;
            }
            throw new Exception("MIME类型不匹配。");
        }

        public bool IsSupport(string MIME)
        {
            throw new NotImplementedException();
        }

        private string[] supportedMIME = new string[] { "image/gif", "image/jpeg", "image/bmp" };
    }
}
