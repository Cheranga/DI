using System.Collections.Generic;
using DIDemo.Business;

namespace DIDemo.DAL_Memory
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(List<Product> collection) : base(collection)
        {
        }
    }
}