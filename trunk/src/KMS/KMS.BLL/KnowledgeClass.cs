using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KMS.Model;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;

namespace KMS.BLL
{
    public class KnowledgeClass : IKnowledgeClass
    {
        public KnowledgeClass(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public KnowledgeClassInfo GetKnowledgeClassById(int id)
        {
            return sessionManager.OpenSession().Get<KnowledgeClassInfo>(id);
        }

        public void CreateClassUnderClass(KnowledgeClassInfo knowledgeClass, int fatherClassId)
        {
            ISession session = sessionManager.OpenSession();
            KnowledgeClassInfo father = session.Load<KnowledgeClassInfo>(fatherClassId);
            knowledgeClass.FatherKnowledgeClassInfo = father;
            session.Save(knowledgeClass);
        }

        public KnowledgeClassInfo GetClassById(int classId)
        {
            ISession session = sessionManager.OpenSession();
            return session.Get<KnowledgeClassInfo>(classId);
        }

        public IEnumerable<KnowledgeClassInfo> GetChildClasses(int classId)
        {
            ISession session = sessionManager.OpenSession();
            KnowledgeClassInfo knowledgeClass = session.Get<KnowledgeClassInfo>(classId);
            return knowledgeClass.KnowledgeClassInfos;
        }

        private ISessionManager sessionManager;

        public KnowledgeClassInfo GetRootClass()
        {
            ISession session = sessionManager.OpenSession();
            return session.Get<KnowledgeClassInfo>(1);
        }
    }
}
