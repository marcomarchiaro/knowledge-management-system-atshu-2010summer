using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public interface IResource
    {
        ResourceInfo GetResourceById(Guid id);
        void CreateResource(ResourceInfo resource);
        void UpdateResource(ResourceInfo resource);
    }
}
