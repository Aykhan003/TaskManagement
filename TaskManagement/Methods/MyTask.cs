
namespace TaskManagement.Methods;

public class MyTask
{
    private static int _id;
    public int Id { get; set; }
    public string Title { get; set; }
    public string Commentary { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Deadline { get; set; }
    public MyTaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public MyTask(string title, string commentary, DateTime deadline, TaskPriority priority, MyTaskStatus status)
    {
        _id++;
        Id = _id;
        Title = title;
        Commentary = commentary;
        Deadline = deadline;
        Priority = priority;
        Status = status;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Commentary: {Commentary}, Created: {Created}, Deadline: {Deadline}, Status: {Status}, Priority: {Priority}";
    }
    
}
