// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Portfolio.Controllers;

public class PortfolioController : Controller
{

    [Route("")]
    public ActionResult RedirectHome()
    {
        return Redirect("/home");
    }

    [Route("/home")]
    public ViewResult Index()
    {
        return View("Index");
    }
    [Route("/projects")]
    public ViewResult Projects()
    {
        return View("Projects");
    }
    [Route("/contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }
}