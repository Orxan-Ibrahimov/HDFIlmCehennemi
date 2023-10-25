using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Controllers
{
    [Area("admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            List<Category> categories = _categoryService.GetList();
            if (categories == null)
                return NotFound();

            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {          
            Category category = _categoryService.GetById(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if(category == null) return NotFound();

                if (!ModelState.IsValid) return View(category);

                _categoryService.Insert(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = _categoryService.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                if (category.Id != id) return BadRequest();

                if(!ModelState.IsValid) return View(category);

                _categoryService.Update(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = _categoryService.GetById(id);

            if(category == null) return NotFound();

            _categoryService.Delete(category);

            return RedirectToAction(nameof(Index));
        }

       
    }
}
