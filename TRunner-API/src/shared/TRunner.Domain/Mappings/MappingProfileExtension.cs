using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace TRunner.Domain.Mappings;

public static class MappingProfileExtension
{
    public static IServiceCollection AddMappingProfile(this IServiceCollection services)
    {
        var mappingProfiles = new Profile[] { new MappingProfile() };
        var mapper = new MapperConfiguration(
                mc =>
                    mc.AddProfiles(mappingProfiles))
            .CreateMapper();

        services.AddSingleton(mapper);

        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        return services;
    }
}
