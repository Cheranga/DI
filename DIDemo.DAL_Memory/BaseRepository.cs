using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDemo.Business;
using DIDemo.Infrastructure;

namespace DIDemo.DAL_Memory
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly List<T> collection;

        public BaseRepository(List<T> collection)
        {
            collection = collection ?? new List<T>();
            this.collection = collection;
        }

        public IQueryable<T> GetAll()
        {
            return this.collection.AsQueryable();
        }

        public T GetById(int id)
        {
            return this.collection.FirstOrDefault(x => x.Id == id);
        }

        public void Add(T entity)
        {
            if (entity != null)
            {
                this.collection.Add(entity);
            }
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                var foundIndex = this.collection.FindIndex(x => x.Id == entity.Id);
                if (foundIndex >= 0)
                {
                    this.collection[foundIndex] = entity;
                }
            }
        }

        public void Delete(T entity)
        {
            if (entity != null)
            {
                var item = this.GetById(entity.Id);
                if (item != null)
                {
                    this.collection.Remove(item);
                }
            }
        }

        public void Delete(int id)
        {
            var item = this.GetById(id);
            this.Delete(item);
        }
    }
}
