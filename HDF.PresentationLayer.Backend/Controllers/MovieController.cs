using HDF.BusinessLayer.Abstract;
using HDF.DAL.Context;
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly ICountryService _countryService;
        private readonly HDFContext _context;
        private readonly IFilmOrSerieService _filmOrSerieService;

        public MovieController(IMovieService movieService, ICategoryService categoryService,
           ICountryService countryService, IFilmOrSerieService filmOrSerieService, HDFContext context)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _countryService = countryService;
            _filmOrSerieService = filmOrSerieService;
            _context = context;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include(m=>m.Country).Include(m=>m.FilmOrSerie).ToList();
            if (movies == null) return NotFound();
            return View(movies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = _movieService.GetById(id);    
            if (movie == null) return NotFound();
            return View(movie);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            MovieVM movieVM = new MovieVM()
            {
                Categories = _categoryService.GetList().ToList(),
                FilmOrSerieList = new List<SelectListItem>(),
                FilmOrSeries = _filmOrSerieService.GetList().ToList(),
                Countries = _countryService.GetList().ToList(),
                CountryList = new List<SelectListItem>(),
                Movies = _movieService.GetList()
            };

            foreach (var filmOrSerie in movieVM.FilmOrSeries)
            {
                movieVM.FilmOrSerieList.AddRange(new List<SelectListItem>
                {
                    new SelectListItem(){Value = filmOrSerie.Id.ToString(), Text = filmOrSerie.Kind}
                });
            }

            foreach (var country in movieVM.Countries)
            {
                movieVM.CountryList.AddRange(new List<SelectListItem>
                {
                    new SelectListItem(){Value = country.Id.ToString(), Text = country.Name}
                });
            }
            return View(movieVM);
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieVM movieVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(movieVM);
                movieVM.Movie.MovieCategories = new List<MovieCategory>();
                foreach (int category in movieVM.categories)
                {
                    MovieCategory movieCategory = new MovieCategory()
                    {
                        CategoryId = category,
                        MovieId = _movieService.GetList().Count() + 1
                    };
                    movieVM.Movie.MovieCategories.Add(movieCategory);
            }
                _movieService.Insert(movieVM.Movie);               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
