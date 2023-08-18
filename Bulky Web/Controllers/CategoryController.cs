using Bulky.DataAccess;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
                _categoryRepository = categoryRepository;
        }
        
        public IActionResult Index()
        {
            var result =  _categoryRepository.GetAll();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == "test")
            {
                ModelState.AddModelError("name", "Name cant be Test");
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(obj);
                _categoryRepository.save();
                TempData["Sucsess"] = " Category Created Sucessfuly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                // here we can return an page for Not Found as well or any Error Page
                return NotFound();
            }
            else
            {
                var result = _categoryRepository.Get( x => x.Id == id);
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
                _categoryRepository.update(obj);
                _categoryRepository.save();
                TempData["Sucsess"] = " Category Updated Sucessfuly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult Delete(int id)
        {
            var result =  _categoryRepository.GetById(id);
            if (result != null)
            {
                _categoryRepository.Delete(result);
                _categoryRepository.save();
                TempData["Sucsess"] = " Category Deleted Sucessfuly";
                return RedirectToAction("Index");
            }else
            {
                return NotFound();
            }

        }
    }
}
