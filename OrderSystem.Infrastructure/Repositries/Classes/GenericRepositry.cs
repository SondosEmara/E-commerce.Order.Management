using Couchbase;
using Couchbase.Core.Exceptions.KeyValue;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using OrderSystem.Domain.Models;
using OrderSystem.Infrastructure.DB;
using OrderSystem.Infrastructure.DB.Interfaces;
using OrderSystem.Infrastructure.Enum;
using OrderSystem.Infrastructure.Repositries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Infrastructure.Repositries.Classes
{
    public class GenericRepository<TEntity>: IGenericRepositry<TEntity>
    {
        
        private readonly ICouchBaseContext _couchBaseContext;
        protected string _scopeName { get; set; }=String.Empty;
        protected string _collectionName { get; set; } = String.Empty;

        public GenericRepository(ICouchBaseContext couchBaseContext,String scopeName,String collectionName )
        {
            _couchBaseContext = couchBaseContext;
            _scopeName= scopeName;
            _collectionName=collectionName;
        }

        public async Task<bool> CreateAsync(string key, TEntity newDocument)
        {
            var couchbaseCollection = await _couchBaseContext.GetCollectionAsync(_scopeName,_collectionName);

            if (newDocument == null) return false;
            try
            {
                var result = await couchbaseCollection.InsertAsync(key, newDocument);
                return true;
            }
            catch (CouchbaseException) 
            {
                return false;
            }

        }                                                    

        public async Task<TEntity?> GetByIdAsync(string key)
        {
            var couchbaseCollection = await _couchBaseContext.GetCollectionAsync(_scopeName, _collectionName);
            try
            {
                var result = await couchbaseCollection.TryGetAsync(key);
                if (!result.Exists) return result.ContentAs<TEntity>();
                return default(TEntity);            
            }
            catch (CouchbaseException) { return default(TEntity); }
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task UpsertAsync(TEntity entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
