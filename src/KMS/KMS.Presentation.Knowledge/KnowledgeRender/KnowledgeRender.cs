using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using KMS.Model;
using KMS.BLL;

namespace KMS.Presentation.Knowledge
{
    public class KnowledgeRender : IKnowledgeRender
    {
        public KnowledgeRender(IResourceService resourceService, ITemplateRender templateRender)
        {
            this.resourceService = resourceService;
            this.templateRender = templateRender;
        }

        public string RenderKnowledge(KnowledgeInfo knowledge)
        {
            #region
            //List<string> process = new List<string>();
            //List<int> idList = new List<int>();
            //char[] trimer={'\"',' '};
            //string content = knowledge.Content;
            //bool flag1 = false;
            //bool flag2 = false;
            //int indexReplace = 0;
            //indexReplace = content.IndexOf("<KMS:Resource");
            //while (indexReplace != -1)
            //{
            //    string temp = "";
            //    flag1 = flag2 = false;
            //    for (int i = indexReplace; i < content.Length; i++)
            //    {
            //        temp += content[i];
            //        content.Remove(indexReplace, 1);
            //        if (content[i] == '/') flag1 = true;
            //        if (flag1 && content[i] == '>') flag2 = true;
            //        if (flag1 && flag2)
            //        {
            //            process.Add(temp);
            //            break;
            //        }

            //    }
            //    index = content.IndexOf("<KMS:Resource");
            //}

            //foreach (string s in process)
            //{
            //    index = s.IndexOf("id=");
            //    flag1 = false;
            //    flag2 = false;
            //    if (index != -1)
            //    {
            //        string temp = "";
            //        for (int i = index+3; i < s.Length; i++)
            //        {
            //            if (s[i] == '\"') flag1 = true;
            //            if (flag1 && s[i] == '\"') flag2 = true;
            //            if (flag1 && flag2)
            //            {
            //                temp.Trim(trimer);
            //                break;
            //            }
            //            if(flag1)
            //                temp += s[i];
            //        }
            //        Guid guid = new Guid(temp);
            //        ResourceInfo r = resourceRepository.GetById(guid);
            //        temp = resourceRender.RenderResource(r);
            //    }
            //}
            #endregion
            XmlDocument xml = new XmlDocument();
            string content = knowledge.Content;
            content.Insert(0, "<?xml version='1.0' encoding='utf-8' ?>");
            xml.LoadXml(content);
            XmlNodeList nodeList = xml.SelectNodes("KMS");

            foreach (var node in nodeList)
            {
                XmlElement xe = node as XmlElement;
                if (xe == null) continue;

                string temp =xe.GetAttribute("id");
                if (string.IsNullOrEmpty(temp)) continue;

                Guid resourceId = new Guid(temp);
                resourceRender.RenderResource(resourceService.GetById(resourceId));
            }
            
            throw new NotImplementedException();
        }

        private IResourceService resourceService;
        private ITemplateRender templateRender;
    }
}
