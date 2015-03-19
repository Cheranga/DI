using System;
using System.Collections.Generic;
using System.Diagnostics;
using DIDemo.Business.Models;
using DIDemo.DAL_Memory.Repositories;
using DIDemo.Infrastructure;
using DIDemo.Infrastructure.Interfaces;

namespace DIDemo.DAL_Memory.RepositoryFactory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly Dictionary<Type, object> repositoriesMappedByType = null;

        public RepositoryFactory()
        {
            this.repositoriesMappedByType = new Dictionary<Type, object>();
            RegisterDefaultRepositories();

            Debug.WriteLine("RepositoryFactory created...");
        }

        private void RegisterDefaultRepositories()
        {
            RegisterCustomerRepository();
            RegisterProductRepository();
        }

        private void RegisterProductRepository()
        {
            this.repositoriesMappedByType.Add(typeof (Product), new ProductRepository(new List<Product>
            {
                new Product {Id = 1, Name = "Fresh Lite Milk"},
                new Product {Id = 2, Name = "Mixed Salad"},
                new Product {Id = 3, Name = "Vegetable Soup"},
                new Product {Id = 4, Name = "Coffee"}
            }));
        }

        private void RegisterCustomerRepository()
        {

            this.repositoriesMappedByType.Add(typeof (Customer), new CustomerRepository(new List<Customer>
            {
                new Customer {Id = 1, Name = "Cheranga Hatangala"},
                new Customer {Id = 2, Name = "Randika Jayasekara"},
                new Customer {Id = 3, Name = "Nadun Rathnayake"},
                new Customer {Id = 4, Name = "Ivy Lee"}
            }));
        }

        public void RegisterRepository<T>(IRepository<T> repository, bool replaceIfExist = false) where T : class, IEntity
        {
            var type = typeof(T);
            var typeExists = this.repositoriesMappedByType.ContainsKey(type);

            if (typeExists)
            {
                if (replaceIfExist)
                {
                    this.repositoriesMappedByType[type] = repository;
                }
            }
            else
            {
                this.repositoriesMappedByType.Add(type, repository);
            }
        }

        public IRepository<T> GetRepository<T>() where T : class, IEntity
        {
            object repo = null;

            if (this.repositoriesMappedByType.TryGetValue(typeof(T), out repo))
            {
                return (IRepository<T>)(repo);
            }

            return null;
        }
    }


}
