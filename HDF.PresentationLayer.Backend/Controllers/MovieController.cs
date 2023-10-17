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
        private readonly ILanguageService _languageService;

        public MovieController(IMovieService movieService, ICategoryService categoryService,
           ICountryService countryService, IFilmOrSerieService filmOrSerieService, ILanguageService languageService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _countryService = countryService;
            _filmOrSerieService = filmOrSerieService;
            _languageService = languageService;
        }

        // GET: MovieController
        public ActionResult Index()
        {
            List<Movie> movies = _movieService.GetList(); ;
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
                LanguageList = new List<SelectListItem>(),
                Languages = _languageService.GetList(),
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
                if (!ModelState.IsValid) return RedirectToAction(nameof(Create));

                // Create m:n Table Instance
                movieVM.Movie.MovieCategories = new List<MovieCategory>();
                movieVM.Movie.MovieLanguages = new List<MovieLanguage>();

                // Fill m:n Tables
                foreach (int category in movieVM._categories)
                {
                    if (category < 0) continue;
                    MovieCategory movieCategory = new MovieCategory()
                    {
                        CategoryId = category,
                        MovieId = movieVM.Movie.Id
                    };
                    movieVM.Movie.MovieCategories.Add(movieCategory);
            }
               
                foreach (int languageId in movieVM._languages)
                {
                    if (languageId < 0) continue;
                    MovieLanguage movieLanguage = new MovieLanguage()
                    {
                        LanguageId = languageId,
                        MovieId = movieVM.Movie.Id
                    };
                    movieVM.Movie.MovieLanguages.Add(movieLanguage);
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
