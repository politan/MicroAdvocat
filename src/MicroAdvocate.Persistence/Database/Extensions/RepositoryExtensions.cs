using MicroAdvocate.Persistence.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MicroAdvocate.Persistence.Database.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));

            return serviceCollection;
        }
    }
}