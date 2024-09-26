using Couchbase;
using Couchbase.KeyValue;
using OrderSystem.Infrastructure.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Infrastructure.DB.Interfaces
{
    public interface ICouchBaseContext
    {
        public Task<IBucket> GetBucketAsync();
        public Task<IScope> GetScopeAsync(string _scopeName);

        public Task<ICouchbaseCollection> GetCollectionAsync(string _scope, string _collectioName);
    }

}
