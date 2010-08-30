using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL.Search.Knowledge
{
    public interface IKnowledgeFilter
    {
        IQueryable<KnowledgeInfo> OnFilter(IQueryable<KnowledgeInfo> range, string input);
    }
}
