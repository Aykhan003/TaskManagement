using TaskManagement.Methods;

namespace TaskManagement.Services;

internal interface ITaskService
{
    public void AddTask(MyTask task);
    public MyTask GetTaskByTitle(string title);
    public List<MyTask> GetByStatus(TaskStatus status);
    public void DeleteById(int id);
}
