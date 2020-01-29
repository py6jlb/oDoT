using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Hubs;
using WebApi.StartupExtensions;

namespace WebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddLiteDb(connectionString);
            services.AddRepositories();
            services.AddServices();
            services.SetInitialData(Configuration);
            services.AddCors(c =>
            {
                c.AddPolicy("default", policy =>
                        {
                            var urls = Configuration.GetSection("CorsUrls").Get<string[]>();
                            policy.WithOrigins(urls)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "oDoT API" });
                //c.ResolveConflictingActions(apiDEscr=> apiDEscr.First());
            });
            services.AddControllers();
            services.AddSignalR();
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(); 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "oDoT API");
                c.RoutePrefix = string.Empty;
            }); 
            app.UseCors("default");
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
                endpoints.MapHub<ToDoHub>("/todos");
            });
        }
    }
}
