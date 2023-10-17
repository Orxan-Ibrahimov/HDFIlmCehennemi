using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        // GET: CountryController
        public ActionResult Index()
        {
            List<Cast> casts = _castService.GetList();

            if (casts == null) return NotFound();

            return View(casts);
        }

        // GET: CastController/Details/5
        public ActionResult Details(int id)
        {
            Cast cast = _castService.GetById(id);
            if (cast == null) return NotFound();

            return View(cast);
        }

        // GET: CastController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CastController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cast cast)
        {
            try
            {
                if (cast == null) return NotFound();

                if (!ModelState.IsValid)
                    return View(cast);

                _castService.Insert(cast);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cast);
            }
        }

        // GET: CastController/Edit/5
        public ActionResult Edit(int id)
        {
            Cast cast = _castService.GetById(id);
            if (cast == null) return NotFound();

            return View(cast);
        }

        // POST: CastController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cast cast)
        {
            try
            {
                if (id != cast.Id) return NotFound();

                if (!ModelState.IsValid) return View(cast);
                _castService.Update(cast);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            Cast cast = _castService.GetById(id);
            if (cast == null) return NotFound();

            _castService.Delete(cast);
            return RedirectToAction(nameof(Index));
        }
    }
}
