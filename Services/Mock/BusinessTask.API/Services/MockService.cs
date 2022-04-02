using System.Text.Json;
using BusinessTask.API.Models;
using BusinessTask.API.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace BusinessTask.API.Services;

public class MockService : IMockService
{
    private readonly HttpClient _httpClient;
    private readonly ServiceApiSettings _settings;
    public MockService(HttpClient httpClient, IOptions<ServiceApiSettings> serviceApiSettings)
    {
        _httpClient = httpClient;
        _settings = serviceApiSettings.Value;
    }

    public async Task<string> GetBusinessTask()
    {
        var result = await _httpClient.GetStringAsync(_settings.BusinessTaskMockUrl);
        return result;
    }
}