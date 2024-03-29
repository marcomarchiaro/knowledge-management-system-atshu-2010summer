﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace KMS.DAL
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        IQuery HqlQuery(string queryString);
        IQueryable<T> GetAll();
        void SaveOnSubmit(T entity);
        void UpdateOnSubmit(T entity);
        void DeleteOnSubmit(T entity);
        void SubmitChanges();
    }

    public interface IRepository
    {
        object GetById(object id);
        IQuery HqlQuery(string queryString);
        void SaveOnSubmit(object entity);
        void UpdateOnSubmit(object entity);
        void DeleteOnSubmit(object entity);
        void SubmitChanges();
    }
}
