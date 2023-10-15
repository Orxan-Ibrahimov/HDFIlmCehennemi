using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class FilmOrSerieController : Controller
    {
        private readonly IFilmOrSerieService _filmOrSerieService;

        public FilmOrSerieController(IFilmOrSerieService filmOrSerieService)
        {
            _filmOrSerieService = filmOrSerieService;
        }

        // GET: FilmOrSerie
        public ActionResult Index()
        {
           List<FilmOrSerie> filmOrSeries = _filmOrSerieService.GetList();
            if (filmOrSeries == null) return NotFound();
            return View(filmOrSeries);
        }

        // GET: FilmOrSerie/Details/5
        public ActionResult Details(int id)
        {
            FilmOrSerie filmOrSerie = _filmOrSerieService.GetById(id);
            if (filmOrSerie == null) return NotFound();
            return View(filmOrSerie);
        }

        // GET: FilmOrSerie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmOrSerie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmOrSerie filmOrSerie)
        {
            try
            {
                if (filmOrSerie == null) return NotFound();
                if(!ModelState.IsValid) return View(filmOrSerie);
                _filmOrSerieService.Insert(filmOrSerie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmOrSerie/Edit/5
        public ActionResult Edit(int id)
        {
            FilmOrSerie filmOrSerie = _filmOrSerieService.GetById(id);
            if (filmOrSerie == null) return NotFound();
            return View(filmOrSerie);
        }

        // POST: FilmOrSerie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FilmOrSerie filmOrSerie)
        {
            try
            {
                if(filmOrSerie.Id !=  id) return BadRequest();
                if (!ModelState.IsValid) return View(filmOrSerie);
                _filmOrSerieService.Update(filmOrSerie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilmOrSerie/Delete/5
        public ActionResult Delete(int id)
        {
            FilmOrSerie filmOrSerie = _filmOrSerieService.GetById(id);
            if (filmOrSerie == null) return NotFound();
            _filmOrSerieService.Delete(filmOrSerie);
            return RedirectToAction(nameof(Index));
        }       
    }
}
