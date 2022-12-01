// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace Portfolio.Controllers;

public class PortfolioController : Controller
{

    [Route("")]
    public string Index()
    {
        return "This is my index!";
    }
    [Route("/projects")]
    public string Projects()
    {
        return "These are my projects!";
    }
    [Route("/contact")]
    public string Contact()
    {
        return "These are my Contact!";
    }
}