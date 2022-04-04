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

        public IActionResult Details(int developerId)
        {
            var dev = _context.Developers
                .Include(x => x.DeveloperTodos)
                .ThenInclude(x => x.Todo)
                .FirstOrDefault(x => x.Id == developerId);
            return View(dev);
        }

    }
}
