using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace P1Task.SecclConnector;

public class TokenClient(HttpClient httpClient) : ITokenClient
{
    JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public async Task<string> GetTokenAsync(string firmId, string id, string password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "authenticate");

        var data = new
        {
            firmId,
            id,
            password
        };

        request.Content = new StringContent(JsonSerializer.Serialize(data, jsonSerializerOptions), Encoding.UTF8, Application.Json);

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(await response.Content.ReadAsStringAsync(), jsonSerializerOptions)!;

        return tokenResponse.Data.Token;
    }

    private class TokenResponse
    {
        public required Data Data { get; set; }
    }

    private class Data
    {
        public required string Token { get; set; }
    }
}
