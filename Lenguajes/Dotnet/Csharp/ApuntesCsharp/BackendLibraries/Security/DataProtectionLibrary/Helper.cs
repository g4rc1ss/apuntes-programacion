using DataProtectionLibrary.Protections;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace DataProtectionLibrary;

internal class Helper
{
    public static IServiceProvider GetServiceProvider()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddTransient<DataProtectionExample>();

        services
            .AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"keysDataProtection"))
            .SetDefaultKeyLifetime(TimeSpan.FromDays(7));

        return services.BuildServiceProvider();
    }
}
