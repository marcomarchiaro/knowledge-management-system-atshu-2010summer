using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KMS.Presentation.Controllers
{
    public class ResourceController : Controller
    {
        //
        // GET: /Resource/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetResource(string id)
        {
            return Content(id);
        }
    }
}
