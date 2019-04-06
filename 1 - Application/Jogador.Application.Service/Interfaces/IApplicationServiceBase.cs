using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jogador.Application.Service.Interfaces
{
    public interface IApplicationServiceBase<TInput,TOutput> where TOutput : class where TInput : class
    {

        Task<TOutput> AddAsync(TInput input);

        Task DeleteAsync(string id);

        Task<IEnumerable<TOutput>> GetAsync();

        Task<TOutput> GetAsync(string id);

        Task UpdateAsync(string id, TInput input);
    }
}
