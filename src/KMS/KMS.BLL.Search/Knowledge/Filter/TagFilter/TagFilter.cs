using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL.Search.Knowledge
{
    public class TagFilter : IKnowledgeFilter
    {
        public IQueryable<KnowledgeInfo> OnFilter(IQueryable<KnowledgeInfo> range, string input)
        {
            string tagName = ConfigManager.GetValue("TagsFilterTag");
            string content = InputParser.ParseContent(input, tagName);
            string[] tags = content.Split(seperateChars, StringSplitOptions.RemoveEmptyEntries);
            if (tags.Count() == 0)
                return range;
            else if (tags.Count() == 1 && tags[0].Trim() == "")
                return range;
            else
            {
                IQueryable<KnowledgeInfo> result = null;
                for(int i=0;i<tags.Count();i++)
                {
                    tags[i] = tags[i].Trim();
                    if (result == null)
                        result = getOrResult(range, tags[i]);
                    else
                        result = result.Union(getOrResult(range, tags[i]));
                }
                return result;
            }
            throw new NotImplementedException();
        }

        private IQueryable<KnowledgeInfo> getOrResult(IQueryable<KnowledgeInfo> range, string tag)
        {
            var result = from r in range
                         from kt in r.KnowledgeTagAssociationInfos
                         where kt.TagInfo.Name == tag
                         select r;
            return result;
        }

        private IQueryable<KnowledgeInfo> getAndResult(IQueryable<KnowledgeInfo> range, string[] tags)
        {
            IList<IQueryable<KnowledgeInfo>> results = new List<IQueryable<KnowledgeInfo>>();
            IQueryable<KnowledgeInfo> result = null;
            foreach (var t in tags)
            {
                if (result != null)
                {
                    var result2 = from r in range
                                  from kt in r.KnowledgeTagAssociationInfos
                                  where kt.TagInfo.Name == t
                                  select r;
                    result = result.Intersect(result2);
                }
            }
            return result;
        }

        private readonly char[] seperateChars = new char[] { ',', ' ', ';' };
    }
}
