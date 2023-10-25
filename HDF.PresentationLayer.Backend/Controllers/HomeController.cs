using HDF.BusinessLayer.Abstract;
using HDF.PresentationLayer.Backend.ViewModels;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;

        public HomeController(IMovieService movieService, ICategoryService categoryService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Movies = _movieService.GetList().Where(m => m.IsActive && !m.IsSeries).ToList(),
                Series = _movieService.GetList().Where(s => s.IsActive && s.IsSeries).ToList(),
                Categories = _categoryService.GetList().Where(c => c.Speciality == Speciality.Normal).ToList(),
                SpecialCategories = _categoryService.GetList().Where(c => c.Speciality == Speciality.Special).ToList()
            };

            if (homeVM.Movies == null || homeVM.Categories == null 
                || homeVM.SpecialCategories == null || homeVM.Series == null) return NotFound();
            return View(homeVM);
        }
    }
}
