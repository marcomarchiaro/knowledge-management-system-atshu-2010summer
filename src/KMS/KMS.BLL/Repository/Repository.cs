using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Castle.Facilities.NHibernateIntegration;
using NHibernate.Linq;

namespace KMS.BLL
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
            return Session.Get<T>(id);
        }

        public T LoadById(object id)
        {
            return Session.Load<T>(id);
        }

        public IQuery HqlQuery(string queryString)
        {
            return Session.CreateQuery(queryString);
        }

        public IQueryable<T> GetAll()
        {
            return Session.Linq<T>();
        }

        public void SaveOnSubmit(T entity)
        {
            Session.Save(entity);
        }

        public void UpdateOnSubmit(T entity)
        {
            Session.Update(entity);
        }

        public void DeleteOnSubmit(T entity)
        {
            Session.Delete(entity);
        }

        public void SubmitChanges()
        {
            Session.Flush();
        }

        #endregion

        public ISession Session
        {
            get
            {
                return sessionManager.OpenSession();
            }
        }

        private ISessionManager sessionManager;
    }
}
