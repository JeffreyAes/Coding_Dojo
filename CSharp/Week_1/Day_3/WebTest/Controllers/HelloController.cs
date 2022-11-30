// This brings all the MVC features we need to this file
using Microsoft.AspNetCore.Mvc;
// Be sure to use your own project's namespace here! 
namespace WebTest.Controllers;
public class HelloController : Controller   // Remember inheritance?    
{
    // We will go over this in more detail on the next page    
    [Route("")] // We will go over this in more detail on the next page
    public string Index()
    {
        return "Hello World from HelloController!";
    }

    [HttpGet("greet/{name}")]

    public string Greet(string name)
    {
        if (name == "jeff")
        {
            return "you suck";
        }
        else
        {
            return $"hello {name}";
        }
    }
}