var builder = WebApplication.CreateBuilder(args);
// ADD THE SERVICES AFTER WebApplication AND BEFORE builder.Build();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Our builder code
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(    
    name: "default",    
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
