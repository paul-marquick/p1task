namespace P1Task.SecclConnector;

public interface ITokenClient
{
    Task<string> GetTokenAsync(string firmId, string id, string password);
}