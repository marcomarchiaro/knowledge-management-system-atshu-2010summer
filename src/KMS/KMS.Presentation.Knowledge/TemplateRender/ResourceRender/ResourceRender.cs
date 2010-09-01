using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.Presentation.Knowledge
{
    public class ResourceRender : IResourceRender
    {
        public string RenderResource(ResourceInfo resource)
        {
            throw new NotImplementedException();
        }

        private string RenderResource_Binary(Resource_BinaryInfo resource)
        {
            string url = getBinaryResourceLocation(resource);
            string MIME = resource.MIME;
            throw new NotImplementedException();
        }

        private string getBinaryResourceLocation(Resource_BinaryInfo resource)
        {
            return "/BinaryResource/" + resource.ResourceId;
        }


        public string RenderResource(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
