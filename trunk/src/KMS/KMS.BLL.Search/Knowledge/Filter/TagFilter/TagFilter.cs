using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.BLL.Search;

namespace KMS.BLL.Search.Knowledge
{
    public class TagFilter : IKnowledgeFilter
    {
        public TagFilter(IInputParser inputParser, IKeyWordAnalyzer keyWordAnalyzer)
        {
            this.inputParser = inputParser;
            this.keyWordAnalyzer = keyWordAnalyzer;
        }

        public IQueryable<KnowledgeInfo> OnFilter(IQueryable<KnowledgeInfo> range, string input)
        {
            string tagName = ConfigManager.GetValue("TagFilterTag");
            string content = inputParser.GetContent(input, tagName);
            if (content == null)
                return range;
            string[] roughTags = content.Split(seperateChars, StringSplitOptions.RemoveEmptyEntries);
            IEnumerable<string> tags = keyWordAnalyzer.DoAnalyze(roughTags);
            
            if (tags.Count() == 0)
                return range;
            else if (tags.Count() == 1 && tags.First().Trim() == "")
                return range;
            else
            {
                //IQueryable<KnowledgeInfo> result = getAndResult(range, tags);
                //return result;

                IQueryable<KnowledgeInfo> result = null;
                foreach(var t in tags)
                {
                    string t2 = t.Trim();
                    if (result == null)
                        result = getOrResult(range, t2);
                    else
                        result = result.Union(getOrResult(range, t2));
                }
                return result;
            }
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
                var result2 = from r in range
                              from kt in r.KnowledgeTagAssociationInfos
                              where kt.TagInfo.Name == t
                              select r;
                if (result == null)
                    result = result2;
                else
                    result = result.Intersect(result2);
            }
            return result;
        }

        private readonly char[] seperateChars = new char[] { ',', ' ', ';' };

        private IInputParser inputParser;
        private IKeyWordAnalyzer keyWordAnalyzer;
    }
}
