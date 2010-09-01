using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using KMS.BLL.Search;
using KMS.Common;

namespace KMS.BLL.Search.Knowledge
{
    public class TagFilter : IKnowledgeFilter
    {
        public TagFilter(IInputParser inputParser, IKeyWordAnalyzer keyWordAnalyzer)
        {
            this.inputParser = inputParser;
            this.keyWordAnalyzer = keyWordAnalyzer;
        }

        public IEnumerable<KnowledgeInfo> OnFilter(IEnumerable<KnowledgeInfo> range, string input)
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
                return getUnionResult(range, tags);
            }
        }

        private IEnumerable<KnowledgeInfo> getUnionResult(IEnumerable<KnowledgeInfo> range, IEnumerable<string> tags)
        {
            IEnumerable<KnowledgeInfo> result = new List<KnowledgeInfo>();
            foreach (var t in tags)
            {
                
                var result2 = from r in range
                            from kt in r.KnowledgeTagAssociationInfos
                            where kt.TagInfo.Name == t
                            select r;
                result = this.union(result, result2);
            }
            return result;
        }

        private IEnumerable<KnowledgeInfo> union(IEnumerable<KnowledgeInfo> set1, IEnumerable<KnowledgeInfo> set2)
        {
            IList<KnowledgeInfo> list = set1.ToList();
            foreach (var p in set2)
            {
                if (!list.Contains(p))
                    list.Add(p);
            }
            return list;
        }

        private readonly char[] seperateChars = new char[] { ',', ' ', ';' };

        private IInputParser inputParser;
        private IKeyWordAnalyzer keyWordAnalyzer;
    }
}
