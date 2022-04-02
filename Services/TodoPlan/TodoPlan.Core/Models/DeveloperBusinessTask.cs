namespace TodoPlan.Core.Models;

public class DeveloperBusinessTask
{
    public int Id { get; set; }

    public int DeveloperId { get; set; }
    public Developer Developer { get; set; }

    public BusinessTask BusinessTask { get; set; }
    public int BusinessTaskId { get; set; }
}