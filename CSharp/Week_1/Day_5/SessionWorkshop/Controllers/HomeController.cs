using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
    [HttpPost("process")]
    public IActionResult NewLogin(string? name)
    {
        if (name is not null)
        {
            HttpContext.Session.SetString("UserName", name);
        }
        else
        {
            return View("Index");
        }

        return RedirectToAction("Workshop");
    }

    [HttpGet("workshop")]
    public ViewResult Workshop()
    {
        string? newName = HttpContext.Session.GetString("username");
        if (HttpContext.Session.GetInt32("Num") == null)
        {
            HttpContext.Session.SetInt32("Num", 22);
        }

        return View("Workshop");
    }

    [HttpPost("operations")]
    public IActionResult Operations(string buttonName)
    {
        int? newNum = HttpContext.Session.GetInt32("Num");
        System.Console.WriteLine(newNum);
        if (buttonName == "add")
        {
            newNum += 1;
            System.Console.WriteLine(newNum);
        }

        if (buttonName == "subtract")
        {
            newNum -= 1;
            System.Console.WriteLine(newNum);
        }

        if (buttonName == "multiply")
        {
            newNum *= 2;
        }

        if (buttonName == "random")
        {
            Random rand = new Random();
            int randNum = rand.Next(1,11);
            newNum += randNum;
        }

        if (newNum is not null)
        {
            HttpContext.Session.SetInt32("Num", (int)newNum);
        }


        return RedirectToAction("Workshop");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}
