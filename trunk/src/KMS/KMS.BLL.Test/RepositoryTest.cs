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
        IRepository<Resource_ImageInfo> ResourceImageR;
        IRepository<TagInfo> TagR;
        IRepository<ResourceTagAssociationInfo> ResourceTagAssociationR;
        ISessionManager SessionManager;

        [SetUp]
        public void Init()
        {
            container = new WindsorContainer("Windsor.config");
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifeStyle.Transient);
            ResourceR = container.Resolve<IRepository<ResourceInfo>>();
            ResourceImageR = container.Resolve<IRepository<Resource_ImageInfo>>();
            ResourceTagAssociationR = container.Resolve<IRepository<ResourceTagAssociationInfo>>();
            TagR = container.Resolve<IRepository<TagInfo>>();
            SessionManager = container.Resolve<ISessionManager>();
        }

        [Test]
        public void GetResource_Flash()
        {
            ResourceInfo r = ResourceR.GetById(new Guid("96533852-291f-4707-8fb2-4dca88551e93"));
            Console.WriteLine(r.GetType());
            Console.WriteLine(r.Name);
            Assert.AreEqual("name93", r.Name);
            Assert.True(r is Resource_FlashInfo);
        }

        [Test]
        public void CreateResource_Image()
        {
            Resource_ImageInfo ri;
            ri = new Resource_ImageInfo();
            ri.Image = ASCIIEncoding.ASCII.GetBytes("123");
            ri.MIME = "jpeg";
            ResourceImageR.SaveOnSubmit(ri);
            ResourceImageR.SubmitChanges();
        }

        [Test]
        public void GetResource_Image()
        {
            ResourceInfo resource = ResourceR.GetById(new Guid("17a8f22c-4822-4b48-8245-1a3d5468ba7b"));
            Assert.True(resource is Resource_ImageInfo);
            byte[] b = ((Resource_ImageInfo)resource).Image;
            Assert.True(Encoding.ASCII.GetString(b) == "123");
        }

        //测试抓取策略，多态查询，应将ResourceTagAssociation.ResourceInfo的抓取策略设为join
        [Test]
        public void ResourceTagAssociation()
        {
            ResourceTagAssociationInfo rta = ResourceTagAssociationR.GetById(1);
            Assert.True(rta.ResourceInfo.GetType() is Resource_FlashInfo);
        }

        [Test]
        public void UpdateTag()
        {
            TagInfo tag = TagR.GetById(1);
            tag.Description = "updated";
            TagR.UpdateOnSubmit(tag);
            TagR.SubmitChanges();
        }

        [Test]
        public void SameSession()
        {
            ISession s1 = SessionManager.OpenSession();
            ISession s2 = SessionManager.OpenSession();
            Assert.True(s1 == s2);
        }
    }
}
