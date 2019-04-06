using AutoMapper;
using Jogador.Application.Service.InputOutput.Player;
using Jogador.Application.Service.Interfaces;
using Jogador.Domain.Interfaces.Service;
using Jogador.Domain.Models;

namespace Jogador.Application.Service.Services
{
    public class PlayerApplicationService : ApplicationServiceBase<Player, PlayerInput, PlayerOutput>, IPlayerApplicationService
    {
        public PlayerApplicationService(IPlayerDomainService domainServiceBase, IMapper mapper) : base(domainServiceBase, mapper)
        {
        }
    }
}
