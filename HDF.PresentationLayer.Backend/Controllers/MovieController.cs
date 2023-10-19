using HDF.BusinessLayer.Abstract;
using HDF.DAL.Context;
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.ViewModels;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;
        private readonly IKindService _kindService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(IMovieService movieService, ICategoryService categoryService,
           ICountryService countryService, ILanguageService languageService, IKindService kindService,
           IWebHostEnvironment webHostEnvironment)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _countryService = countryService;
            _languageService = languageService;
            _kindService = kindService;           
            _webHostEnvironment = webHostEnvironment;
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
                KindList = new List<SelectListItem>(),
                Kinds = _kindService.GetList(),
                LanguageList = new List<SelectListItem>(),
                Languages = _languageService.GetList(),
                Countries = _countryService.GetList(),
                CountryList = new List<SelectListItem>(),
                Movies = _movieService.GetList()
            };          

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

                // Movie Image Created
                if (!movieVM.Movie.FilmPhoto.ContentType.Contains("image")) return View(movieVM);
                if (movieVM.Movie.FilmPhoto.Length / 1024 > 1000) return View(movieVM);
                movieVM.Movie.FilmImage = Methods.RenderImage(movieVM.Movie.FilmPhoto, movieVM.Movie.Name.Replace(" ", "-"), "movies", _webHostEnvironment.WebRootPath);
                if (string.IsNullOrEmpty(movieVM.Movie.FilmImage))
                {
                    ModelState.AddModelError("Image", "Image was incorrect");
                    return View(movieVM);
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
            MovieVM movieVM = new MovieVM()
            {
                Categories = _categoryService.GetList(),
                Kinds = _kindService.GetList(),
                Languages = _languageService.GetList(),
                Countries = _countryService.GetList(),
                CountryList = new List<SelectListItem>(),
                Movie = _movieService.GetById(id),
                Movies = _movieService.GetList()             
            };

            if (movieVM.Movie == null) return NotFound();
            movieVM.Image = movieVM.Movie.FilmImage;

            foreach (var country in movieVM.Countries)
            {
                movieVM.CountryList.AddRange(new List<SelectListItem>
                {
                    new SelectListItem(){Value = country.Id.ToString(), Text = country.Name}
                });
            }                  
            return View(movieVM);
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieVM movieVM)
        {
            try
            {
                //if user don't choose image program enter here
                if (movieVM.Movie.FilmPhoto == null)
                {
                    movieVM.Movie.FilmImage = movieVM.Image;
                    ModelState["Movie.FilmPhoto"].ValidationState = ModelValidationState.Valid;
                }
                else
                    movieVM.Movie.FilmImage = Methods.UpdateImage(movieVM.Movie.FilmPhoto, movieVM.Movie.Name.Replace(" ", "-"), "movies", _webHostEnvironment.WebRootPath, movieVM.Image);

                if (!ModelState.IsValid) return View(movieVM);

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

               
               
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult DeleteOrActive(int id)
        {

            Movie movie = _movieService.GetById(id);
            if (movie == null) return NotFound();

            if(movie.IsActive) movie.IsActive = false;
            else movie.IsActive = true;
            _movieService.Update(movie);

            return RedirectToAction(nameof(Index));
        }
       
    }
}
