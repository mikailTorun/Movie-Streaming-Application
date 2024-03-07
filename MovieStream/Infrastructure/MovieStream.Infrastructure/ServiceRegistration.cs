using Microsoft.Extensions.DependencyInjection;
using MovieStream.Application.Abstruction.Services.Common;
using MovieStream.Infrastructure.Services;

namespace MovieStream.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
