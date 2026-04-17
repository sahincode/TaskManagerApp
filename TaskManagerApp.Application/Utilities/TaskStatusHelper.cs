using TaskManagerApp.Domain.Entities;

namespace TaskManagerApp.Application.Utilities;

public static class TaskStatusHelper
{
    public static string GetStatus(TaskItem task)
    {
        if (task.IsCompleted)
            return "Done";

        if (task.Deadline.HasValue)
        {
            if (task.Deadline < DateTime.Now)
                return "Overdue";

            if ((task.Deadline.Value - DateTime.Now).TotalHours <= 24)
                return "Urgent";
        }

        return "Active";
    }
}