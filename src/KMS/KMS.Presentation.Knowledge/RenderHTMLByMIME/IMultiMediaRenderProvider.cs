using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Presentation.Knowledge
{
    public interface IMultiMediaRenderProvider
    {
        IMultiMediaRender GetRender(IEnumerable<string> MIME);
    }
}
