using DataAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.StartupExtensions{

    public static class RepositoriesExtensions{
        public static IServiceCollection AddLiteDb(this IServiceCollection services, string databasePath)
        {
            services.AddTransient<LiteDbContext>(sp => new LiteDbContext(databasePath));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<ICardCommentRepository, CardCommentRepository>();
            services.AddTransient<ICardContentRepository, CardContentRepository>();
            return services;
        }
    }

}