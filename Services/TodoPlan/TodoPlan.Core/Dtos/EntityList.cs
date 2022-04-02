namespace TodoPlan.Core.Dtos;

public class EntityList<T>
{
    public int TotalCount { get; set; }
    public int FilteredCount { get; set; }
    public IReadOnlyList<T> PageData { get; set; }
}