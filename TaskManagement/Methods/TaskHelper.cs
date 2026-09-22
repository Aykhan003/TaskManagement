namespace TaskManagement.Methods;

public static class TaskHelper
{
    public static TimeSpan GetRemainingTime(this MyTask task)
    {
        return task.Deadline - DateTime.Now;
    }
    public static TimeSpan GetOverdueTime(this MyTask task)
    {
        return DateTime.Now - task.Deadline;
    }
}
