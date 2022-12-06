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
            return RedirectToAction("Songs");
        } else{

        return View("Index");
        }
    }

    [HttpGet("songs")]
    public IActionResult Songs()
    {
        // grab all songs
    List<Music> AllSongs = _context.Music.ToList();
        // pass it down to cshtml
        return View("AllSongs", AllSongs);
    }

    [HttpPost("songs/{musicId}/destroy")]
    public IActionResult DestroySong(int musicId)
    {
        Music? SongToDestroy = _context.Music.SingleOrDefault(a => a.MusicId == musicId);
        _context.Music.Remove(SongToDestroy);
        _context.SaveChanges();

        return RedirectToAction("Songs");
    }

    [HttpGet("songs/{musicId}/edit")]
    public IActionResult EditSong(int musicId)
    {
        Music? SongToEdit = _context.Music.FirstOrDefault(i => i.MusicId == musicId);
        if (SongToEdit != null)
        {
            return View("SongToEdit", SongToEdit);
        }
        else {
            return RedirectToAction("Songs");
        }
    }

    [HttpPost("songs/{musicId}/update")]
    public IActionResult UpdateSong(Music NewSong, int musicId)
    {
        if(ModelState.IsValid)
        {
            Music? OldSong = _context.Music.FirstOrDefault(i => i.MusicId == musicId);
            OldSong.Title = NewSong.Title; 
            OldSong.Year = NewSong.Year; 
            OldSong.Genre = NewSong.Genre; 
            OldSong.Artist = NewSong.Artist; 
            OldSong.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Songs");
        }
        else{
            return View("SongToEdit");
        }
    }

    [HttpGet("song/{musicId}/show")]
    public IActionResult ShowSong(int musicId)
    {
        System.Console.WriteLine("************in the show song method");
        Music? SongToShow = _context.Music.FirstOrDefault(i => i.MusicId == musicId);
        if (SongToShow != null)
        {
            return View("OneSong", SongToShow);
        }
        else{
            return RedirectToAction("Songs");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
