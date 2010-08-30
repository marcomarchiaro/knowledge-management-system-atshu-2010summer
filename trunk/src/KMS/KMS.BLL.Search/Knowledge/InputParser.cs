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
            throw new NotImplementedException();
        }
    }
}
