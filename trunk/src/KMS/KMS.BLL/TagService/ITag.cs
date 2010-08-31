using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public interface ITag
    {
        TagInfo GetTagById(int id);
        void CreateTag(TagInfo tag);
        IEnumerable<ResourceInfo> SearchResourceByTagName(params string[] tagNames);
        IEnumerable<KnowledgeInfo> SearchKnowledgeByTagName(params string[] tagNames);
    }
}
