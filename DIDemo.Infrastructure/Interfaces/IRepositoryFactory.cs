namespace DIDemo.Infrastructure.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepository<T>() where T:class,IEntity;
    }
}