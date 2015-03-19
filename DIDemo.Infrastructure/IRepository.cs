using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo.Infrastructure
{
    public interface IRepository<T> where T:class, IEntity 
    {
        IQueryable<T> GetAll();
        T GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
