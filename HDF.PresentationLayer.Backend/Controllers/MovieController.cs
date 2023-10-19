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
        private readonly IMovieKindService _movieKindService;
        private readonly IMovieLanguageService _movieLanguageService;
        private readonly IMovieCategoryService _movieCategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(IMovieService movieService, ICategoryService categoryService,
           ICountryService countryService, ILanguageService languageService, IKindService kindService,
           IWebHostEnvironment webHostEnvironment, IMovieLanguageService movieLanguageService,
           IMovieCategoryService movieCategoryService, IMovieKindService movieKindService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _countryService = countryService;
            _languageService = languageService;
            _kindService = kindService;
            _webHostEnvironment = webHostEnvironment;
            _movieLanguageService = movieLanguageService;
            _movieCategoryService = movieCategoryService;
            _movieKindService = movieKindService;
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
                movieVM.Movie.Id = id;
                
                _movieService.Update(movieVM.Movie);
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

        public void AddSub(int first, int second, string list)
        {           
            if (first > 0 && second > 0) 
            {
                
                if (list == "category")
                {
                    MovieCategory movieCategory = new MovieCategory
                    {
                        CategoryId = second,
                        MovieId = first,
                    };

                    _movieCategoryService.Insert(movieCategory);
                }
                if (list == "kind")
                {
                    MovieKind movieKind = new MovieKind
                    {
                        KindId = second,
                        MovieId = first,
                    };
                    _movieKindService.Insert(movieKind);
                }
                if (list == "language")
                {
                    MovieLanguage movieLanguage = new MovieLanguage
                    {
                        LanguageId = second,
                        MovieId = first
                    };
                    _movieLanguageService.Insert(movieLanguage);
                }
            }          

            
        }
        public void RemoveSub(int first, int second,string list)
        {

            if(list == "category")
            {
                MovieCategory movieCategory = _movieCategoryService.GetList()
                    .First(mc => (mc.MovieId == first && mc.CategoryId == second));
                if (movieCategory == null) return;
                _movieCategoryService.Delete(movieCategory);
            }
            if (list == "kind")
            {
                MovieKind movieKind = _movieKindService.GetList().
                    First(mk => (mk.MovieId == first && mk.KindId == second));
                if (movieKind == null) return;
                _movieKindService.Delete(movieKind);
            }
            if (list == "language")
            {
                MovieLanguage movieLanguage = _movieLanguageService.GetList().
                    First( ml => (ml.MovieId == first && ml.LanguageId == second));
                if (movieLanguage == null) return;
                _movieLanguageService.Delete(movieLanguage);
            }

        }
    }
}
