﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Services.Transaction;
using KMS.Common;
using KMS.Model;
using KMS.DAL;
using KMS.BLL;
using KMS.BLL.Search.Knowledge;

namespace KMS.Presentation.Controllers
{
    [Transactional]
    public class KnowledgeController : Controller
    {
        public KnowledgeController(
            IRepository<KnowledgeInfo> knowledgeRepository, 
            IKnowledgeService knowledgeService,
            ISearchKnowledge searchKnowledge)
        {
            this.knowledgeService = knowledgeService;
            this.knowledgeRepository = knowledgeRepository;
            this.searchKnowledge = searchKnowledge;
        }

        [Transaction(TransactionMode.Requires)]
        public virtual ActionResult Delete(int id)
        {
            KnowledgeInfo knowledge = knowledgeRepository.GetById(id);
            knowledgeRepository.DeleteOnSubmit(knowledge);
            return View("Back");
        }

        public ActionResult Details(int id)
        {
            KnowledgeInfo knowledge = knowledgeRepository.GetById(id);
            return View(knowledge);
        }

        public ActionResult Create(int id)
        {
            ViewData["knowledgeClassId"] = id;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [Transaction(TransactionMode.Requires)]
        public virtual ActionResult Create(KnowledgeInfo knowledge)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">means tagName</param>
        /// <returns></returns>
        public ActionResult SearchByTag(string id)
        {
            string input = string.Format("tags:{0}", id);
            return doSearch(input);
        }

        public ActionResult Result(FormCollection form)
        {
            string input = form["condition"];
            return doSearch(input);
        }

        private ActionResult doSearch(string input)
        {
            ViewData["input"] = input;
            IEnumerable<KnowledgeInfo> knowledgeList = searchKnowledge.Search(input);
            return View("Result", knowledgeList);
        }

        public ActionResult Search()
        {
            return View();
        }

        private IRepository<KnowledgeInfo> knowledgeRepository;
        private IKnowledgeService knowledgeService;
        private ISearchKnowledge searchKnowledge;
    }
}
