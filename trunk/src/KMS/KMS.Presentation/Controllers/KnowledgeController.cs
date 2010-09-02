using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KMS.Common;
using KMS.Model;
using KMS.DAL;
using KMS.BLL;

namespace KMS.Presentation.Controllers
{
    public class KnowledgeController : Controller
    {
        public KnowledgeController(IRepository<KnowledgeInfo> knowledgeRepository, IKnowledgeService knowledgeService)
        {
            this.knowledgeService = knowledgeService;
            this.knowledgeRepository = knowledgeRepository;
        }
        //
        // GET: /Knowledge/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            ViewData["knowledgeClassId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(KnowledgeInfo knowledge)
        {
            string tags = Request.Form["tags"];
            ViewData["tags"] = tags;
            int knowledgeClassId = Int32.Parse(Request.Form["knowledgeClassId"]);
            ViewData["knowledgeClassId"] = knowledgeClassId;
            if (ModelState.IsValid)
            {
                knowledgeService.CreateKnowledge(knowledge, knowledgeClassId, tags.Split(' '));
                ModelState.AddModelError("success", "操作成功");
            }
            return View(knowledge);
        }

        private IRepository<KnowledgeInfo> knowledgeRepository;
        private IKnowledgeService knowledgeService;
    }
}
