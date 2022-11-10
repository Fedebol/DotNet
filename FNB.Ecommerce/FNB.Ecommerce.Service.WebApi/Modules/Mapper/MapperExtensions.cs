using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FNB.Ecommerce.Transvredal.Mapper;

namespace FNB.Ecommerce.Service.WebApi.Modules.Mapper
{
    public static class MapperExtensions
    {
           public static IServiceCollection AddMapper(this IServiceCollection services)
           {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingsProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                services.AddSingleton(mapper);

                return services;
           }
        

    }
}
