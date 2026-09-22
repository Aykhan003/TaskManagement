using TaskManagement.Methods;

namespace TaskManagement.Services;

internal interface ITaskService
{
    public void AddTask(MyTask task);
    public MyTask GetTaskByTitle(string title);
    public List<MyTask> GetByStatus(MyTaskStatus status);
    public void DeleteById(int id);
    public List<MyTask> GetByPriority(TaskPriority priority);
    public void ChangePriority(int id, TaskPriority newPriority);
}
