using AspMvcTesting.Configuration;

namespace AspMvcTesting;

public class TestConfigurationToFixture
{
    public HttpClient Client { get; set; }
    public IServiceProvider ServiceProvider { get; set; }

    public TestConfigurationToFixture()
    {
        WebApplicationFactoryWeatherForecast? webHost = new();
        ServiceProvider = webHost.Services;
        Client = webHost.CreateClient();
    }
}
