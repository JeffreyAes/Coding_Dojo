using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFDemo.Models;

namespace EFDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    // Add a private variable of type MyContext (or whatever you named your context file)
    private MyContext _context;  

    public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        _context = context;    
    }         

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("songs/create")]
    public IActionResult CreateSong(Music newSong)
    {
        if(ModelState.IsValid)
        {
            // add a song to our database
            _context.Add(newSong);
            // Save the changes
            _context.SaveChanges();
            // Redirect somewhere.
            return RedirectToAction("Index");
        } else{

        return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
