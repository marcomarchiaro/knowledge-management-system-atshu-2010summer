using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KMS.BLL;
using KMS.Model;

namespace KMS.Presentation.Controllers
{
    public class ResourceController : Controller
    {
        //
        // GET: /Resource/

        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        public ActionResult Resource(string resourceId)
        {
            Guid guid = new Guid(resourceId);
            ResourceInfo resource = resourceService.GetById(guid);
            if (resource is Resource_URLInfo)
                return this.Resource_URL(resource as Resource_URLInfo);
            else if (resource is Resource_BinaryInfo)
                return this.Resource_Binary(resource as Resource_BinaryInfo);
            else
                return Content("", "text/plain");
        }

        private ActionResult Resource_Binary(Resource_BinaryInfo resource)
        {
            byte[] content = resource.Binary;
            string MIME = resource.MIME;
            return File(content, MIME);
        }

        private ActionResult Resource_URL(Resource_URLInfo resource)
        {
            string url = resource.URL;
            return Content(url, "text/plain");
        }

        private IResourceService resourceService;
    }
}
