using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Areas.Admin.Controllers
{
    public class SeasonController : Controller
    {
        private readonly ISeasonService _seasonService;
        private readonly IMovieService _movieService;

        public SeasonController(ISeasonService seasonService, IMovieService movieService)
        {
            _seasonService = seasonService;
            _movieService = movieService;
        }

        // GET: SeasonController
        public ActionResult Index()
        {
            List<Season> seasons = _seasonService.GetList();
            if (seasons == null) return NotFound();
            return View(seasons);
        }

        // GET: SeasonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SeasonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeasonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SeasonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeasonController/Edit/5
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

        // GET: SeasonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeasonController/Delete/5
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
