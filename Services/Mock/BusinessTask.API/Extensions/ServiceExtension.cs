using BusinessTask.API.Models;
using BusinessTask.API.Services;
using BusinessTask.API.Services.Interfaces;

namespace BusinessTask.API.Extensions;

public static class ServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        services.AddHttpClient<IMockService, MockService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.BusinessTaskMockUrl}");
        });

    }
}