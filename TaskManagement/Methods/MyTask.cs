namespace TaskManagement.Methods;

internal class MyTask
{
    private static int _id;
    public int Id { get; set; }
    public string Title { get; set; }
    public string Commentary { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Deadline { get; set; }
    public TaskStatus Status { get; set; }
    public MyTask(string title, string commentary, DateTime deadline)
    {
        _id++;
        Id = _id;
        Title = title;
        Commentary = commentary;
        Deadline = deadline;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Commentary: {Commentary}, Created: {Created}, Deadline: {Deadline}, Status: {Status}";
    }
}
