using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIDemo.Infrastructure;

namespace DIDemo.Business
{
    public class OrderDetail : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }
        
    }
}
