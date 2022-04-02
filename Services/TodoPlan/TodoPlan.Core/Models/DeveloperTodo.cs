namespace TodoPlan.Core.Models;

public class DeveloperTodo
{
    public int Id { get; set; }

    public int DeveloperId { get; set; }
    public Developer Developer { get; set; }

    public Todo Todo { get; set; }
    public string TodoId { get; set; }
}