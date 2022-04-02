namespace ITTask.API.Services.Interfaces;

public interface IMockService
{
    Task<string> GetTodosAsync();
}