
using Cavardi.DataAccess;
using Cavardi.Entities.Models;
using Cavardi.Entities.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cavardi.Web.Controllers
{
    public class CategoryController : Controller
    {

        //private readonly ApplicationDbContext _context;

        //public CategoryController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
          _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var categories=_context.Categories.ToList();
            var categories=_unitOfWork.Category.GetAll();
            return View(categories);
        }

        [HttpGet] //Just for Display
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost] //Just for Display
        [ValidateAntiForgeryToken] //save from CrossSiteForgeryAttack
        public IActionResult Create(Category category)
        {
            if(ModelState.IsValid)
            {
                //_context.Categories.Add(category);
                _unitOfWork.Category.Add(category);
                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Create"] = "Data Has Created Succesfully";

                return RedirectToAction("Index");
            }

           return View(category);
        }


        [HttpGet] //Just for Display
        public IActionResult Edit(int? id)
        {
            if(id == null | id==0)
                NotFound();

            // var categoryIndb = _context.Categories.Find(id);
            var categoryIndb = _unitOfWork.Category.GetFirstOrDefault(x=>x.Id==id);

            return View(categoryIndb);
        }

        [HttpPost] //Just for Display
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                // _context.Categories.Update(category);
                _unitOfWork.Category.Update(category);

                //_context.SaveChanges();
                _unitOfWork.Complete();
                TempData["Update"] = "Data Has Updated Succesfully";

                return RedirectToAction("Index");
            }

            return View(category);
        }


        [HttpGet] //Just for Display
        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
                NotFound();

            // var categoryIndb = _context.Categories.Find(id);
            var categoryIndb = _unitOfWork.Category.GetFirstOrDefault(i => i.Id == id);
            return View(categoryIndb);
        }

        [HttpPost] //Just for Display
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {

            //var categoryIndb = _context.Categories.Find(id);
            var categoryIndb = _unitOfWork.Category.GetFirstOrDefault(i => i.Id == id);

            if (categoryIndb != null)
                NotFound();
           // _context.Categories.Remove(categoryIndb);
            _unitOfWork.Category.Remove(categoryIndb);
            // _context.SaveChanges();
            _unitOfWork.Complete();
            TempData["Delete"] = "Data Has Deleted Succesfully";
            return RedirectToAction("Index");
        }

    }
}
