using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.DAL;

namespace KMS.BLL
{
    public class KnowledgeService : IKnowledgeService
    {
        public KnowledgeService(IRepository<KnowledgeInfo> knowledgeRepository)
        {
            this.knowledgeRepository = knowledgeRepository;
        }

        public KnowledgeInfo GetById(int id)
        {
            return knowledgeRepository.GetById(id);
        }

        private IRepository<KnowledgeInfo> knowledgeRepository;
    }
}
