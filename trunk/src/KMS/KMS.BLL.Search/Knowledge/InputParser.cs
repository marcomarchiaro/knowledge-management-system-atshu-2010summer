using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL.Search.Knowledge
{
    public static class InputParser
    {
        /// <summary>
        /// 搜索字符串分析工具类
        /// </summary>
        /// <param name="input">整个查询字符串，如 tags:计算机 电脑 dateRange:1992-1-1~2002-2-3。</param>
        /// <param name="tag">标记名，如"tags"。</param>
        /// <returns>返回内容，如"计算机 电脑"</returns>
        public static string ParseContent(string input, string tag)
        {
            int flag = 0;
            int i, j = 0;
            string result = null;
            tag = tag + ':';
            int index = input.IndexOf(tag);

            if (index == -1) return null;

            for (i = index; i < input.Length; i++)
            {
                if (flag == 1)
                {
                    result += input[i];
                }
                else if (flag >= 2)
                {
                    break;
                }
                if (input[i] == ':') flag++;
            }

            if (i != input.Length)
            {
                for (j = result.Length - 1; j >= 0; j--)
                {
                    if (result[j] == ' ') break;
                }

                return result.Remove(j).Trim();
            }
            return result.Trim();
        }
    }
}
