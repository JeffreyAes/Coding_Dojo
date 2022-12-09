using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DishesNChefs.Models;
using Microsoft.EntityFrameworkCore;

namespace DishesNChefs.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllChefs = _context.Chefs.Include(chef => chef.AllDishes).ToList()
        };
        return View("Index", MyModel);
    }

    [HttpGet("chefs/new")]
    public IActionResult NewChef()
    {
        return View("AddChef");
    }

    [HttpPost("chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        System.Console.WriteLine("******FROM THE CREATE CHEF");
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChef");
        }
    }

    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllDishes = _context.Dishes.ToList()
        };
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("AllDishes", MyModel);
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDishes()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllChefs = _context.Chefs.ToList()
        };
        return View("AddDishes", MyModel);
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDishes(Dish dish)
    {
        if (ModelState.IsValid)
        {
            System.Console.WriteLine("*******this is valid");
            _context.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("Dishes");
        }
        else
        {
            System.Console.WriteLine("***********THIS IS NOT VALID");
            MyViewModel MyModel = new MyViewModel
            {
                AllChefs = _context.Chefs.ToList()
            };
            return View("AddDishes", MyModel);
        }
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
