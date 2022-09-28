using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;

namespace MyAppWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public CategoryController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
    
        public IActionResult Index()
        {
            IEnumerable<CategoryModel> categories = _unitofwork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel category )
        {
            if(ModelState.IsValid)
            {
                _unitofwork.Category.Add(category);
                _unitofwork.Save();
                TempData["success"] = "Data Created Successfully !";
                return RedirectToAction("Index");
            }
            return View(category);
           
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var category = _unitofwork.Category.GetT(x=>x.Id==id);  
            if(category==null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                _unitofwork.Category.Update(category);
                _unitofwork.Save();
                TempData["success"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitofwork.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost , ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id)
        {
            var category = _unitofwork.Category.GetT(x => x.Id == id);
            if (category==null)
            {
                return NotFound();
            }
            _unitofwork.Category.Delete(category);
           _unitofwork.Save();
            TempData["success"] = "Data deleted Successfully !";
            return RedirectToAction("Index");

        }
    }
}
