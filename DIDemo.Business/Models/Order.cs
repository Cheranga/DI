using System.Collections.Generic;
using DIDemo.Infrastructure;
using DIDemo.Infrastructure.Interfaces;

namespace DIDemo.Business.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
