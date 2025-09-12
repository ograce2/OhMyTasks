using TasksManagerMVC.Models;

namespace TasksManagerMVC.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public void AddTask(string description)
        {
            _tasks.Add(new TaskItem
            {
                Id = _nextId++,
                Description = description,
                IsCompleted = false
            });
        }

        public TaskItem? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void MarkTaskComplete(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        public bool DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                return _tasks.Remove(task);
            }
            return false;
        }
    }
}