using TaskManagerApp.Domain.Entities;
using TaskManagerApp.Domain.Repositories;

namespace TaskManagerApp.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync(string sortBy)
    {
        return await _repo.GetSortedAsync(sortBy);
    }

    public async Task<TaskItem> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task CreateAsync(TaskItem task)
    {
        Validate(task);

        await _repo.AddAsync(task);
        await _repo.SaveAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        Validate(task);

        _repo.Update(task);
        await _repo.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _repo.GetByIdAsync(id);

        if (task == null)
            throw new Exception("Task not found");

        _repo.Delete(task);
        await _repo.SaveAsync();
    }

    private void Validate(TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
            throw new Exception("Title boş ola bilməz");
        if (task.Deadline.HasValue)
        {
            task.Deadline = DateTime.SpecifyKind(task.Deadline.Value, DateTimeKind.Utc);
        }

        if (task.Deadline.HasValue && task.Deadline < DateTime.Now)
            throw new Exception("Deadline keçmiş tarix ola bilməz");
    }
}