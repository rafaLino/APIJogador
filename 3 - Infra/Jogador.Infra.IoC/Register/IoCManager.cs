using Jogador.Application.Service.Interfaces;
using Jogador.Application.Service.Services;
using Jogador.Domain.Interfaces.Data;
using Jogador.Domain.Interfaces.Service;
using Jogador.Domain.Services;
using Jogador.Infra.Data.Context;
using Jogador.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jogador.Infra.IoC.Register
{
    public static class IoCManager
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPlayerRepository, PlayerRepository>();

            services.AddScoped<IPlayerDomainService, PlayerDomainService>();

            services.AddScoped<IPlayerApplicationService, PlayerApplicationService>();

            services.AddScoped<MongoContext>();
            
        } 
    }
}
