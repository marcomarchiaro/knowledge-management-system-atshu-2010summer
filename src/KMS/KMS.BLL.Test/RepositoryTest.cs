using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Facilities.NHibernateIntegration;
using KMS.BLL;
using KMS.Model;


namespace KMS.BLL.Test
{
    [TestFixture]
    public class RepositoryTest
    {
        IWindsorContainer container;
        IRepository<ResourceInfo> ResourceR;
        IRepository<Resource_BinaryInfo> ResourceBinaryR;
        IRepository<TagInfo> TagR;
        IRepository<ResourceTagAssociationInfo> ResourceTagAssociationR;
        ISessionManager SessionManager;

        [SetUp]
        public void Init()
        {
            container = new WindsorContainer("Windsor.config");
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.Transient);
            ResourceR = container.Resolve<IRepository<ResourceInfo>>();
            ResourceBinaryR = container.Resolve<IRepository<Resource_BinaryInfo>>();
            ResourceTagAssociationR = container.Resolve<IRepository<ResourceTagAssociationInfo>>();
            TagR = container.Resolve<IRepository<TagInfo>>();
            SessionManager = container.Resolve<ISessionManager>();
        }

        //测试用IRepository<ResourceInfo>取出Resource_URLInfo
        [Test]
        public void GetResource_URL()
        {
            ResourceInfo r = ResourceR.GetById(new Guid("96533852-291f-4707-8fb2-4dca88551e93"));
            Console.WriteLine(r.GetType());
            Console.WriteLine(r.Name);
            Assert.AreEqual("name93", r.Name);
            Assert.True(r is Resource_URLInfo);
        }

        //测试用IRepository<Resource_BinaryInfo>插入数据
        [Test]
        public void InsertResource_Binary()
        {
            Resource_BinaryInfo ri;
            ri = new Resource_BinaryInfo();
            ri.Binary = ASCIIEncoding.ASCII.GetBytes("123");
            ri.MIME = "jpeg";
            ResourceBinaryR.SaveOnSubmit(ri);
            ResourceBinaryR.SubmitChanges();
        }


        //测试用IRepository<ResourceInfo>取出Resource_BinaryInfo，并测试二进制数据是否正确
        [Test]
        public void GetResource_Binary()
        {
            ResourceInfo resource = ResourceR.GetById(new Guid("17a8f22c-4822-4b48-8245-1a3d5468ba7b"));
            Assert.True(resource is Resource_BinaryInfo);
            byte[] b = ((Resource_BinaryInfo)resource).Binary;
            Assert.True(Encoding.ASCII.GetString(b) == "123");
        }

        //测试抓取策略，多态查询，应将ResourceTagAssociation.ResourceInfo的抓取策略设为join
        [Test]
        public void ResourceTagAssociation()
        {
            ResourceTagAssociationInfo rta = ResourceTagAssociationR.GetById(1);
            Assert.True(rta.ResourceInfo.GetType() == typeof(Resource_URLInfo));
        }

        //测试2次取出是否为同一个session
        [Test]
        public void SameSession()
        {
            ISession s1 = SessionManager.OpenSession();
            ISession s2 = SessionManager.OpenSession();
            Assert.True(s1 == s2);
        }

        //测试是否能用IRepository<ResourceInfo>来添加Resource_URLInfo，以及guid是否能返回。
        [Test]
        public void InsertURL()
        {
            Resource_URLInfo URL = new Resource_URLInfo();
            URL.Description = "InsertURL";
            URL.URL = "InsertURL";
            URL.SourceName = "InsertURL";
            ResourceR.SaveOnSubmit(URL);
            ResourceR.SubmitChanges();
            Console.WriteLine(URL.ResourceId);
        }

        //测试插入的数据是否能返回ID号，可以。
        [Test]
        public void InsertTag()
        {
            TagInfo tag = new TagInfo();
            tag.Name = "InsertTag";
            tag.Description = "InsertTag";
            TagR.SaveOnSubmit(tag);
            TagR.SubmitChanges();

            TagInfo tag2 = new TagInfo();
            tag2.Name = "InsertTag2";
            tag2.Description = "InsertTag2";
            TagR.SaveOnSubmit(tag2);
            TagR.SubmitChanges();

            Console.WriteLine(tag.TagId);
        }
    }
}
