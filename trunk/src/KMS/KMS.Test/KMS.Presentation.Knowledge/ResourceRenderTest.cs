using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KMS.BLL.Search;
using KMS.Presentation.Knowledge;
using KMS.BLL;
using KMS.Model;
using NUnit.Framework;
using KMS.DAL;

namespace KMS.Test
{
    [TestFixture]
    public class ResourceRenderTest
    {
        [Test]
        public void TestResource_URL()
        {
            IResourceRender resourceRender = new ResourceRender(new URLResourceRepository(), new MultiMediaRender());
            string str = resourceRender.Render(new Guid("f01a54e4-0056-46e3-9342-617d3a4048d3"));
            Console.WriteLine(str);
        }

        [Test]
        public void TestResource_Binary()
        {
            IResourceRender resourceRender = new ResourceRender(new BinaryResourceRepository(), new MultiMediaRender());
            string str = resourceRender.Render(new Guid("f01a54e4-0056-46e3-9342-617d3a4048d3"));
            Console.WriteLine(str);
        }
    }

    public class BinaryResourceRepository : IRepository<ResourceInfo>
    {
        public ResourceInfo GetById(object id)
        {
            Resource_BinaryInfo resource = new Resource_BinaryInfo();
            resource.MIME = "image/jpeg";
            resource.ResourceId = new Guid("f01a54e4-0056-46e3-9342-617d3a4048d3");
            resource.Width = 100;
            resource.Height = 200;
            return resource;
        }


        public void Insert(ResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        public void Update(ResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        public NHibernate.IQuery HqlQuery(string queryString)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ResourceInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }


        public void SaveOrUpdateOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }
    }

    public class URLResourceRepository : IRepository<ResourceInfo>
    {
        public ResourceInfo GetById(object id)
        {
            Resource_URLInfo resource = new Resource_URLInfo();
            resource.URL = "http://www.baidu.com";
            resource.MIME = "image/jpeg";
            resource.ResourceId = new Guid("f01a54e4-0056-46e3-9342-617d3a4048d3");
            resource.Width = 100;
            resource.Height = 200;
            return resource;
        }

        public void Insert(ResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        public void Update(ResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        public NHibernate.IQuery HqlQuery(string queryString)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ResourceInfo> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }


        public void SaveOrUpdateOnSubmit(ResourceInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
