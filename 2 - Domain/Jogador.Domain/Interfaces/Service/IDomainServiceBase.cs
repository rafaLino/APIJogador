using Jogador.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogador.Domain.Interfaces.Service
{
    public interface IDomainServiceBase<TEntity> where TEntity : Entity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(string id,TEntity entity);

        Task DeleteAsync(string id);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(string id);
    }
}
