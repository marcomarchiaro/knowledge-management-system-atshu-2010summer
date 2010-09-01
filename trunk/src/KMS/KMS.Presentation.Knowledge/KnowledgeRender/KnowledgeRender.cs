using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using System.Xml;
using KMS.BLL;
using System.IO;

namespace KMS.Presentation.Knowledge
{
    public class KnowledgeRender : IKnowledgeRender
    {
        public KnowledgeRender(ITemplateRender templateRender)
        {
            this.templateRender = templateRender;
        }

        public string RenderKnowledge(KnowledgeInfo knowledge)
        {         
            XmlDocument xml = new XmlDocument();
            string content = knowledge.Content;
            xml.LoadXml(content);
            XmlNodeList nodeList = xml.DocumentElement.ChildNodes;

            foreach (var node in nodeList)
            {
                XmlElement xe = node as XmlElement;
                XmlNode parent = xe.ParentNode;
                if (xe == null) continue;

                if (!templateRender.IsSupported(xe.Name))
                    continue;

                string rendered = templateRender.Render(xe.ToString());

                XmlDocumentFragment fragment = xml.CreateDocumentFragment();
                fragment.InnerXml = rendered;
                XmlNode x= fragment.FirstChild;

                parent.ReplaceChild(x, xe);

            }
            return xml.OuterXml;
        }

        private ITemplateRender templateRender;
    }
}
