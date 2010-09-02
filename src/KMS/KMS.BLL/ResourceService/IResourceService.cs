using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public interface IResourceService
    {
        ResourceInfo GetById(Guid id);
        void Insert(ResourceInfo resource);
        void Update(ResourceInfo resource);
    }
}
