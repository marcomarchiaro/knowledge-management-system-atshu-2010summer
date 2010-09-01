using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace KMS.Presentation.Knowledge
{
    public class KMSResourceRender : ITemplateRender
    {
        public bool IsSupported(string tagName)
        {
            if (supportedTags.Contains(tagName))
                return true;
            return false;
        }

        public string Render(string segment)
        {
            XmlReader reader = new XmlTextReader(new StringReader(segment));
            reader.MoveToContent();
            string tagName = reader.Name;
            if (!IsSupported(tagName))
                throw new Exception("不支持该标记。");
            while (reader.MoveToNextAttribute())
            {
                string attr = reader.Name.ToLower();
                if (attr == attr_id)
                {
                    string temp = reader.Value;
                    Guid resourceId = new Guid(temp);

                }
            }
            string name = reader.Name;
            throw new NotImplementedException();
        }

        private readonly string[] supportedTags = new string[] { "KMSResource" };
        private readonly string attr_id = "id";
    }
}
