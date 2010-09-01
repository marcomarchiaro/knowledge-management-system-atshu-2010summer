using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;
using NHibernate.Linq;

namespace KMS.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        #region IRepository<T> 成员

        public T GetById(object id)
        {
            return session.Get<T>(id);
        }

        public IQuery HqlQuery(string queryString)
        {
            return session.CreateQuery(queryString);
        }

        public IQueryable<T> GetAll()
        {
            return session.Linq<T>();
        }

        public void SaveOnSubmit(T entity)
        {
            session.Save(entity);
        }

        public void UpdateOnSubmit(T entity)
        {
            session.Update(entity);
        }

        public void DeleteOnSubmit(T entity)
        {
            session.Delete(entity);
        }

        public void SubmitChanges()
        {
            session.Flush();
        }

        #endregion

        private ISession session
        {
            get
            {
                return sessionManager.OpenSession();
            }
        }

        private ISessionManager sessionManager;
    }
}
