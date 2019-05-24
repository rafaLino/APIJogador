using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Jogador.Domain.Interfaces.Data;
using Jogador.Domain.Models;
using Jogador.Infra.Data.Context;
using MongoDB.Driver;

namespace Jogador.Infra.Data.Repositories
{
    public class PlayerRepository : RepositoryBase<Player, MongoContext>, IPlayerRepository
    {
        
        public PlayerRepository(MongoContext context) : base(context)
        {
            
        }

        public async Task<Player> GetBy(Expression<Func<Player, bool>> filter)
        {
            var result = await _collection.FindAsync<Player>(filter).ConfigureAwait(false);
            return await result.FirstOrDefaultAsync();
        }
    }
}
