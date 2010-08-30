using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.Presentation.Knowledge
{
    public interface IKnowledgeRender
    {
        string RenderKnowledge(KnowledgeInfo knowledge);
    }
}
