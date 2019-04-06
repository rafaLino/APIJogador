using Jogador.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogador.Domain.Interfaces.Data
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<string> AddAsync(TEntity entity);

        Task DeleteAsync(string id);

        Task UpdateAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(string id);
    }
}
