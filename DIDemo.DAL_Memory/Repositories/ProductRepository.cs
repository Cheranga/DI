using System.Collections.Generic;
using DIDemo.Business.Models;

namespace DIDemo.DAL_Memory.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(List<Product> collection) : base(collection)
        {
        }
    }
}