using TodoPlan.Core.Models;

namespace TodoPlan.API.Services.Interfaces;

public interface IITTaskMockService
{
    Task<List<Todo>> Get();

    Task<bool> AddItTaskMock(List<Todo> todos);
}