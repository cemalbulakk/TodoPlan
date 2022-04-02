namespace TodoPlan.Core.Models;

public class BusinessTask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int EstimatedDuration { get; set; }
}