using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public class ResourceService : IResourceService
    {
        public ResourceService(IRepository<ResourceInfo> resourceRepository)
        {
            this.resourceRepository = resourceRepository;
        }

        public ResourceInfo GetById(object id)
        {
            return resourceRepository.GetById(id);
        }

        private IRepository<ResourceInfo> resourceRepository;
    }
}
