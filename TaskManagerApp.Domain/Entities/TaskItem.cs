using TaskManagerApp.Domain.Enums;

namespace TaskManagerApp.Domain.Entities;

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public DateTime? Deadline { get; set; }

    public bool IsCompleted { get; set; }
}