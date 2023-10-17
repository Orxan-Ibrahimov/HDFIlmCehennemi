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
        private readonly IFilmOrSerieService _filmOrSerieService;
        private readonly ILanguageService _languageService;
        private readonly IMovieKindService _movieKindService;
        private readonly IMovieLanguageService _movieLanguageService;
        private readonly IMovieCategoryService _movieCategoryService;
        private readonly IKindService _kindService;

        public MovieController(IMovieService movieService, ICategoryService categoryService,
           ICountryService countryService, IFilmOrSerieService filmOrSerieService, ILanguageService languageService, IKindService kindService,
           IMovieKindService movieKindService, IMovieLanguageService movieLanguageService, IMovieCategoryService movieCategoryService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _countryService = countryService;
            _filmOrSerieService = filmOrSerieService;
            _languageService = languageService;
            _kindService = kindService;
            _movieKindService = movieKindService;
            _movieLanguageService = movieLanguageService;
            _movieCategoryService = movieCategoryService;
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
                Categories = _categoryService.GetList(),
                FilmOrSerieList = new List<SelectListItem>(),
                FilmOrSeries = _filmOrSerieService.GetList(),
                KindList = new List<SelectListItem>(),
                Kinds = _kindService.GetList(),
                LanguageList = new List<SelectListItem>(),
                Languages = _languageService.GetList(),
                Countries = _countryService.GetList(),
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
                movieVM.Movie.MovieKinds = new List<MovieKind>();

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
                foreach (int kindId in movieVM._kinds)
                {
                    if (kindId < 0) continue;
                    MovieKind movieKind = new MovieKind()
                    {
                        KindId = kindId,
                        MovieId = movieVM.Movie.Id
                    };
                    movieVM.Movie.MovieKinds.Add(movieKind);
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

            Movie movie = _movieService.GetById(id);
            if (movie == null) return NotFound();

            _movieService.Delete(movie);

            if (movie.MovieKinds != null || movie.MovieKinds.Count() > 0)
            {
                foreach (var movieKind in movie.MovieKinds)
                {
                    _movieKindService.Delete(movieKind);
                }
                movie.MovieKinds.RemoveRange(0, movie.MovieKinds.Count());
            }
            if (movie.MovieLanguages != null || movie.MovieLanguages.Count() > 0)
            {               
                foreach (var movieLanguage in movie.MovieLanguages)
                {
                    _movieLanguageService.Delete(movieLanguage);
                }
                movie.MovieLanguages.RemoveRange(0, movie.MovieLanguages.Count());
            }
            if (movie.MovieCategories != null || movie.MovieCategories.Count() > 0)
            {
                foreach (var movieCategory in movie.MovieCategories)
                {
                    _movieCategoryService.Delete(movieCategory);
                }
                movie.MovieCategories.RemoveRange(0, movie.MovieCategories.Count());
            }

           
            return RedirectToAction(nameof(Index));
        }
       
    }
}
