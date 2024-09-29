using Couchbase;
using Couchbase.KeyValue;
using OrderSystem.Infrastructure.DB.Interfaces;

namespace OrderSystem.Infrastructure.DB.Classes
{
    public class CouchBaseContext : ICouchBaseContext
    {
        private readonly IEcommericeOrderBucketProvider _couchbaseBucketProvider;

        public CouchBaseContext(IEcommericeOrderBucketProvider couchBaseProvider)
        {
            _couchbaseBucketProvider = couchBaseProvider;
        }

        public async Task<IBucket> GetBucketAsync()
        {
            return await _couchbaseBucketProvider.GetBucketAsync();
        }
        public async Task<IScope> GetScopeAsync(string _scopeName)
        {
            var bucket = await GetBucketAsync();
            return await bucket.ScopeAsync(_scopeName);
        }

        public async Task<ICouchbaseCollection> GetCollectionAsync(string _scope, string _collectioName)
        {
            var scopeObj = await GetScopeAsync(_scope);
            return await scopeObj.CollectionAsync(_collectioName);
        }
    }
}
