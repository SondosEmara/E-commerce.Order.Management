using Couchbase.Extensions.DependencyInjection;
using Google.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.Models;
using OrderSystem.Infrastructure.DB.Classes;
using OrderSystem.Infrastructure.DB.Interfaces;
using OrderSystem.Infrastructure.Repositries.Classes;
using OrderSystem.Infrastructure.Repositries.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Infrastructure.Configuration
{
    public static class InfrastructureExtensions
    {
      
        public static IServiceCollection AddInfrastructureBuilder(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            #region CouchBase
            services.AddCouchbase(configuration.GetSection("CouchBase"))
                    .AddCouchbaseBucket<IEcommericeOrderBucketProvider>("e-commerce-order-system");


            services.AddScoped<ICouchBaseContext, CouchBaseContext>()
                    .AddScoped<IOrderDetailsRepositry, OrderDetailsRepositry>();


            return services;
            #endregion
        }

        public static void AddInfrastructureApp(this IApplicationBuilder app, IHostApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                app.ApplicationServices.GetRequiredService<ICouchbaseLifetimeService>();
            });
        }
    }
}
