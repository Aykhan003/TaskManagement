using Assignment_Functional.Methods;
using System.Data;
using TaskManagement.Exceptions;
using TaskManagement.Services;

namespace TaskManagement.Methods;

internal class TaskService : ITaskService
{
    private static List<MyTask> _tasks = new List<MyTask>();
    private static List<TasksAssignment> _taskAssignments = new List<TasksAssignment>();
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
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            throw new NotFoundException("Task not found.");
        }
        _tasks.Remove(task);
    }

    public List<MyTask> GetByStatus(MyTaskStatus status)
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
    public List<MyTask> GetByPriority(TaskPriority priority)
    {
        List<MyTask> tasksByPriority = new List<MyTask>();
        foreach (var task in _tasks)
        {
            if (task.Priority == priority)
            {
                tasksByPriority.Add(task);
            }
        }

        if (tasksByPriority.Count == 0)
        {
            throw new NotFoundException($"No tasks found with priority '{priority}'.");
        }

        return tasksByPriority;
    }
    public void ChangePriority(int id, TaskPriority newPriority)
    {
        foreach (var task in _tasks)
        {
            if (task.Id == id)
            {
                task.Priority = newPriority;
                return;
            }
        }
        throw new NotFoundException("Task not found.");
    }
    public void AssignTaskToUser(int taskId, int userId)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == taskId);
        var user = UserService.GetUserById(userId);
        if (task == null || user == null)
        {
            throw new NotFoundException("Task or user not found.");
        }
        _taskAssignments.Add(new TasksAssignment(taskId, userId));
    }
    public List<MyTask> GetTasksByUserId(int userId)
    {
        var user = UserService.GetUserById(userId);
        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }
        List<MyTask> tasksForUser = new List<MyTask>();
        foreach (var assignment in _taskAssignments)
        {
            if (assignment.UserId == userId)
            {
                var task = _tasks.FirstOrDefault(t => t.Id == assignment.TaskId);
                if (task != null)
                {
                    tasksForUser.Add(task);
                }
            }
        }
        if (tasksForUser.Count == 0)
        {
            throw new NotFoundException("No tasks assigned to this user.");
        }
        return tasksForUser;
    }
}
