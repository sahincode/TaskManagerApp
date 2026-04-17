using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Application.Services;
using TaskManagerApp.Domain.Entities;


public class TaskController : Controller
{
    private readonly ITaskService _service;

    public TaskController(ITaskService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> Index(string sortBy)
    {
        var tasks = await _service.GetAllAsync(sortBy);
        return View(tasks);
    }
    public async Task<IActionResult> Details(int id)
    {
        var task = await _service.GetByIdAsync(id);

        if (task == null)
            return NotFound();

        return View(task);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskItem task)
    {
        task.Deadline = task.Deadline.HasValue
            ? DateTime.SpecifyKind(task.Deadline.Value, DateTimeKind.Utc)
            : null;
        try
        {
            if (!ModelState.IsValid)
                return View(task);

            await _service.CreateAsync(task);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(task);
        }
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _service.GetByIdAsync(id);

        if (task == null)
            return NotFound();

        return View(task);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TaskItem task)
    {
        task.Deadline = task.Deadline.HasValue
            ? DateTime.SpecifyKind(task.Deadline.Value, DateTimeKind.Utc)
            : null;
        try
        {
            if (!ModelState.IsValid)
                return View(task);

            await _service.UpdateAsync(task);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(task);
        }
    }
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _service.GetByIdAsync(id);
        if (task == null) return NotFound();

        return View(task);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(TaskItem task)
    {
        await _service.DeleteAsync(task.Id);
        return RedirectToAction(nameof(Index));
    }
}