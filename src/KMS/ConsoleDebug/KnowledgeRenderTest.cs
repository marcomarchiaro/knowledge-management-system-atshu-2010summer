using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Presentation.Knowledge;

namespace ConsoleDebug
{
    public class KnowledgeRenderTest
    {
        static public void Test()
        {
            KMS.Model.KnowledgeInfo knowledge = new KMS.Model.KnowledgeInfo();
            knowledge.Content = @"
<html>
    <KMSResource id='3' />
    <div>
        你好
        <KMSResource id='1' />
        <KMSResource id='2' />
    </div>
    <KMSResource id='3' />
    <span>
        <div>
            <KMSResource id='3' />
        </div>
        谢谢
        <KMSResource id='4' />
    </span>
</html>";
            //knowledge.Content = "";
            KnowledgeRender render = new KnowledgeRender(new TempRender());
            string result = render.RenderKnowledge(knowledge);
            Console.Write(result);
            Console.ReadKey();
        }

        class TempRender : ITemplateRender
        {
            
            public TempRender()
            {

            }

            public bool IsSupported(string tagName)
            {
                if (tagName == "KMSResource") return true;
                return false;
            }

            public string Render(string segment)
            {
                string result = "<img src=\"string.jpg\"></img>";
                return result;
            }
        }
    }
}
