using Couchbase.KeyValue;
using Couchbase;
using OrderSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Extensions.DependencyInjection;
using OrderSystem.Infrastructure.DB.Interfaces;
using OrderSystem.Infrastructure.Enum;
using OrderSystem.Infrastructure.Repositries.Interface;
using OrderSystem.Infrastructure.DB.Classes;

namespace OrderSystem.Infrastructure.Repositries.Classes
{
    public class OrderDetailsRepositry: GenericRepository<Order_Details>,IOrderDetailsRepositry
    {
        public OrderDetailsRepositry(ICouchBaseContext _couchBaseContext) : base(_couchBaseContext,"Order","order_details"){}
    }
}
