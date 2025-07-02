using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using project_mvc.Data;
using project_mvc.Models;
using project_mvc.Services;
using System.Threading.Tasks;

namespace project_mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new();
        public IActionResult Index()
        {
            var categories = context.categories.ToList();
            
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(Category request,IFormFile Image)
        {
            var imgServ = new ImageService();
            if (ModelState.IsValid)
            {
               var imgName= await imgServ.UploadImage(Image);
                request.Image = imgName;
                context.categories.Add(request);
                context.SaveChanges(); 
                TempData["success"] = "the operation is completed";//this tem data from browser read only one time after that it deleted already
                return RedirectToAction("index");
            }
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var cate = context.categories.Find(id);
            return View(cate);
        }
        [HttpPost()]
        public async Task<IActionResult> Edit(Category request,IFormFile ? Image)
        {
            var existCat = context.categories.AsNoTracking().FirstOrDefault(c => c.Id == request.Id);
            if(Image is not null)
            {
                var imgServ = new ImageService();
                var newImg =await imgServ.UploadImage(Image);
                request.Image = newImg;
                imgServ.DeleteImage(existCat.Image);
            }
            else
            {
                request.Image = existCat.Image;
            }
                context.categories.Update(request);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var imgServ = new ImageService();
            var category = context.categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                imgServ.DeleteImage(category.Image);
                context.categories.Remove(category);
                context.SaveChanges();
                TempData["success"] = "the category was deleted success";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");


        }
    }
}
