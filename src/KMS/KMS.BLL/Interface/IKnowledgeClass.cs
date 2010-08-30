using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;

namespace KMS.BLL
{
    public interface IKnowledgeClass
    {
        public interface IKnowledgeClass
        {
            KnowledgeClassInfo GetRootClass();
            KnowledgeClassInfo GetClassById(int classId);
            IEnumerable<KnowledgeClassInfo> GetChildClasses(int classId);
            void CreateClassUnderClass(KnowledgeClassInfo knowledgeClass, int fatherClassId);
        }
    }
}
