using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;

namespace KMS.DAL
{
    public class Resource : IResource
    {
        public Resource(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        #region IResource 成员

        public ResourceInfo GetResourceById(Guid id)
        {
            ISession session = sessionManager.OpenSession();
            return session.Get<ResourceInfo>(id);
        }

        public void CreateResource(ResourceInfo resource)
        {
            ISession session = sessionManager.OpenSession();
            session.Save(resource);
        }

        #endregion

        private ISessionManager sessionManager;
    }
}
