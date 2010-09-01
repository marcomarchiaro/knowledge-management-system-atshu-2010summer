using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using KMS.Model;
using KMS.Common;

namespace KMS.BLL.Search.Knowledge
{
    public class DateRangeFilter : IKnowledgeFilter
    {
        public DateRangeFilter(IInputParser inputParser)
        {
            this.inputParser = inputParser;
        }

        /// <summary>
        /// 日期范围过滤器
        /// </summary>
        /// <param name="range"></param>
        /// <param name="input">dateRange:1989-6-22~2000-2-3</param>
        /// <returns></returns>
        public IEnumerable<KnowledgeInfo> OnFilter(IEnumerable<KnowledgeInfo> range, string input)
        {
            string tagName = ConfigManager.GetValue("DateRangeFilterTag");
            string content = inputParser.GetContent(input, tagName);
            if (content == null)
                return range;
            else
            {
                string[] temp = content.Split('~');
                if (temp.Length != 2)
                    return range;
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        temp[i] = temp[i].Trim();
                        if (!Regex.IsMatch(temp[i], dateRegular))
                            return range;
                    }
                    DateTime[] dateRange = new DateTime[2];
                    for (int i = 0; i < 2; i++)
                    {
                        string[] date = temp[i].Split('-');
                        int year = Int32.Parse(date[0]);
                        int month = Int32.Parse(date[1]);
                        int day = Int32.Parse(date[2]);
                        dateRange[i] = new DateTime(year, month, day);
                    }
                    if (dateRange[0].CompareTo(dateRange[1]) > 0)
                        return range;
                    else
                    {
                        var result = from r in range
                                     where r.TimeStamp >= dateRange[0] && r.TimeStamp <= dateRange[1]
                                     select r;
                        return result;
                    }
                }
            }
        }

        private readonly string dateRegular = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";

        private IInputParser inputParser;
    }
}
