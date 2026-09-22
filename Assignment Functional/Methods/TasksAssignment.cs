namespace Assignment_Functional.Methods;

internal class TasksAssignment
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public int UserId { get; set; }
    public DateTime AssignedDate { get; set; } = DateTime.Now;
    public TasksAssignment(int id, int taskId, int userId)
    {
        Id = id;
        TaskId = taskId;
        UserId = userId;
    }
}
