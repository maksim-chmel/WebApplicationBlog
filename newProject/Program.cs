using Microsoft.EntityFrameworkCore;
using newProject.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IDataRepository, EFDataRepository>();
builder.Services.AddDbContext<EFDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddDbContext<EFDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomePage}/{id?}"); 

app.Run();
