﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        void Add (T entity);   
        //void Update (T entity);
        void Delete (T entity);
        void DeleteRange( IEnumerable<T> entities);
        IQueryable<T> Getting(Expression<Func<T, bool>> predicate);
    }
}
