using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;

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
            services.AddTransient<ISettingsRepository, SettingsRepository>();
            return services;
        }

        public static IServiceCollection SetInitialData(this IServiceCollection services, IConfiguration config){
             
            var serviceProvider = services.BuildServiceProvider();
            var settingsRepo = serviceProvider.GetService<ISettingsRepository>();
            var currentSettings = settingsRepo.GetSettings();
            
            if(currentSettings == null){
                var dataFromConfig = config.GetSection("DefaultSettings").Get<DefaultSettings>();
                var newSettings = new Settings{
                    DeadlineTimeSpanInMiliseconds = dataFromConfig.DefaultDeadlineTimeSpanInSeconds*1000,
                    DoNotDisturbTimeSpanInMiliseconds = dataFromConfig.DefaultDoNotDisturbTimeSpanInSeconds*1000,
                    PanicTimeSpanInMiliseconds = dataFromConfig.DefaultPanicTimeSpanInSeconds*1000,
                    StartPanicForTimeSpanInMiliseconds = dataFromConfig.DefaultStartPanicForTimeSpanInSeconds*1000
                };

                var s = settingsRepo.AddSettings(newSettings);
            }
            return services;
        }
    }

}