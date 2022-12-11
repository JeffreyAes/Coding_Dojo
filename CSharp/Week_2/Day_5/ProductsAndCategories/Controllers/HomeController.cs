using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        MyViewModel MyModels = new MyViewModel
        {
            AllViewProduct = _context.Products.ToList()
        };
        return View("Index", MyModels);
    }

    [HttpPost("create/product")]
    public IActionResult CreateProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            System.Console.WriteLine("*************HI");
            return Index();
        }
    }

    [HttpGet("category")]
    public IActionResult ShowCategories()
    {
        MyViewModel MyModels = new MyViewModel
        {
            AllViewCategory = _context.Categories.ToList()
        };
        return View("ShowCategories", MyModels);
    }

    [HttpPost("category/create")]
    public IActionResult CreateCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("ShowCategories");
        }
        else
        {
            return ShowCategories();
        }
    }

    [HttpGet("product/{id}")]
    public IActionResult OneProduct(int id)
    {
        // ViewBag.AllCategories = _context.Categories.OrderBy(s => s.Name).ToList();
        ViewBag.AllCategories = _context.Categories.Include(category => category.ProductWithCategories).Where(category => category.ProductWithCategories.All(a => a.ProductId != id));
        Association? OneAssociation = new Association();
        OneAssociation.ProductId = id;
        MyViewModel MyModel = new MyViewModel
        {
                ViewProduct = _context.Products
                .Include(a => a.CategoryWithProducts)
                .ThenInclude(a => a.Category)
                .FirstOrDefault(a => a.ProductId == id),
                ViewAssociation = OneAssociation,
                AllViewAssociation = _context.Associations
                .Include(a => a.Category)
                .Where(a => a.ProductId == id)
                .ToList()
                
            
        };
            return View("OneProductPlusCategories", MyModel);
    }

[HttpPost("create/p/association")]
public IActionResult CreateProductAssociation(Association association)
{
    if(ModelState.IsValid)
    {
        _context.Add(association);
        _context.SaveChanges();
        return RedirectToAction("OneProduct", new {id = association.ProductId});
    } else {
        return View("OneProduct", association.ProductId);
    }
}

[HttpGet("category/{id}")]
public IActionResult OneCategory(int id)
{
    // ViewBag.AllProducts = _context.Products.OrderBy(p => p
    // .Name).ToList();

    ViewBag.AllProducts = _context.Products.Include(prod => prod.CategoryWithProducts).Where(prod => prod.CategoryWithProducts.All(a => a.CategoryId != id));

    Association? OneAssociation = new Association();
    OneAssociation.CategoryId = id;
    MyViewModel MyModel = new MyViewModel
    {
        ViewCategory = _context.Categories
            .Include(a => a.ProductWithCategories)
            .ThenInclude(a => a.Product)
            .FirstOrDefault(a => a.CategoryId == id),
            ViewAssociation = OneAssociation,
                AllViewAssociation = _context.Associations
                .Include(a => a.Product)
                .Where(a => a.CategoryId == id)
                .ToList()
    };
    return View("OneCategoryPlusProduct", MyModel);
}

[HttpPost("create/c/association")]
public IActionResult CreateCategoryAssoiciation(Association association)
{
    if(ModelState.IsValid)
    {
        _context.Add(association);
        _context.SaveChanges();
        return RedirectToAction("OneCategory", new {id = association.CategoryId});
    } else{
        return View("OneCategory", association.CategoryId);
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
