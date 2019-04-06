using Jogador.Domain.Interfaces.Data;
using Jogador.Domain.Interfaces.Service;
using Jogador.Domain.Models;

namespace Jogador.Domain.Services
{
    public sealed class PlayerDomainService : DomainServiceBase<Player>, IPlayerDomainService
    {
        public PlayerDomainService(IPlayerRepository repository) : base(repository)
        {
        }
    }
}
