using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public static class KnowledgeClassRepositoryExtension
    {
        public static KnowledgeClassInfo GetRootClass(this IRepository<KnowledgeClassInfo> knowledgeClassRepository)
        {
            int id = Int32.Parse(ConfigManager.GetValue("RootKnowledgeClassId"));
            return knowledgeClassRepository.GetById(id);
        }
    }
}
