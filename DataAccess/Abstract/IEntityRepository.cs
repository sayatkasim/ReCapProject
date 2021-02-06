﻿using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<Car, bool>> filter = null);
        T GetById(T entity);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
