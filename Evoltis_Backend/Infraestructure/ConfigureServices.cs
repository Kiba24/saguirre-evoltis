
using Amazon.Util.Internal;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Infraestructure.Persistance.Repositories;
using Infraestructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraestrucutreServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IFile, FileRetriever>();
            return services;
        }
    }
}
