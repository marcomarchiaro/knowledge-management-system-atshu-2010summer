using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL.Search
{
    public interface ISearchKnowledge
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">For searching contiditions.For example:"tags:x1,x2,x3 dateRange:2007-1-1~2010-2 date:2009-1-1"</param>
        /// <returns></returns>
        IEnumerable<KnowledgeInfo> Search(string input);
    }
}
