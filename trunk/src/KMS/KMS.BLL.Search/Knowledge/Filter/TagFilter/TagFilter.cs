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
            string tag = ConfigManager.GetValue("TagsFilterTag");
            string content = InputParser.ParseContent(input, tag);

            throw new NotImplementedException();
        }

        private readonly char[] seperateChars = new char[] { ',', ' ', ';' };
    }
}
