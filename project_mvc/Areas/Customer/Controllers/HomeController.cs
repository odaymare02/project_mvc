using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project_mvc.Data;
using project_mvc.Models;

namespace project_mvc.Areas.Customer.Controllers
{
    [Area("Customer")]
  public class HomeController : Controller
{
    ApplicationDbContext context = new();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()//this is the main page thath open when run this project
    {
        ViewBag.categories = context.categories.ToList();
        ViewBag.products=context.products.ToList();
        return View();
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
}
