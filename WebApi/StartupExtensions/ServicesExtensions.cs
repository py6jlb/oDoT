using BusinessLogic;
using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace WebApi.StartupExtensions
{
    public static class ServicesExtension{
        public static IServiceCollection AddServices(this IServiceCollection services){
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<ISettingsService, SettingsService>();
            return services;
        }

        public static IServiceCollection SetInitialData(this IServiceCollection services, IConfiguration config){
             
            var serviceProvider = services.BuildServiceProvider();
            var settingsRepo = serviceProvider.GetService<ISettingsService>();
            var currentSettings = settingsRepo.GetSettings();
            
            if(currentSettings == null){
                var dataFromConfig = config.GetSection("DefaultSettings").Get<DefaultSettings>();
                var newSettings = new SettingsDto{
                    DeadlineTimeSpanInMiliseconds = dataFromConfig.DefaultDeadlineTimeSpanInSeconds*1000,
                    PanicTimeSpanInMiliseconds = dataFromConfig.DefaultPanicTimeSpanInSeconds*1000,
                    StartPanicForTimeSpanInMiliseconds = dataFromConfig.DefaultStartPanicForTimeSpanInSeconds*1000
                };
                var s = settingsRepo.AddSettings(newSettings);
            }
            return services;
        }

    } 
}