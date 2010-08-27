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
        }

        [Test]
        public virtual void CreateTest()
        {
        }

        private ResourceTest self;
    }
}
