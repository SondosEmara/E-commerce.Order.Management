using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Infrastructure.Configuration
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureDependendies(this IServiceCollection services, IConfiguration configuration)
        {
            //CouchBase


        }
    }
}
