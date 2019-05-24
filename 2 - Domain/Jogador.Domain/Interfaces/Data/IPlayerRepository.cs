using Jogador.Domain.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jogador.Domain.Interfaces.Data
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {

        Task<Player> GetBy(Expression<Func<Player, bool>> filter);
    }
}
