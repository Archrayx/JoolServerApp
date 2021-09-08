﻿using JoolServerApp.Data;
using System.Collections.Generic;

namespace JoolServerApp.Repo
{
    public interface IRepository<T> where T : JoolServerEntities
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}