using System.Collections.Generic;
using DIDemo.Business.Models;

namespace DIDemo.DAL_Memory.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(List<Customer> collection) : base(collection)
        {
        }
    }
}