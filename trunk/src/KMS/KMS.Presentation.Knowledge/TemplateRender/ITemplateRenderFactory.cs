using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public interface ITemplateRenderFactory
    {
        ITemplateRender GetRender(IEnumerable<string> tagNames);
    }
}
