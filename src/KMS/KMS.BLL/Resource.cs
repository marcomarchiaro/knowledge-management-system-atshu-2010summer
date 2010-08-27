using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;

namespace KMS.BLL
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
            return sessionManager.OpenSession().Get<ResourceInfo>(id);
        }

        public void CreateResource(ResourceInfo resource)
        {
            sessionManager.OpenSession().Save(resource);
        }

        public void UpdateResource(ResourceInfo resource)
        {
            sessionManager.OpenSession().Update(resource);
        }

        public void DeleteResource(Guid id)
        {
            ISession session = sessionManager.OpenSession();
            ResourceInfo resource = session.Load<ResourceInfo>(id);
            session.Delete(resource);
        }

        #endregion

        private ISessionManager sessionManager;


    }
}
