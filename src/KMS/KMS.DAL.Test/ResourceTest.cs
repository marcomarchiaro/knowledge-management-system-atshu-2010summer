using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Facilities.NHibernateIntegration;
using KMS.DAL;
using KMS.Model;

namespace KMS.DAL.Test
{
    [TestFixture]
    public class ResourceTest
    {
        [SetUp]
        public void Init()
        {
            IWindsorContainer container = new WindsorContainer("Windsor.config");
            container.Register(Component.For<IResource>().ImplementedBy<Resource>());

            resource = container.Resolve<IResource>();
            self = container.Resolve<ResourceTest>();
        }

        [Test]
        public virtual void CreateTest()
        {
            Resource_URLInfo r = new Resource_URLInfo();
            r.Description = "CreateTest";
            resource.CreateResource(r);
        }

        private IResource resource;
        private ResourceTest self;
    }
}
