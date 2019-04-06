using Jogador.Domain.Core.Models;
using Jogador.Domain.Interfaces.Data;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogador.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity : Entity where TContext : Context.Context
    {
        protected readonly IMongoCollection<TEntity> _collection;
        protected readonly IMongoDatabase database;
        protected RepositoryBase(TContext context)
        {
            database = context.Database;
            _collection = database.GetCollection<TEntity>(nameof(TEntity));
        }
        public async Task<string> AddAsync(TEntity entity)
        {

            await _collection.InsertOneAsync(entity).ConfigureAwait(false);

            return entity.Id;
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync<TEntity>(x => x.Id == id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            var result = await _collection.FindAsync<TEntity>(x => true).ConfigureAwait(false);
            return await result.ToListAsync();
        }

        public async Task<TEntity> GetAsync(string id)
        {
            var result = await _collection.FindAsync(x => x.Id == id).ConfigureAwait(false);
            return await result.FirstOrDefaultAsync<TEntity>();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _collection.ReplaceOneAsync<TEntity>(x => x.Id == entity.Id, entity).ConfigureAwait(false);
        }
    }
}
