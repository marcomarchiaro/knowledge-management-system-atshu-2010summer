using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL.Search.Knowledge
{
    public interface IDateRangeFilter
    {
        IQueryable<KnowledgeInfo> OnDataRange(IQueryable<KnowledgeInfo> input, DateTime begin, DateTime end);
    }
}
