using AspMvcTesting.Configuration;

namespace AspMvcTesting;

public class TestConfigurationToFixture
{
    private readonly WebApplicationFactoryWeatherForecast _webApplicationFactory;
    public HttpClient Client { get; set; }
    public IServiceProvider ServiceProvider { get; set; }

    public TestConfigurationToFixture()
    {
        _webApplicationFactory = new WebApplicationFactoryWeatherForecast();
        ServiceProvider = _webApplicationFactory.Services;
        Client = _webApplicationFactory.CreateClient();
    }
}
