using Microsoft.Extensions.DependencyInjection;

namespace AutomapperLibrary;

public class Helper
{
    public static IServiceProvider GetServiceProvider()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<AutoMappingClasses>();
        services.AddAutoMapper(typeof(Program));

        return services.BuildServiceProvider();
    }
}
