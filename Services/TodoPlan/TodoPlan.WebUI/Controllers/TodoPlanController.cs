using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoPlan.Core.Models;
using TodoPlan.Repo;

namespace TodoPlan.WebUI.Controllers
{
    public class TodoPlanController : Controller
    {
        private readonly TodoPlanContext _context;

        public TodoPlanController(TodoPlanContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var developers = _context.Developers.ToList();
            var todos = _context.Todos.ToList();

            ViewBag.Developers = developers;
            ViewBag.Todos = todos;

            return View();
        }

        public async Task<IActionResult> TaskAssign()
        {
            var developers = _context.Developers.ToList();
            var todos = _context.Todos.Where(x => x.IsAssigned == false).ToList();

            while (todos.Count > 0)
            {
                todos = _context.Todos.Where(x => x.IsAssigned == false).ToList();
                foreach (var todo in todos)
                {
                    foreach (var developer in developers)
                    {
                        if (developer.Difficulty == todo.Zorluk)
                        {
                            if (developer.WeeklyWorkingHours > 0 && ((developer.WeeklyWorkingHours - todo.Sure) > 0))
                            {
                                developer.WeeklyWorkingHours -= todo.Sure;
                                todo.IsAssigned = true;

                                var devTodo = new DeveloperTodo()
                                {
                                    DeveloperId = developer.Id,
                                    TodoId = todo.Id
                                };

                                await _context.AddAsync(devTodo);
                                await _context.SaveChangesAsync();

                            }
                        }
                    }
                }

                await _context.Developers.ForEachAsync(x => x.WeeklyWorkingHours = 45);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index");
        }
    }
}
