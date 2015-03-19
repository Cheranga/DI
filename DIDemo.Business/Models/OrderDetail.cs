using DIDemo.Infrastructure;
using DIDemo.Infrastructure.Interfaces;

namespace DIDemo.Business.Models
{
    public class OrderDetail : IEntity
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }
        
    }
}
