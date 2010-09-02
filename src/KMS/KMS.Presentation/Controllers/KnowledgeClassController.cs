using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KMS.Model;
using KMS.BLL;
using KMS.DAL;
using Castle.Services.Transaction;

namespace KMS.Presentation.Controllers
{
    [Transactional]
    public class KnowledgeClassController : Controller
    {
        public KnowledgeClassController(IRepository<KnowledgeClassInfo> knowledgeClassRepository)
        {
            this.knowledgeClassRepository = knowledgeClassRepository;
        }

        public ActionResult Create(int id)
        {
            ViewData["fatherId"] = id;
            return View();
        }

        [HttpPost]
        [Transaction(TransactionMode.Requires)]
        public virtual ActionResult Create(KnowledgeClassInfo knowledgeClass)
        {
            int fatherId = Int32.Parse(Request.Form["fatherId"]);
            if (ModelState.IsValid)
            {
                KnowledgeClassInfo father = knowledgeClassRepository.GetById(fatherId);
                knowledgeClass.FatherKnowledgeClassInfo = father;
                knowledgeClassRepository.SaveOnSubmit(knowledgeClass);
                ModelState.AddModelError("Success", "操作成功");
            }
            ViewData["fatherId"] = fatherId;
            return View(knowledgeClass);
        }

        [Transaction(TransactionMode.Requires)]
        public virtual ActionResult Delete(int id)
        {
            KnowledgeClassInfo kc = knowledgeClassRepository.GetById(id);
            knowledgeClassRepository.DeleteOnSubmit(kc);
            return View("Back");
        }

        public ActionResult Edit(int id)
        {
            KnowledgeClassInfo kc = knowledgeClassRepository.GetById(id);
            return View(kc);
        }

        [HttpPost]
        public ActionResult Edit(KnowledgeClassInfo knowledgeClass)
        {
            KnowledgeClassInfo kc = knowledgeClassRepository.GetById(knowledgeClass.KnowledgeClassId);
            if (ModelState.IsValid)
            {
                kc.Name = knowledgeClass.Name;
                kc.Description = knowledgeClass.Description;
                knowledgeClassRepository.UpdateOnSubmit(kc);
                ModelState.AddModelError("Success", "操作成功");
                return View(kc);
            }
            return View(knowledgeClass);
        }

        public ActionResult Details(int id)
        {
            KnowledgeClassInfo kc = knowledgeClassRepository.GetById(id);
            return View(kc);
        }

        public ActionResult Index()
        {
            return View();
        }

        private IRepository<KnowledgeClassInfo> knowledgeClassRepository;
    }
}
