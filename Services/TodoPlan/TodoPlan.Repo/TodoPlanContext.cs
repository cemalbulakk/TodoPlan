using Microsoft.EntityFrameworkCore;
using TodoPlan.Core.Models;

namespace TodoPlan.Repo;

public partial class TodoPlanContext : DbContext
{
    public TodoPlanContext(DbContextOptions<TodoPlanContext> options) : base(options)
    {
    }

    public DbSet<Developer> Developers { get; set; }
    public DbSet<DeveloperTodo> DeveloperTodos { get; set; }
    public DbSet<DeveloperBusinessTask> DeveloperBusinessTasks { get; set; }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<BusinessTask> BusinessTasks { get; set; }
}