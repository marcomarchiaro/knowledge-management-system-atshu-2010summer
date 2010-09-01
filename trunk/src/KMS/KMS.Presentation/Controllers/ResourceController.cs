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

        public ActionResult GetResource(string resourceId)
        {
            Guid guid = new Guid(resourceId);
            throw new NotImplementedException();
        }

        public ActionResult GetBinaryResource(string resourceId)
        {
            Guid guid = new Guid(resourceId);
            ResourceInfo resource = resourceService.GetById(guid);
            if (resource is Resource_BinaryInfo)
            {
                Resource_BinaryInfo resource2 = (Resource_BinaryInfo)resource;
                byte[] content = resource2.Binary;
                string MIME = resource2.MIME;
                return File(content, MIME);
            }
            throw new Exception("无法找到资源");
        }

        private IResourceService resourceService;
    }
}
