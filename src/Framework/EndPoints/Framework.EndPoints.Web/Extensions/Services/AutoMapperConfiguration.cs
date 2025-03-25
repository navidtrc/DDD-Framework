using AutoMapper;

namespace Framework.EndPoints.Web.Extensions.Services;

public interface IHaveCustomMapping
{
    void CreateMappings(Profile profile);
}

public class CustomMappingProfile : Profile
{
    public CustomMappingProfile()
    {

    }
    public CustomMappingProfile(IEnumerable<IHaveCustomMapping> haveCustomMappings)
    {
        foreach (var item in haveCustomMappings)
            item.CreateMappings(this);
    }
}

public static class AutoMapperConfiguration
{
    public static void InitializeAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddAutoMapper(config =>
        {
            config.AddCustomMappingProfile(assemblies);
        }, assemblies);
    }

    public static void AddCustomMappingProfile(this IMapperConfigurationExpression config, params Assembly[] assemblies)
    {
        var allTypes = assemblies.SelectMany(a => a.ExportedTypes);

        var list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
                                          type.GetInterfaces().Contains(typeof(IHaveCustomMapping)))
            .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

        var profile = new CustomMappingProfile(list);

        config.AddProfile(profile);
    }
}