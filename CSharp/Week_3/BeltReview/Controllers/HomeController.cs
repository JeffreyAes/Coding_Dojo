using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltReview.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace BeltReview.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }


    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }

    [HttpPost("users/login")]
    public IActionResult LoginUser(LogUser userLog)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userLog.LEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(userLog, userInDb.Password, userLog.LPassword);
            if (result == 0)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
        }
        else
        {
            return View("Index");
        }
    }

    [SessionCheck]
    [HttpGet("users/dashboard")]
    public IActionResult Dashboard()
    {

        MyViewModel MyModel = new MyViewModel
        {
            User = _context.Users
        .Include(a => a.OrdersPlaced)
        .ThenInclude(s => s.Craft)
        .FirstOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId")),

            TotalSold = _context.Orders
        .Include(a => a.Craft)
        .Where(s => s.Craft.UserId == (int)HttpContext.Session.GetInt32("UserId"))
        .Sum(a => a.QuantityOrdered),

            MoneyMade = _context.Orders.Include(a => a.Craft).Where(s => s.Craft.UserId == (int)HttpContext.Session.GetInt32("UserId")).Sum(s => s.Craft.Price * s.QuantityOrdered),
            CraftsBought = _context.Orders.Where(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId")).Sum(a => a.QuantityOrdered)
        };

        return View("Dashboard", MyModel);
    }


    [SessionCheck]
    [HttpGet("crafts")]
    public IActionResult Crafts()
    {
        List<Craft> AllCrafts = _context.Crafts.Include(a => a.Creator).ToList();
        return View("Craft", AllCrafts);
    }


    [SessionCheck]
    [HttpGet("crafts/new")]
    public IActionResult NewCraft()
    {
        return View("NewCraft");
    }

    [SessionCheck]
    [HttpPost("crafts/create")]
    public IActionResult CreateCraft(Craft newCraft)
    {
        if (ModelState.IsValid)
        {
            newCraft.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newCraft);
            _context.SaveChanges();
            return RedirectToAction("Crafts");
        }
        else
        {
            return View("NewCraft");
        }
    }


    [SessionCheck]
    [HttpGet("crafts/{craftId}")]
    public IActionResult OneCraft(int craftId)
    {
        Craft One = _context.Crafts.Include(s => s.Creator).FirstOrDefault(a => a.CraftId == craftId);

        ViewBag.OneCraft = One;
        return View("OneCraft", One);
    }

    [SessionCheck]
    [HttpPost("orders/create")]
    public IActionResult CreateOrder(Order newOrder, int craftId)
    {
        if (ModelState.IsValid)
        {
            newOrder.UserId = (int)HttpContext.Session.GetInt32("UserId");
            Craft CraftOrdered = _context.Crafts.FirstOrDefault(a => a.CraftId == newOrder.CraftId);
            CraftOrdered.Quantity -= newOrder.QuantityOrdered;
            CraftOrdered.UpdatedAt = DateTime.Now;
            _context.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("OneCraft", newOrder.CraftId);
        }
    }


    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("crafts/{craftId}/destroy")]
    public IActionResult DestroyCraft(int craftId)
    {
        Craft CraftToDestroy = _context.Crafts.SingleOrDefault(a => a.CraftId == craftId);
        if(CraftToDestroy == null)
        {
            return RedirectToAction("Crafts");
        }
        _context.Remove(CraftToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Crafts");
    }


    [SessionCheck]
    [HttpGet("orderhistory")]
    public IActionResult OrderHistory()
    {
        MyViewModel MyModel = new MyViewModel
        {
            YourSales = _context.Orders
            .Include(s => s.User)
            .Include(a => a.Craft)
            .Where(s => s.UserId == (int)HttpContext.Session.GetInt32("UserId")).ToList(),
            YourOrders = _context.Orders
            .Include(s => s.Craft)
            .ThenInclude(a => a.Creator)
            .Where(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId")).ToList()

        };
        return View("OrderHistory", MyModel);
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

    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "home", null);
            }
        }
    }
}
