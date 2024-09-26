using Couchbase.KeyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Infrastructure.Repositries.Interface
{
    public interface IGenericRepositry<TEntity>
    {
        public Task<TEntity?> GetByIdAsync(string id);
        public Task UpsertAsync(TEntity entity, string id);
        public Task DeleteAsync(string id);
    }
}
