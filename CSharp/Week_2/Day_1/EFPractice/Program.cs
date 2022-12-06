using Microsoft.EntityFrameworkCore;
// You will need access to your models for your context file
using EFPractice.Models;

var builder = WebApplication.CreateBuilder(args);
// Add this using statement
// Builder code from before
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddDbContext<MyContext>(options =>
// Create a variable to hold your connection string
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
