using Bulky.DataAccess;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        
        public IActionResult Index()
        {
            var result =  _unitOfWork.Category.GetAll();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.save();
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
                var result = _unitOfWork.Category.Get( x => x.Id == id);
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
                _unitOfWork.Category.update(obj);
                _unitOfWork.save();
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
            var result =  _unitOfWork.Category.GetById(id);
            if (result != null)
            {
                _unitOfWork.Category.Delete(result);
                _unitOfWork.save();
                TempData["Sucsess"] = " Category Deleted Sucessfuly";
                return RedirectToAction("Index");
            }else
            {
                return NotFound();
            }

        }
    }
}
