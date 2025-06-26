namespace NSubstituteLibrary;

public interface IRepositoryToMock
{
    Task GetRepositoryAsync(string name);
    Task<IEnumerable<string>> GetRepositoriesAsync();
}
