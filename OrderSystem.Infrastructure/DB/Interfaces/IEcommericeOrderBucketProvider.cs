using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Infrastructure.DB.Interfaces
{
    public interface IEcommericeOrderBucketProvider : INamedBucketProvider
    {
    }
}
