using Microsoft.Extensions.Options;
using TodoPlan.API.Models;
using TodoPlan.API.Services.Interfaces;
using TodoPlan.Core.Models;

namespace TodoPlan.API.Services;

public class BusinessTaskMockService : IBusinessTaskMockService
{
    private readonly HttpClient _httpClient;
    private readonly ServiceApiSettings _settings;
    public BusinessTaskMockService(HttpClient httpClient, IOptions<ServiceApiSettings> serviceApiSettings)
    {
        _httpClient = httpClient;
        _settings = serviceApiSettings.Value;
    }

    public async Task<List<BusinessTask>?> Get()
    {
        var result = await _httpClient.GetStringAsync(_settings.BusinessTaskAPIUrl + "/api/Mock");
        //var result = await _httpClient.GetFromJsonAsync<List<BusinessTask>>(_settings.BusinessTaskAPIUrl + "/api/Mock");

        //todo => business task mapleyemedim. 

        return new List<BusinessTask>();
    }
}