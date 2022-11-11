using Microsoft.Extensions.DependencyInjection;
using FNB.Ecommerce.Application.Validator;

namespace FNB.Ecommerce.Service.WebApi.Modules.Validator
{
    public static class ValidatorExtension
    {
        public static IServiceCollection AddValidator (this IServiceCollection services)
        {
            services.AddTransient<UsersDTOValidator>();
            return services;
        } 
    }
}
