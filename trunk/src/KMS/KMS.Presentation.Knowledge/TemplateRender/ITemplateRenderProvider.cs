using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public interface ITemplateRenderProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagName">给定标记名列表，如KMSResource</param>
        /// <returns></returns>
        ITemplateRender GetRender(IEnumerable<string> tagNames);
    }
}
