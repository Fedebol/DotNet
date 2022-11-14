using Microsoft.AspNetCore.Mvc;

namespace FNB.Ecommerce.Service.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {

        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";

            services.AddCors(options => options.AddPolicy(myPolicy, builder => builder.WithOrigins()
                                                                                   .AllowAnyHeader()
                                                                                   .AllowAnyMethod()));
            services.AddMvc();
                                                                                    

            return services;
        }
    }
}
