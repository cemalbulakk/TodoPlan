using TodoPlan.API.Models;
using TodoPlan.API.Services;
using TodoPlan.API.Services.Interfaces;
using TodoPlan.Core.Repositories;
using TodoPlan.Repo.Repositories;

namespace TodoPlan.API.Extensions;

public static class ServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {
        var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        services.AddHttpClient<IBusinessTaskMockService, BusinessTaskMockService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.BusinessTaskAPIUrl}");
        });

        services.AddHttpClient<IITTaskMockService, ITTaskMockService>(opt =>
        {
            opt.BaseAddress = new Uri($"{serviceApiSettings.ITTaskAPIUrl}");
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}