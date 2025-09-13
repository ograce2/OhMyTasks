using Microsoft.EntityFrameworkCore;
using TasksManagerMVC.Data;
using TasksManagerMVC.Models;

namespace TasksManagerMVC.Services
{
    public class TaskService
    {
        private readonly TasksDbContext _context;

        public TaskService(TasksDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public void AddTask(string description)
        {
            var task = new TaskItem
            {
                Description = description,
                IsCompleted = 0
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public TaskItem? GetTaskById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void MarkTaskComplete(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                // task.IsCompleted = true;
                task.IsCompleted = 1;
                _context.SaveChanges();
            }
        }

        public bool DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}