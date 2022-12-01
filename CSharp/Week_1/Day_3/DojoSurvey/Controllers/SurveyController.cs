using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;

public class SurveyController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("process")]
    public IActionResult process(string name, string location, string language, string comment)
    {
        if (name == null)
        {
            return RedirectToAction("Index");
        }
        else
        {

        return RedirectToAction("ShowResults", new { name = name, location = location, language = language, comment = comment });
        }

    }

    [HttpGet("results")]
    public ViewResult ShowResults(string name, string location, string language, string comment)
    {
        ViewBag.Name = name;
        ViewBag.Language = language;
        ViewBag.Location = location;
        ViewBag.Comment = comment;
        return View("Results");
    }



}