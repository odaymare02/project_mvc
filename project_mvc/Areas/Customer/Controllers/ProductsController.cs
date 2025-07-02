using Microsoft.AspNetCore.Mvc;
using project_mvc.Data;

namespace project_mvc.Areas.Customer.Controllers
{
    [Area("customer")]
    public class ProductsController : Controller
    {
        ApplicationDbContext context = new();
        public IActionResult Index()
        {
            var products = context.products.ToList();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var prod = context.products.FirstOrDefault(p => p.Id == id);
            if(prod is not null)
            {
                return View(prod);
            }
            return NotFound();
        }

    }
}
