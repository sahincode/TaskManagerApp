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

    // GET: /Task?sortBy=priority
    public async Task<IActionResult> Index(string sortBy)
    {
        var tasks = await _service.GetAllAsync(sortBy);
        return View(tasks);
    }

    // GET: /Task/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var task = await _service.GetByIdAsync(id);

        if (task == null)
            return NotFound();

        return View(task);
    }

    // GET: /Task/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Task/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskItem task)
    {
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

    // GET: /Task/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _service.GetByIdAsync(id);

        if (task == null)
            return NotFound();

        return View(task);
    }

    // POST: /Task/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TaskItem task)
    {
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

    // POST: /Task/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}