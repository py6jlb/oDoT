using BusinessLogic;
using BusinessLogic.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.StartupExtensions
{
    public static class ServicesExtension{
        public static IServiceCollection AddServices(this IServiceCollection services){
            services.AddTransient<ICardService, CardService>();
            return services;
        }
    } 
}