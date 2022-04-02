namespace TodoPlan.Core.Models;

public class Developer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WeeklyWorkingHours { get; set; }
    public int Duration { get; set; }
    public int Difficulty { get; set; }

    public List<DeveloperTodo> DeveloperTodos { get; set; }
    public List<DeveloperBusinessTask> DeveloperBusinessTasks { get; set; }
}