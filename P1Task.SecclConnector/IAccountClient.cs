using P1Task.Dtos;

namespace P1Task.SecclConnector;

public interface IAccountClient
{
    Task<List<Account>> GetAccountsAsync(string token, string firmId, string clientId);
}