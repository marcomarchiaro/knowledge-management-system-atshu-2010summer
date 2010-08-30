using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public class KnowledgeClassRepository : Repository<KnowledgeClassInfo>
    {
        public KnowledgeClassInfo GetRootClass()
        {
            int id = Int32.Parse(ConfigManager.GetValue("RootKnowledgeClassId"));
            return GetById(id);
        }
    }
}
