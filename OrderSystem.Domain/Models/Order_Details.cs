using OrderSystem.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Domain.Models
{
    public class Order_Details
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPrice {  get; set; }

        public IEnumerable<Product> Items { get;}=new List<Product>();
    }
}
