using TaskManagerApp.Domain.Entities;

namespace TaskManagerApp.Application.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllAsync(string sortBy);

    Task<TaskItem> GetByIdAsync(int id);

    Task CreateAsync(TaskItem task);

    Task UpdateAsync(TaskItem task);

    Task DeleteAsync(int id);
}