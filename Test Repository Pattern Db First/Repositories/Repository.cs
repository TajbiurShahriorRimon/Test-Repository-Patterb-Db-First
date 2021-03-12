using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Test_Repository_Pattern_Db_First.Models;

namespace Test_Repository_Pattern_Db_First.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected InventoryDbEntities context = new InventoryDbEntities();

        public void Delete(int id)
        {
            TEntity element = this.Get(id);
            context.Set<TEntity>().Remove(element);

            context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            TEntity element = context.Set<TEntity>().Find(id);
            return element;
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> list = context.Set<TEntity>().ToList();
            return list;
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}