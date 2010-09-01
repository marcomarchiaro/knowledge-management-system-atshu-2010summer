using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KMS.BLL.Search;
using KMS.Presentation.Knowledge;
using KMS.BLL;
using KMS.Model;
using KMS.Test;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            TemplateRenderTest test = new TemplateRenderTest();
            test.Test1();
            KnowledgeRenderTest.Test();
        }
    }
}
