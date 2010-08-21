using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;
using KMS.Model;

namespace KMS.DAL
{
    public interface IResource
    {
        ResourceInfo GetResourceById(Guid id);
        void CreateResource(ResourceInfo resource);
    }
}
