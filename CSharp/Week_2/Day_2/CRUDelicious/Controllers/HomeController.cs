using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

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

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View("Index", AllDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        return View("NewDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {

            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {

            return View("NewDish");
        }
    }

    [HttpGet("Dishes/()dishId/show")]
    public IActionResult ShowDish(int dishId)
    {
        Dish? DishToShow = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
        if (DishToShow != null)
        {
            return View("OneDish", DishToShow);
        }
        else{
            return RedirectToAction("Index");
        }
    }

    [HttpPost("dishes/{dishId}/destroy")]
    public IActionResult DestroyDish(int dishId)
    {
        Dish? DishToDestroy = _context.Dishes.SingleOrDefault(d =>  d.DishId == dishId);
        _context.Dishes.Remove(DishToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet("dishes/{dishId}/edit")]
    public IActionResult EditDish(int dishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(e => e.DishId == dishId);
        if (DishToEdit != null)
        {
            return View("DishToEdit", DishToEdit);
        } else {
            return RedirectToAction("ShowDish");
        }
    }

    [HttpPost("dishes/{dishId}/update")]
    public IActionResult UpdateDish(Dish NewDish, int dishId)
    {
        if(ModelState.IsValid)
        {
            Dish?OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == dishId);
            OldDish.Name = NewDish.Name;
            OldDish.Chef = NewDish.Chef;
            OldDish.Tastiness = NewDish.Tastiness;
            OldDish.Calories = NewDish.Calories;
            OldDish.Description = NewDish.Description;
            OldDish.Updated_At = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ShowDish", new{dishId=dishId});
        }else{
            return RedirectToAction("ShowDish");
        }
    }
}
