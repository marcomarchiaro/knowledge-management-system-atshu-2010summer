﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.DAL;

namespace KMS.BLL.Search.Knowledge
{
    public class SearchKnowledge : ISearchKnowledge
    {
        public SearchKnowledge(IRepository<KnowledgeInfo> knowledgeRepository)
        {
            this.knowledgeRepository = knowledgeRepository;

            filterList.Add(new DateRangeFilter(new InputParser()));
            filterList.Add(new TagFilter(new InputParser(), new KeyWordAnalyzer()));
        }

        public IList<IKnowledgeFilter> filterList = new List<IKnowledgeFilter>();

        public IEnumerable<KnowledgeInfo> Search(string input)
        {
            IEnumerable<KnowledgeInfo> result = knowledgeRepository.GetAll();
            foreach (var p in filterList)
            {
                result = p.OnFilter(result, input);
            }
            return result;
        }

        private IRepository<KnowledgeInfo> knowledgeRepository;
    }
}
