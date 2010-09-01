using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    /// <summary>
    /// 将模板标记转换为HTML标记
    /// </summary>
    public interface ITemplateRender
    {
        /// <summary>
        /// 支持的模板标记，如KMSResource
        /// </summary>
        IEnumerable<string> SupportedTags { get; }
        /// <summary>
        /// 将模板标记转换为HTML标记
        /// </summary>
        /// <param name="segment">如：<KMSResource id="xxx-xxx-xxx-xxx" width="10" height="20" /></param>
        /// <returns>如：<img src="xxx.com" width="10" height="20" /></returns>
        string Render(string segment);
    }
}
