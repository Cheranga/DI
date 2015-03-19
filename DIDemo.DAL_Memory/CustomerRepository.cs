using System.Collections.Generic;
using DIDemo.Business;

namespace DIDemo.DAL_Memory
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(List<Customer> collection) : base(collection)
        {
        }
    }
}