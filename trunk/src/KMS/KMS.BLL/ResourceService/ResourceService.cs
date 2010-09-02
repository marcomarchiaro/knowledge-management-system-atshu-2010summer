using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.DAL;

namespace KMS.BLL
{
    public class ResourceService : IResourceService
    {
        public ResourceService(IRepository<ResourceInfo> resourceRepository)
        {
            this.resourceRepository = resourceRepository;
        }

        public ResourceInfo GetById(Guid id)
        {
            return resourceRepository.GetById(id);
        }

        private IRepository<ResourceInfo> resourceRepository;


        public void Insert(ResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        public void Update(ResourceInfo resource)
        {
            throw new NotImplementedException();
        }
    }
}
