using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL.Search.Knowledge
{
    public interface ITagFilter
    {
        IQueryable<KnowledgeInfo> OnTags(IQueryable<KnowledgeInfo> input,IEnumerable<string> tags);
    }
}
