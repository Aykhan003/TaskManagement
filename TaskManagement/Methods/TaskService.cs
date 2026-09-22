using System.Data;
using TaskManagement.Exceptions;
using TaskManagement.Services;

namespace TaskManagement.Methods;

internal class TaskService : ITaskService
{
    private static List<MyTask> _tasks = new List<MyTask>();

    public void AddTask(MyTask task)
    {
        foreach (var existingTask in _tasks)
        {
            if (existingTask.Title == task.Title)
            {
                throw new ConflictException($"A task with the title '{task.Title}' already exists.");
            }
        }
        _tasks.Add(task);
    }

    public void DeleteById(int id)
    {
        foreach (var task in _tasks)
        {
            if (task.Id == id)
            {
                _tasks.Remove(task);
                return;
            }
        }
        throw new NotFoundException("Task not found.");
    }

    public List<MyTask> GetByStatus(TaskStatus status)
    {
        List<MyTask> tasksByStatus = new List<MyTask>();
        foreach (var task in _tasks)
        {
            if (task.Status == status)
            {
                tasksByStatus.Add(task);
            }
        }
        return tasksByStatus;
    }

    public MyTask GetTaskByTitle(string title)
    {
        foreach (var task in _tasks)
        {
            if (task.Title == title)
            {
                return task;
            }
        }
        throw new NotFoundException("Task not found.");
    }
}
