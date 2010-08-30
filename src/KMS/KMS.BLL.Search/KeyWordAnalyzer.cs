using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.BLL.Search
{
    /// <summary>
    /// 关键词分析器
    /// </summary>
    public class KeyWordAnalyzer : IKeyWordAnalyzer
    {
        /// <summary>
        /// Do分析
        /// </summary>
        /// <param name="input">关键词列表，如：我们的上海很美丽 北京也不错</param>
        /// <returns>处理过的有效的关键词，如：我们 上海 美丽 北京 不错</returns>
        public IEnumerable<string> DoAnalyze(IEnumerable<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
