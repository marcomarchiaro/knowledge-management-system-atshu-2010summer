using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Specialized;
using KMS.Common;

namespace KMS.Presentation.Knowledge
{
    public class ResourceTemplateRender : ITemplateRender
    {
        public ResourceTemplateRender(IResourceRender resourceRender)
        {
            this.resourceRender = resourceRender;
        }

        public bool IsSupported(string tagName)
        {
            if (supportedTags.Contains(tagName))
                return true;
            return false;
        }

        public string Render(string fregment)
        {
            string resourceId = null;
            using (XmlReader reader = new XmlTextReader(new StringReader(fregment)))
            {
                reader.MoveToContent();
                string tagName = reader.Name;
                if (!IsSupported(tagName))
                    throw new TagNotSupportedException();

                while (reader.MoveToNextAttribute())
                {
                    string attr = reader.Name.ToLower();
                    if (attr == attr_id)
                    {
                        resourceId = reader.Value;
                    }
                }
            }
            Guid resourceId2 = new Guid(resourceId);
            return resourceRender.Render(resourceId2);
        }

        private readonly string[] supportedTags = new string[] { "KMSResource" };
        private readonly string attr_id = "id";

        private IResourceRender resourceRender;
    }
}
