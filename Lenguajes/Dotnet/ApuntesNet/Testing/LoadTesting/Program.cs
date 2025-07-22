using NBomber.Contracts;
using NBomber.CSharp;

using HttpClient httpClient = new();
ScenarioProps? scenario = Scenario
    .Create(
        "http_scenario",
        async context =>
        {
            await httpClient.GetAsync("https://nbomber.com");

            return Response.Ok();
        }
    )
    .WithLoadSimulations(
        Simulation.Inject(
            rate: 100,
            interval: TimeSpan.FromSeconds(1),
            during: TimeSpan.FromSeconds(10)
        )
    );

NBomberRunner.RegisterScenarios(scenario).Run();
