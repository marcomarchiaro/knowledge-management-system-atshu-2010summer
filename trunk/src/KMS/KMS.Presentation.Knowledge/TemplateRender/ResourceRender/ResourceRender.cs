using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.BLL;
using KMS.Common;
using System.Collections.Specialized;

namespace KMS.Presentation.Knowledge
{
    public class ResourceRender : IResourceRender
    {
        public ResourceRender(IResourceService resourceService, IMultiMediaRender multiMediaRender)
        {
            this.resourceService = resourceService;
            this.multiMediaRender = multiMediaRender;
        }

        public string Render(ResourceInfo resource)
        {
            if(resource is Resource_BinaryInfo)
                return RenderResource_Binary((Resource_BinaryInfo)resource);
            else if(resource is Resource_URLInfo)
                return RenderResource_URL((Resource_URLInfo)resource);
            else
                throw new Exception("Type not found.");
        }

        private string RenderResource_Binary(Resource_BinaryInfo resource)
        {
            string url = getBinaryResourceLocation(resource);
            string MIME = resource.MIME;
            
            if (!multiMediaRender.IsSupported(resource.MIME))
                throw new MIMENotSupportedException();

            NameValueCollection collection = new NameValueCollection();

            if (resource.Width != null)
                collection.Add("width", resource.Width.ToString());
            if (resource.Height != null)
                collection.Add("height", resource.Height.ToString());

            string html=multiMediaRender.Render(
                url,
                resource.MIME,
                collection);
            return html;
        }

        private string RenderResource_URL(Resource_URLInfo resource)
        {
            if (!multiMediaRender.IsSupported(resource.MIME))
                throw new MIMENotSupportedException();

            NameValueCollection collection = new NameValueCollection();

            if (resource.Width != null)
                collection.Add("width", resource.Width.ToString());
            if (resource.Height != null)
                collection.Add("height", resource.Height.ToString());

            string html = multiMediaRender.Render(
                resource.URL,
                resource.MIME,
                collection);
            return html;
        }

        private string getBinaryResourceLocation(Resource_BinaryInfo resource)
        {
            string location = ConfigManager.GetValue("BinaryResourceLocation");
            if (location.EndsWith("/"))
                return location + resource.ResourceId;
            else
                return location + "/" + resource.ResourceId;
        }

        public string Render(Guid resourceId)
        {
            ResourceInfo resource = resourceService.GetById(resourceId);
            return Render(resource);
        }

        private IResourceService resourceService;
        private IMultiMediaRender multiMediaRender;
    }
}
