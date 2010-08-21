using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public interface IKnowledgeClass
    {
        KnowledgeClassInfo GetClassById(int classId);
        IEnumerable<KnowledgeClassInfo> GetChildClasses(int classId);
        void CreateClassUnderClass(KnowledgeClassInfo clazz, int classId);
    }
}
