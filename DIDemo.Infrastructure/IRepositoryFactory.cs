using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace DIDemo.Infrastructure
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T:class,IEntity;
    }
}