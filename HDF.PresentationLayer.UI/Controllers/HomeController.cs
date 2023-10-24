using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.UI.Models;
using HDF.PresentationLayer.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace HDF.PresentationLayer.UI.Controllers
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
                Series = _movieService.GetList().Where(m => m.IsActive && m.IsSeries).ToList(),
                Categories = _categoryService.GetList()
            };
            if (homeVM.Movies == null || homeVM.Categories == null) return NotFound();
            return View(homeVM);
        }

       
    }
}