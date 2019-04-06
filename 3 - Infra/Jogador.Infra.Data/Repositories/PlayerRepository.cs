using Jogador.Domain.Interfaces.Data;
using Jogador.Domain.Models;
using Jogador.Infra.Data.Context;

namespace Jogador.Infra.Data.Repositories
{
    public class PlayerRepository : RepositoryBase<Player, MongoContext>, IPlayerRepository
    {
        
        public PlayerRepository(MongoContext context) : base(context)
        {
            
        }
        
    }
}
