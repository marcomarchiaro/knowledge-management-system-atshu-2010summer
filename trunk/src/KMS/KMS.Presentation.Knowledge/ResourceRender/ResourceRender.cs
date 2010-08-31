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
            string url = getResourcePath(resource.ResourceId);
            string MIME = resource.MIME;
            throw new NotImplementedException();
        }

        private string getResourcePath(Guid resourceId)
        {
            return "/Resource/" + resourceId.ToString();
        }
    }
}
