using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.BLL.Search;
using KMS.Presentation.Knowledge;
using KMS.BLL;
using KMS.Model;
using NUnit.Framework;

namespace KMS.Test
{
    [TestFixture]
    public class TemplateRenderTest
    {
        [Test]
        public void Test1()
        {
            ITemplateRender templateRender = new ResourceTemplateRender(new ResourceRender(new ResourceServiceURL(), new MultiMediaRender()));
            string str = templateRender.Render("<KMSResource id='f01a54e4-0056-46e3-9342-617d3a4048d3' />");
            Console.WriteLine(str);
        }
    }
}
