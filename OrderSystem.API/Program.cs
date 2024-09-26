
using Microsoft.Extensions.Hosting.Internal;
using OrderSystem.Infrastructure.Configuration;

namespace OrderSystem.API
{
    public class Program
    {
     
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder=ConfigureServices(builder);
            builder=ConfigureLayersServicesBuilder(builder);

            var app = builder.Build();
            ConfigureLayersServicesApp(app);
            ConfigureMiddleware(app);
            app.Run();
        }

        private static void ConfigureLayersServicesApp(WebApplication app)
        {
            app.AddInfrastructureApp(app.Services.GetRequiredService<IHostApplicationLifetime>());
        }
        private static WebApplicationBuilder ConfigureLayersServicesBuilder(WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructureBuilder(builder.Configuration);
            return builder;
        }


        private static void ConfigureMiddleware(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                // Enable Swagger UI in development mode
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable HTTPS redirection
            app.UseHttpsRedirection();

            // Enable Authorization middleware
            app.UseAuthorization();

            // Map controller routes
            app.MapControllers();
        }

       
        private static WebApplicationBuilder ConfigureServices(WebApplicationBuilder builder)
        {
            // Add controllers
            builder.Services.AddControllers();

            // Configure Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }

    }
}
