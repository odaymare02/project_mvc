using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_mvc.Data;
using project_mvc.Models;
using project_mvc.Services;
using System.Threading.Tasks;

namespace project_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public ApplicationDbContext contex = new();
        public IActionResult Index()
        {
            var products = contex.products.ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            ViewBag.category = contex.categories.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product request,IFormFile Image /*this show cuz enctypt that i use*/ )
        {
            if (Image == null || Image.Length == 0)
            {
                ModelState.AddModelError("Image", "Please upload an image.");
            }
            else
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
                var extension = Path.GetExtension(Image.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Image", "Only image files with valid extensions are allowed.");
                }
            }
            if(!ModelState.IsValid)
            {
                ViewBag.category = contex.categories.ToList();
                return View(request);
            }
                var imgServ = new ImageService();
                var fileName = await imgServ.UploadImage(Image);
                request.Image = fileName;//only name store inside the database
                contex.products.Add(request);
                TempData["success"] = "the operation was copleted success";
                contex.SaveChanges();
                return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var product = contex.products.Find(id);
            ViewBag.categories = contex.categories.ToList();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product,IFormFile ? image)
        {
            var existProduct = contex.products.AsNoTracking().FirstOrDefault(p => p.Id == product.Id);
            if(image is not null)
            {
                var imgServ = new ImageService();                
               var newImg= await imgServ.UploadImage(image);
                product.Image = newImg;
                imgServ.DeleteImage(existProduct.Image);
            }
            else
            {
                product.Image = existProduct.Image;

            }
            contex.products.Update(product);
            contex.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult delete(int id)
        {
            var imgServ = new ImageService();
            var product = contex.products.FirstOrDefault(p => p.Id == id);
            imgServ.DeleteImage(product.Image);
            contex.products.Remove(product);
            contex.SaveChanges();
           return RedirectToAction("index");
        }
    }
}
