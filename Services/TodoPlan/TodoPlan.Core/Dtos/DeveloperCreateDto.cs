namespace TodoPlan.Core.Dtos;

public class DeveloperCreateDto
{
    public string Name { get; set; }
    public int WeeklyWorkingHours { get; set; }
    public int Duration { get; set; }
    public int Difficulty { get; set; }
}