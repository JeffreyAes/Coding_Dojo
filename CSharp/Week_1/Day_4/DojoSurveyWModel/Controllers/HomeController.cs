using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWModel.Models;

namespace DojoSurveyWModel.Controllers;

public class HomeController : Controller
{
    static Survey data;
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
    public IActionResult process(Survey newData)
    {
        data = newData;
        return RedirectToAction("ShowResults");

    }
    [HttpGet("results")]
    public ViewResult ShowResults()
    {
        
        return View("Results", data);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
