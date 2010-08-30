using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KMS.Model;

namespace KMS.BLL.Search.Knowledge
{
    public class DataRangeFilter : IKnowledgeFilter
    {
        public DataRangeFilter()
        {
        }

        /// <summary>
        /// 日期范围过滤器
        /// </summary>
        /// <param name="range"></param>
        /// <param name="input">dateRange:1989-6-22~2000-2-3</param>
        /// <returns></returns>
        public IQueryable<KnowledgeInfo> OnFilter(IQueryable<KnowledgeInfo> range, string input)
        {
            string tagName = ConfigManager.GetValue("DateRangeFilterTag");
            string content = InputParser.ParseContent(input, tagName);
            if (content == null)
                return range;
            else
            {
                string[] temp = content.Split('~');
                if (temp.Length != 2)
                    return range;
                else
                {
                    foreach (var p in temp)
                    {
                        
                    }
                }
            }
        }

        private readonly string dateRegular = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$ ";

        //private bool tryParse(string input)
        //{
        //    string tagName = ConfigManager.GetValue("DateRangeFilterTag");
        //    int index = input.IndexOf(tagName);
        //    if (index < 0)
        //        return false;
        //    else
        //    {
        //        string temp = input.Substring(index + tagName.Length);
        //    }
        //    throw new NotImplementedException();
        //}

        //private void getDateRange(out DateTime begin, out DateTime end, string input)
        //{
        //    string tagName = ConfigManager.GetValue("DateRangeFilterTag");
        //    throw new NotImplementedException();
        //}

    }
}
