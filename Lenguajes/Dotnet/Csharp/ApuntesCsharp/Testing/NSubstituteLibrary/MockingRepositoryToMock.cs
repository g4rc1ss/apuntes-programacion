using NSubstitute;

namespace NSubstituteLibrary;

public class MockingRepositoryToMock
{
    public IRepositoryToMock RepositoryToMock { get; set; }

    public MockingRepositoryToMock()
    {
        RepositoryToMock = Substitute.For<IRepositoryToMock>();
        Initialize();
    }

    private void Initialize()
    {
        RepositoryToMock.GetRepositoryAsync(Arg.Any<string>()).Returns(Task.CompletedTask);
        RepositoryToMock
            .GetRepositoriesAsync()
            .Returns(Enumerable.Range(0, 1000).Select(x => $"{x}"));
    }
}
