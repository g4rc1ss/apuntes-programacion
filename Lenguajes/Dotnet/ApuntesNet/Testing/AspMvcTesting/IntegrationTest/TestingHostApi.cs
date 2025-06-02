using Xunit;

namespace AspMvcTesting.IntegrationTest;

[Collection("Identificador")]
public class TestingHostApi(TestConfigurationToFixture fixture)
{
    [Fact]
    public async Task WhenGetAllApiWeatherForecastThenReturnValueAsync()
    {
        string? response = await fixture.Client.GetStringAsync("WeatherForecast");

        Assert.NotNull(response);
        Assert.True(response is not null);
    }
}
