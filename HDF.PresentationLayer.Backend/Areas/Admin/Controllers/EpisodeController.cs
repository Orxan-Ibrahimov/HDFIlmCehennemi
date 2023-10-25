using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using HDF.PresentationLayer.Backend.ViewModels;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace HDF.PresentationLayer.Backend.Areas.Admin.Controllers
{
    [Area("admin")]
    public class EpisodeController : Controller
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMovieService _movieService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EpisodeController(IEpisodeService episodeService, IMovieService movieService, IWebHostEnvironment webHostEnvironment)
        {
            _episodeService = episodeService;
            _movieService = movieService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: EpisodeController
        public ActionResult Index()
        {
            List<Episode> episodes = _episodeService.GetList();
            if (episodes == null) return NotFound();
            return View(episodes);
        }

        // GET: EpisodeController/Details/5
        public ActionResult Details(int id)
        {
            Episode episode = _episodeService.GetById(id);
            if (episode == null) return NotFound();
            return View(episode);
        }

        // GET: EpisodeController/Create
        public ActionResult Create()
        {
            EpisodeVM episodeVM = new EpisodeVM
            {
                Movies = _movieService.GetList(),
                MovieList = new List<SelectListItem>()
            };

            foreach (var movie in episodeVM.Movies)
            {
                episodeVM.MovieList.AddRange(new List<SelectListItem>()
                {
                    new SelectListItem(){ Value = movie.Id.ToString(), Text = movie.Name }
                });
            }
            return View(episodeVM);
        }

        // POST: EpisodeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EpisodeVM episodeVM)
        {
            try
            {
                if (episodeVM.Episode.EpisodePhoto.Length / 1024 > 1000) return RedirectToAction(nameof(Create));
                if (!episodeVM.Episode.EpisodePhoto.ContentType.Contains("image")) return RedirectToAction(nameof(Create));
                episodeVM.Episode.EpisodeImage = Methods.RenderImage(episodeVM.Episode.EpisodePhoto, episodeVM.Episode.Name.Replace(" ","-"),"episodes",_webHostEnvironment.WebRootPath);
                if (string.IsNullOrEmpty(episodeVM.Episode.EpisodeImage))
                {
                    ModelState.AddModelError("Image", "Image was incorrect");
                    return RedirectToAction(nameof(Create));
                }
                if (!ModelState.IsValid) return View(episodeVM);
                _episodeService.Insert(episodeVM.Episode);                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EpisodeController/Edit/5
        public ActionResult Edit(int id)
        {
            EpisodeVM episodeVM = new EpisodeVM
            {
                Movies = _movieService.GetList(),
                MovieList = new List<SelectListItem>(),
                Episode = _episodeService.GetById(id),
            };

            if (episodeVM.Episode == null) return NotFound();

            episodeVM.EpisodeImage = episodeVM.Episode.EpisodeImage;
            foreach (var movie in episodeVM.Movies)
            {
                episodeVM.MovieList.AddRange(new List<SelectListItem>()
                {
                    new SelectListItem(){ Value = movie.Id.ToString(), Text = movie.Name }
                });
            }
            return View(episodeVM);
        }

        // POST: EpisodeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EpisodeVM episodeVM)
        {
            try
            {
                //if user don't choose image program enter here
                if (episodeVM.Episode.EpisodePhoto == null)
                {
                    episodeVM.Episode.EpisodeImage = episodeVM.EpisodeImage;
                    ModelState["Episode.EpisodePhoto"].ValidationState = ModelValidationState.Valid;
                }
                else
                    episodeVM.Episode.EpisodeImage = Methods.UpdateImage(episodeVM.Episode.EpisodePhoto, episodeVM.Episode.Name.Replace(" ", "-"), "episodes", _webHostEnvironment.WebRootPath, episodeVM.EpisodeImage);

                if (!ModelState.IsValid) return View(episodeVM);

                Episode changedEpisode = new Episode
                {
                   Id = id,
                   EpisodeImage = episodeVM.Episode.EpisodeImage,
                   EpisodeNumber = episodeVM.Episode.EpisodeNumber,
                   Name = episodeVM.Episode.Name,
                   MovieId = episodeVM.Episode.MovieId,
                };
                _episodeService.Update(changedEpisode);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EpisodeController/Delete/5
        public ActionResult Delete(int id)
        {
            Episode episode = _episodeService.GetById(id);
            if (episode == null) return NotFound();
            Methods.DeleteImage("episodes", _webHostEnvironment.WebRootPath, episode.EpisodeImage);
            _episodeService.Delete(episode);
            return RedirectToAction(nameof(Index));
        }        
    }
}
