using Microsoft.AspNetCore.Mvc;
using TasksManagerMVC.Services;

namespace TasksManagerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly TaskService _taskService;

        public HomeController(TaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var tasks = _taskService.GetAllTasks();
            return View(tasks);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                _taskService.AddTask(description);
                return RedirectToAction(nameof(List));
            }
            return View();
        }

        public IActionResult MarkComplete()
        {
            var tasks = _taskService.GetAllTasks();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult MarkComplete(int id)
        {
            _taskService.MarkTaskComplete(id);
            return RedirectToAction(nameof(List));
        }

        public IActionResult Delete()
        {
            var tasks = _taskService.GetAllTasks();
            return View(tasks);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var task = _taskService.GetTaskById(id);
            return View(task);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _taskService.DeleteTask(id);
            return RedirectToAction(nameof(List));
        }
    }
}