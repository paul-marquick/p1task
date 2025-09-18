namespace P1Task.SecclConnector;

public interface ITokenHttpClient
{
    Task<string> GetTokenAsync(string firmId, string id, string password);
}