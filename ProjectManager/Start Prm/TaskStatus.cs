namespace Project_Manager;

public class TaskStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
    public static TaskStatus Status { get; set; }

    public void ChangeTaskStatus(TaskStatus status)
    {
        Status = status;
        
    }
    
    public static TaskStatus NotStarted = new TaskStatus { Id = 1, Name = "Не начато" };
    public static TaskStatus InProgress = new TaskStatus { Id = 2, Name = "В процессе" };
    public static TaskStatus Completed = new TaskStatus { Id = 3, Name = "Завершено" };
}