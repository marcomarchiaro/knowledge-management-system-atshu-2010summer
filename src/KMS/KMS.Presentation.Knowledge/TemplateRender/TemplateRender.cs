using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using KMS.Common;

namespace KMS.Presentation.Knowledge
{
    public class TemplateRender : ITemplateRender
    {
        public TemplateRender(ResourceTemplateRender resourceTemplateRender)
        {
            this.templateRenders.Add(resourceTemplateRender);
        }

        public bool IsSupported(string tagName)
        {
            foreach (var p in templateRenders)
                if (p.IsSupported(tagName))
                    return true;
            return false;
        }

        public string Render(string fregment)
        {
            string tagName = null;
            using (XmlReader reader = new XmlTextReader(new StringReader(fregment)))
            {
                reader.MoveToContent();
                tagName = reader.Name;
            }
            foreach (var p in templateRenders)
            {
                if (p.IsSupported(tagName))
                    return p.Render(fregment);
            }
            throw new TagNotSupportedException();
        }

        private IList<ITemplateRender> templateRenders = new List<ITemplateRender>();
    }
}
