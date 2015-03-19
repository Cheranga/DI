using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDemo.Infrastructure;

namespace DIDemo.Business
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
