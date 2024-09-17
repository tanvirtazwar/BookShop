using BookShopWeb.Data;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Category> objectCategory = db.Categories.ToList();
            return View(objectCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name != null && !(category.Name.All(char.IsLetter)))
            {
                ModelState.AddModelError("Name", "The Category" +
                    " Name must contain only letters.");
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name != null && !(category.Name.All(char.IsLetter)))
            {
                ModelState.AddModelError("Name", "The Category" +
                    " Name must contain only letters.");
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
