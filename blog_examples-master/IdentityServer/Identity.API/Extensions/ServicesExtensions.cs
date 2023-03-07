using Identity.API.Models;
using Identity.API.Repositories;
using Identity.API.Services;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices<TConfigurationDbContext>(this IServiceCollection services) 
            where TConfigurationDbContext : DbContext, IConfigurationDbContext
        {
            //Repositories
            services.AddTransient<IClientRepository, ClientRepository<TConfigurationDbContext>>();
            
            //Services
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ILoginService<ApplicationUser>, LoginService>();

            return services;
        }
    }
}
