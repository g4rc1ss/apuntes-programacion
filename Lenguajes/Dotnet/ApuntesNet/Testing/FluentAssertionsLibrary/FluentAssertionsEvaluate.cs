using FluentAssertions;
using Xunit;

namespace FluentAssertionsLibrary;

public class FluentAssertionsEvaluate
{
    private readonly IEnumerable<string> _enumerable;

    public FluentAssertionsEvaluate()
    {
        _enumerable = Enumerable.Range(0, 10).Select(x => x.ToString());
    }

    [Fact]
    public void Fluent()
    {
        "".Should().NotBeNull();
        _enumerable.Should().HaveCountGreaterThan(0);
        "Expected".Should().Be("Expected");
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Should().StartWith("AB");

        ""
            .Invoking(x => throw new NotImplementedException("Excepcion lanzada de prueba"))
            .Should()
            .Throw<NotImplementedException>()
            .WithMessage("Excepcion lanzada de prueba");
    }
}
