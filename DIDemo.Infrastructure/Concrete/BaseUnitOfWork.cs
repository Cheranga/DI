using System;
using System.Diagnostics;
using System.Linq;
using DIDemo.Infrastructure.Interfaces;

namespace DIDemo.Infrastructure.Concrete
{
    public class BaseUnitOfWork : IUoW
    {
        #region Fields

        private readonly IRepositoryFactory repositoryFactory;

        #endregion

        #region Constructor

        public BaseUnitOfWork(IRepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;

            ValidateRepositoryFactory();

            Debug.WriteLine("Base UoW created...");
        }

        #endregion

        #region IUoW Implementation

        public bool Commit()
        {
            return true;
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            ValidateRepositoryFactory();

            var repository = this.repositoryFactory.GetRepository<T>();
            return repository;
        }

        #endregion

        #region Virtual Members

        public virtual IQueryable<T> GetAll<T>() where T : class,IEntity
        {
            ValidateRepositoryFactory();

            var repository = this.GetOrThrowRepository<T>();

            return repository.GetAll();
        }

        public virtual T GetById<T>(int id) where T : class, IEntity
        {
            ValidateRepositoryFactory();

            var repository = this.GetOrThrowRepository<T>();

            return repository.GetById(id);
        }


        public virtual IQueryable<T> GetAll<T>(Func<T, bool> expression) where T : class,IEntity
        {
            ValidateRepositoryFactory();

            var repository = this.GetOrThrowRepository<T>();

            return repository.GetAll().Where(expression).AsQueryable();
        }

        public virtual void Add<T>(T entity) where T : class ,IEntity
        {
            ValidateRepositoryFactory();

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var repository = this.GetOrThrowRepository<T>();
            repository.Add(entity);
        }

        public virtual void Update<T>(T entity) where T : class ,IEntity
        {
            ValidateRepositoryFactory();

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var repository = this.GetOrThrowRepository<T>();
            repository.Update(entity);
        }

        public virtual void Delete<T>(T entity) where T : class ,IEntity
        {
            ValidateRepositoryFactory();

            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var repository = this.GetOrThrowRepository<T>();
            repository.Delete(entity);
        }

        public virtual void Delete<T>(int id) where T : class ,IEntity
        {
            ValidateRepositoryFactory();


            var repository = this.GetOrThrowRepository<T>();
            var item = repository.GetById(id);
            this.Delete(item);
        }

        public virtual void Delete<T>(Func<T, bool> expression) where T : class ,IEntity
        {
            ValidateRepositoryFactory();

            var repository = this.GetOrThrowRepository<T>();
            var itemsToRemove = repository.GetAll().Where(expression);

            itemsToRemove.ToList().ForEach(this.Delete);
        }

        #endregion

        #region Private Helpers

        private void ValidateRepositoryFactory()
        {
            if (this.repositoryFactory == null)
            {
                throw new ArgumentNullException("repository factory cannot be null");
            }
        }

        private IRepository<T> GetOrThrowRepository<T>() where T : class ,IEntity
        {
            var repository = this.GetRepository<T>();
            if (repository == null)
            {
                throw new ArgumentNullException("There are no repositories registered for the requested type");
            }

            return repository;
        }

        #endregion
    }
}
