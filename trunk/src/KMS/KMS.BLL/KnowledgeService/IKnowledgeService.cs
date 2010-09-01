using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public interface IKnowledgeService
    {
        KnowledgeInfo GetById(int id);
    }
}
