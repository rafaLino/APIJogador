using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogador.Infra.Data.Context
{
    public class MongoContext : Context
    {
        public MongoContext(IConfiguration config) : base(config.GetConnectionString(nameof(MongoContext)))
        {
        }
    }
}
