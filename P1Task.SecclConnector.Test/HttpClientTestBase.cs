namespace P1Task.SecclConnector.Test;

public abstract class HttpClientTestBase
{
    // Need to replace these with valid credentials for the tests to work.
    protected const string firmId = "firmId";
    protected const string id = "id";
    protected const string password = "password";

    protected readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("https://pfolio-api-staging.seccl.tech/")
    };

    protected ITokenHttpClient tokenClient => new TokenHttpClient(_httpClient);
}
