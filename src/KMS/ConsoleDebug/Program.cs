using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KMS.BLL.Search;
using KMS.Presentation.Knowledge;

namespace ConsoleDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            test1();
        }

        static void test1()
        {
            KMSResourceRender render = new KMSResourceRender();
            string segment = "<KMSResource id='1' id2='2' />";
            render.Render(segment);
        }
    }
}
