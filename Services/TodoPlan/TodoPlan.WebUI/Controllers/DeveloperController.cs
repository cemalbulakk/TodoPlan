using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoPlan.Core.Dtos;
using TodoPlan.Core.Models;
using TodoPlan.Core.Repositories;
using TodoPlan.Repo;

namespace TodoPlan.WebUI.Controllers
{
    public class DeveloperController : Controller
    {
        private readonly IGenericRepository<Developer> _devRepo;
        private readonly IGenericRepository<Todo> _todoRepo;

        private readonly TodoPlanContext _context;

        public DeveloperController(IGenericRepository<Developer> devRepo, IGenericRepository<Todo> todoRepo, TodoPlanContext context)
        {
            _devRepo = devRepo;
            _todoRepo = todoRepo;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var developers = await _devRepo.GetAll().ToListAsync();
            return View(developers);
        }

        public async Task<IActionResult> AddTaskDeveloper(int developerId)
        {
            ViewBag.DeveloperId = developerId;
            var dev = _context.Developers.FirstOrDefault(x => x.Id == developerId);
            if (dev != null) ViewBag.DeveloperName = dev.Name;

            var todo = _context.DeveloperTodos.Include(x => x.Todo).Where(x => x.DeveloperId == developerId).ToList();
            ViewBag.Todo = todo;
            var todos = _context.Todos.ToList();
            ViewBag.Todos = todos;
            return View();
        }

        [HttpPost]
        public IActionResult AddTaskDeveloper(DeveloperTodoCreateDto model)
        {
            var developerTodo = new DeveloperTodo()
            {
                DeveloperId = model.DeveloperId,
                TodoId = model.TodoId
            };

            _context.DeveloperTodos.Add(developerTodo);
            var result = _context.SaveChanges();

            if (result > 0)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("AddTaskDeveloper", model.DeveloperId);

        }
    }
}
