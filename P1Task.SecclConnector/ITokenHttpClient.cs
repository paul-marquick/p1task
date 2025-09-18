namespace P1Task.SecclConnector;

/// <summary>
/// Makes web requests to Seccl's Token endpoint.
/// </summary>
public interface ITokenHttpClient
{
    /// <summary>
    /// Gets an access token to access the seccl api.
    /// </summary>
    /// <param name="firmId"></param>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<string> GetTokenAsync(string firmId, string id, string password);
}