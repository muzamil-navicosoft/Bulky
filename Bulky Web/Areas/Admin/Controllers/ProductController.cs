using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController( IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
           var result =  _unitOfWork.Product.GetAll().ToList();
                
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (obj.Title == "test")
            {
                ModelState.AddModelError("Title", "Title cant be Test");
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
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
                var result = _unitOfWork.Product.Get(x => x.Id == id);
                if (result != null)
                {

                    return View(result);
                }
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (obj.Title == "test")
            {
                ModelState.AddModelError("title", "Title cant be Test");
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.update(obj);
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
            var result = _unitOfWork.Product.GetById(id);
            if (result != null)
            {
                _unitOfWork.Product.Delete(result);
                _unitOfWork.save();
                TempData["Sucsess"] = " Category Deleted Sucessfuly";
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
