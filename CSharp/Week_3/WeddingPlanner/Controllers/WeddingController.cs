using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public WeddingController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }
    [SessionCheck]
    [HttpGet("weddings")]
    public IActionResult Weddings()

    {
        List<Wedding> allWeddings = _context.Weddings
        .Include(a => a.Guests)
        .ToList();
        
        return View("Weddings", allWeddings);
    }


    [SessionCheck]
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        return View("NewWedding");
    }


    [SessionCheck]
    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (ModelState.IsValid)
        {
            newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        else
        {
            return View("NewWedding");
        }
    }
    [SessionCheck]
    [HttpPost("weddings/{weddingId}/destroy")]
    public IActionResult DeleteWedding(int weddingId)
    {
        Wedding weddingToDestroy = _context.Weddings.SingleOrDefault(a => a.WeddingId == weddingId);
        if (weddingToDestroy == null)
        {
            return RedirectToAction("Weddings");
        }
        _context.Remove(weddingToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpPost("guests")]
    public IActionResult AddGuest(Guest guest)
    {
        if (ModelState.IsValid)
        {
            _context.Add(guest);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpPost("guests/{weddingId}/{userId}/delete")]
    public IActionResult DeleteGuest(int weddingId, int userId)
    {
        Guest? guest = _context.Guests.SingleOrDefault(g => g.WeddingId == weddingId && g.UserId == userId);
        if (guest == null)
        {
            return RedirectToAction("Weddings");
        }
        _context.Guests.Remove(guest);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }


    [SessionCheck]
    [HttpGet("guests/weddings/{weddingId}")]
    public IActionResult OneWedding(int weddingId)
    {
        // passing the model including related objects for using multiple models.
        Wedding One = _context.Weddings
        .Include(w => w.Guests)
        .ThenInclude(g => g.User)
        .FirstOrDefault(w => w.WeddingId == weddingId);
        return View("OneWedding", One);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
