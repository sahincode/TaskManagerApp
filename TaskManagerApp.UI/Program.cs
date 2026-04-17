

using Microsoft.EntityFrameworkCore;
using TaskManagerApp.Application.Services;
using TaskManagerApp.DataAccess.Context;
using TaskManagerApp.DataAccess.Repositories;
using TaskManagerApp.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Default")
    )
);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}"
);

app.Run();