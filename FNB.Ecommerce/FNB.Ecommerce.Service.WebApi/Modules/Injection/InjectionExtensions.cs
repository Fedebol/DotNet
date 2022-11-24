using FNB.Ecommerce.Application.Interface;
using FNB.Ecommerce.Application.Main;
using FNB.Ecommerce.Domain.Core;
using FNB.Ecommerce.Domain.Interface;
using FNB.Ecommerce.Infrastructure.Data;
using FNB.Ecommerce.Infrastructure.Interface;
using FNB.Ecommerce.Infrastructure.Repository;
using FNB.Ecommerce.Infrastruture.Repository;
using FNB.Ecommerce.Transversal.Common;
using FNB.Ecommerce.Transversal.Logging;

namespace FNB.Ecommerce.Service.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection ( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>();
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
