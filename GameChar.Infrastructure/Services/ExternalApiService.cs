using GameChar.Application.Abstractions.Services;

namespace GameChar.Infrastructure.Services;

public class ExternalApiService(HttpClient httpClient) : IExternalApiService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> GetExternalDataAsync()
    {
        var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users/");
        return response;
    }
}
