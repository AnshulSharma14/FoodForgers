using FoodForgers.DataAccess.Repository.IRespository;
using FoodForgers.Model;
using Microsoft.AspNetCore.Mvc;

namespace FoodForgers.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null) return View(category);
            category = _unitOfWork.CategoryRepository.Get(id.GetValueOrDefault());
            if (category == null)
                return NotFound();
            return View(category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (category == null)
                return NotFound();
            if (!ModelState.IsValid)
                return View();
            if (category.Id == 0)
            {
                _unitOfWork.CategoryRepository.Add(category);
            }
            else
            {
                _unitOfWork.CategoryRepository.Update(category);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");
        }
        #region APIs
        [HttpGet]
        public IActionResult GetAll()
        {
            var CategoryList = _unitOfWork.CategoryRepository.GetAll();
            return Json(new { data = CategoryList });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.CategoryRepository.Get(id);
            if (category == null)
                return Json(new { success = false, message = "something Went Wrong" });
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.save();
            return Json(new { success = true, message = "Data Deleted Succesfully" });

        }
        #endregion
    }
}
