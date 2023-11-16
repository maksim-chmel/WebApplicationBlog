using Microsoft.EntityFrameworkCore;
using newProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Реєстрація служби EFDataRepository та налаштування зв'язку з базою даних
builder.Services.AddTransient<IDataRepository, EFDataRepository>();
builder.Services.AddDbContext<EFDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.Run();
