using AutoMapper;
using Jogador.Application.Service.InputOutput.Player;
using Jogador.Domain.Models;

namespace Jogador.Application.Service.Mappings
{
    public static class AutoMapperRegister
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Player, PlayerOutput>();
                cfg.CreateMap<PlayerInput, Player>();
                
                
            });
        }
    }
}
