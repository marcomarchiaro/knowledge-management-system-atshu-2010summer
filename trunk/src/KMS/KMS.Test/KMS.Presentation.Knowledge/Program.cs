using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KMS.BLL.Search;
using KMS.Presentation.Knowledge;
using KMS.BLL;
using KMS.Model;

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
            IResourceRender resourceRender = new ResourceRender(new ResourceService2(), new MultiMediaRender());
            string str = resourceRender.Render(new Guid("f01a54e4-0056-46e3-9342-617d3a4048d3"));
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }

    class ResourceService2 : IResourceService
    {
        public ResourceInfo GetById2(Guid id)
        {
            Resource_URLInfo resource = new Resource_URLInfo();
            resource.URL = "http://www.baidu.com";
            resource.MIME = "image/jpeg";
            resource.ResourceId = new Guid("f01a54e4-0056-46e3-9342-617d3a4048d3");
            resource.Width = 100;
            resource.Height = 200;
            return resource;
        }

        public ResourceInfo GetById(Guid id)
        {
            Resource_BinaryInfo resource = new Resource_BinaryInfo();
            resource.MIME = "image/jpeg";
            resource.ResourceId = new Guid("f01a54e4-0056-46e3-9342-617d3a4048d3");
            resource.Width = 100;
            resource.Height = 200;
            return resource;
        }
    }
}
