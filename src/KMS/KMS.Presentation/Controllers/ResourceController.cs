using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KMS.BLL;
using KMS.Model;
using KMS.Presentation.Knowledge;
using Castle.Facilities.Logging;

namespace KMS.Presentation.Controllers
{
    public class ResourceController : Controller
    {
        //
        // GET: /Resource/
        public ResourceController(IResourceService resourceService, IResourceRender resourceRender)
        {
            this.resourceService = resourceService;
            this.resourceRender = resourceRender;
        }


        public ActionResult UploadBinaryResource()
        {
            Resource_BinaryModelBinder b = new Resource_BinaryModelBinder();
            Resource_BinaryInfo result = b.BindModel(this.ControllerContext, null) as Resource_BinaryInfo;
            return null;
        }
        public ActionResult SaveResource()
        {
            throw new NotImplementedException();
        }
        public ActionResult GetResourceHTML(Guid id)
        {
            return Content(resourceRender.Render(id), "text/html");
        }

        public ActionResult GetBinaryResource(Guid id)
        {
            ResourceInfo resource = resourceService.GetById(id);
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
        private IResourceRender resourceRender;
    }
}
