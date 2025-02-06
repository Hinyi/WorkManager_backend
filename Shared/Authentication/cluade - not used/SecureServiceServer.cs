using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Shared.Authentication;

public class SecureServiceServer
{
    private readonly HttpClient _httpClient;
    private readonly IAuthService _authService;

    public async Task<HttpResponseMessage> SendSecureRequestAsync(
        string url, 
        HttpMethod method, 
        object content = null)
    {
        // Generate service-to-service token
        var tokenResponse = await _authService.GenerateTokenAsync("ServiceName", new[] { "Service" });
        
        var request = new HttpRequestMessage(method, url);
        request.Headers.Authorization = 
            new AuthenticationHeaderValue("Bearer", tokenResponse.AccessToken);

        if (content != null)
        {
            request.Content = new StringContent(
                JsonSerializer.Serialize(content), 
                Encoding.UTF8, 
                "application/json"
            );
        }

        return await _httpClient.SendAsync(request);
    }
}