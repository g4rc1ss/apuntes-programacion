using Xunit;

namespace NSubstituteLibrary;

public class MockingTest
{
    private readonly IRepositoryToMock _repository;

    public MockingTest()
    {
        _repository = new MockingRepositoryToMock().RepositoryToMock;
    }

    [Fact]
    public async Task MockingDependencyAsync()
    {
        await _repository.GetRepositoryAsync(string.Empty);
        IEnumerable<string>? repositories = await _repository.GetRepositoriesAsync();
        Assert.True(repositories.Count() == 1000);
    }
}
