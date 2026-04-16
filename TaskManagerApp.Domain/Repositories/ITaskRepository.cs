using TaskManagerApp.Domain.Entities;

namespace TaskManagerApp.Domain.Repositories;

public interface ITaskRepository : IBaseRepository<TaskItem>
{
    Task<IEnumerable<TaskItem>> GetSortedAsync(string sortBy);
}