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

        static void dfs(XmlNode node, Action<XmlNode> visit)
        {
            if (node.HasChildNodes)
            {
                foreach (XmlNode p in node.ChildNodes)
                {
                    dfs(p, visit);
                }
            }
            visit(node);
        }

        public string RenderKnowledge(KnowledgeInfo knowledge)
        {
            XmlDocument xml = new XmlDocument();
            List<XmlElement> nodelist = new List<XmlElement>();

            if (string.IsNullOrWhiteSpace(knowledge.Content))
                return null;

            xml.LoadXml(knowledge.Content);

            dfs(xml, (x) =>
            {
                if (x is XmlElement && !x.HasChildNodes)
                {
                    nodelist.Add((XmlElement)x);
                }
            });

            foreach (var node in nodelist)
            {
                XmlElement xe = node as XmlElement;
                XmlNode parent = xe.ParentNode;

                if (xe == null)
                    continue;

                if (!templateRender.IsSupported(xe.Name))
                    continue;

                string rendered = templateRender.Render(xe.OuterXml);

                XmlDocumentFragment fragment = xml.CreateDocumentFragment();
                fragment.InnerXml = rendered;
                XmlNode x = fragment.FirstChild;
                parent.ReplaceChild(x, xe);
            }
            return xml.OuterXml;
        }

        private ITemplateRender templateRender;
    }
}
