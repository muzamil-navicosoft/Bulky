using Bulky_Web.Data;
using Bulky_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProjectContext _db;
        public CategoryController(ProjectContext db)
        {
                _db = db;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _db.Categories.ToListAsync();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category obj)
        {
            if(obj.Name == "test")
            {
                ModelState.AddModelError("name", "Name cant be Test");
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(obj);
                _db.SaveChanges();
                TempData["Sucsess"] = " Category Created Sucessfuly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                // here we can return an page for Not Found as well or any Error Page
                return NotFound();
            }
            else
            {
                var result = await _db.Categories.FindAsync(id);
                if(result != null)
                {

                    return View(result);
                }
                return NotFound();
            }
        }
        [HttpPost]
        public  IActionResult Edit(Category obj)
        {
            if (obj.Name == "test")
            {
                ModelState.AddModelError("name", "Name cant be Test");
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Sucsess"] = " Category Updated Sucessfuly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public async Task<IActionResult> Delete( int? id)
        {
            var result = await _db.Categories.FindAsync(id);
            if (result != null)
            {
                _db.Remove(result);
                _db.SaveChanges();
                TempData["Sucsess"] = " Category Deleted Sucessfuly";
                return RedirectToAction("Index");
            }else
            {
                return NotFound();
            }

        }
    }
}
