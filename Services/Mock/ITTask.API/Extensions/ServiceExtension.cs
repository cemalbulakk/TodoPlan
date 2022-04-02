using ITTask.API.Models;
using ITTask.API.Services;
using ITTask.API.Services.Interfaces;

namespace ITTask.API.Extensions;

public static class ServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        services.AddHttpClient<IMockService, MockService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.ItTaskMockUrl}");
        });

    }
}