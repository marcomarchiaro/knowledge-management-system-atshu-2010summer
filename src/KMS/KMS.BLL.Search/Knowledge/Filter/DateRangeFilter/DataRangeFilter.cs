using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL.Search
{
    public class DataRangeFilter : IKnowledgeFilter
    {
        public DataRangeFilter()
        {
        }

        public IQueryable<KnowledgeInfo> OnFilter(IQueryable<KnowledgeInfo> range, string input)
        {
            DateTime begin;
            DateTime end;
            if (tryParse(input))
            {
                getDateRange(out begin, out end, input);
                var result = from i in range
                             where i.TimeStamp >= begin && i.TimeStamp <= end
                             select i;
                return result;
            }
            else
                return range;
        }

        private bool tryParse(string input)
        {
            string tagName = ConfigManager.GetValue("DateRangeFilterTag");
            int index = input.IndexOf(tagName);
            if (index < 0)
                return false;
            else
            {
                string temp = input.Substring(index + tagName.Length);
            }
            throw new NotImplementedException();
        }

        private void getDateRange(out DateTime begin, out DateTime end, string input)
        {
            string tagName = ConfigManager.GetValue("DateRangeFilterTag");
            throw new NotImplementedException();
        }

    }
}
