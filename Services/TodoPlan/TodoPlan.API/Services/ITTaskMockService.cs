using System.Text.Json;
using Microsoft.Extensions.Options;
using TodoPlan.API.Models;
using TodoPlan.API.Services.Interfaces;
using TodoPlan.Core.Models;
using TodoPlan.Core.Repositories;

namespace TodoPlan.API.Services;

public class ITTaskMockService : IITTaskMockService
{
    private readonly HttpClient _httpClient;
    private readonly ServiceApiSettings _settings;
    private readonly IGenericRepository<Todo> _todoRepo;
    public ITTaskMockService(HttpClient httpClient, IOptions<ServiceApiSettings> serviceApiSettings, IGenericRepository<Todo> todoRepo)
    {
        _httpClient = httpClient;
        _todoRepo = todoRepo;
        _settings = serviceApiSettings.Value;
    }

    public async Task<List<Todo>> Get()
    {
        return await _httpClient.GetFromJsonAsync<List<Todo>>(_settings.ITTaskAPIUrl + "/api/Mock") ?? new List<Todo>();
    }

    public async Task<bool> AddItTaskMock(List<Todo> todos)
    {
        try
        {
            await _todoRepo.AddRangeAsync(todos);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}