
using JoolServerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace JoolServerApp.Repo
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly JoolServerEntities context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(JoolServerEntities context)
        {
            this.context = context;
            Debug.WriteLine(context);
            entities = context.Set<T>();
            Debug.WriteLine(entities);
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(long id)
        {
            return entities.Find(id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}