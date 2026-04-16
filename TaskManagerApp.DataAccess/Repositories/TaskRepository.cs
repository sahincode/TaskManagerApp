using Microsoft.EntityFrameworkCore;
using TaskManagerApp.DataAccess.Context;
using TaskManagerApp.Domain.Entities;
using TaskManagerApp.Domain.Repositories;

namespace TaskManagerApp.DataAccess.Repositories;

public class TaskRepository : BaseRepository<TaskItem>, ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<TaskItem>> GetSortedAsync(string sortBy)
    {
        var query = _context.Tasks.AsQueryable();

        query = sortBy switch
        {
            "priority" => query.OrderBy(t => t.Priority),
            "deadline" => query.OrderBy(t => t.Deadline),
            _ => query
        };

        return await query.ToListAsync();
    }
}