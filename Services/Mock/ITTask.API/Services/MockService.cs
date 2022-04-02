using ITTask.API.Models;
using ITTask.API.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ITTask.API.Services;

public class MockService : IMockService
{
    private readonly HttpClient _httpClient;
    private readonly ServiceApiSettings _settings;
    public MockService(HttpClient httpClient, IOptions<ServiceApiSettings> serviceApiSettings)
    {
        _httpClient = httpClient;
        _settings = serviceApiSettings.Value;
    }

    public async Task<string> GetTodosAsync()
    {
        return await _httpClient.GetStringAsync(_settings.ItTaskMockUrl);
    }
}