using TodoPlan.Core.Models;

namespace TodoPlan.API.Services.Interfaces;

public interface IBusinessTaskMockService
{
    Task<List<BusinessTask>?> Get();
}