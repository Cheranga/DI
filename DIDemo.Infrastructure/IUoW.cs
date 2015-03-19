namespace DIDemo.Infrastructure
{
    public interface IUoW
    {
        bool Commit();
        IRepository<T> GetRepository<T>() where T : class, IEntity;
    }
}