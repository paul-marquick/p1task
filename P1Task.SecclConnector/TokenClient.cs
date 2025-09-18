using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace P1Task.SecclConnector;

public class TokenClient(HttpClient httpClient) : ITokenClient
{
    public async Task<string> GetTokenAsync(string firmId, string id, string password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "authenticate");

        var data = new
        {
            firmId,
            id,
            password
        };

        request.Content = new StringContent(JsonSerializer.Serialize(data, JsonSerializerOptions.Web), Encoding.UTF8, Application.Json);

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(await response.Content.ReadAsStringAsync(), JsonSerializerOptions.Web)!;

        return tokenResponse.Data.Token;
    }

    private record TokenResponse
    {
        public required Data Data { get; set; }
    }

    private record Data
    {
        public required string Token { get; set; }
    }
}
