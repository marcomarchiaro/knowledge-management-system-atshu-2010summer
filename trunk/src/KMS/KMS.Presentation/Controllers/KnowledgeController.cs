using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KMS.Common;
using KMS.Model;

namespace KMS.Presentation.Controllers
{
    public class KnowledgeController : Controller
    {
        //
        // GET: /Knowledge/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KnowledgeInfo knowledge)
        {
            return View();
        }
    }
}
