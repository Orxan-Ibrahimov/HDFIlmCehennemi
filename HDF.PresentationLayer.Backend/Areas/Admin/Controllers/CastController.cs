using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace HDF.PresentationLayer.Backend.Areas.Admin.Controllers
{
    [Area("admin")]    
    public class CastController : Controller
    {
        private readonly ICastService _castService;
        private readonly IWebHostEnvironment _env;

        public CastController(ICastService castService, IWebHostEnvironment env)
        {
            _castService = castService;
            _env = env;
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

                if (!cast.Photo.ContentType.Contains("image")) return View(cast);
                if (cast.Photo.Length / 1024 > 1000) return View(cast);
                string environment = _env.WebRootPath;
                cast.Image = Methods.RenderImage(cast.Photo, cast.Name, "casts", environment);

                if (string.IsNullOrEmpty(cast.Image))
                {
                    ModelState.AddModelError("Image", "Image was incorrect");
                    return View(cast);
                }

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

                Cast oldCast = _castService.GetById(id);
                if (!cast.Photo.ContentType.Contains("image")) return View(cast);
                if (cast.Photo.Length / 1024 > 1000) return View(cast);
                string environment = _env.WebRootPath;
                cast.Image = Methods.UpdateImage(cast.Photo, cast.Name, "casts", environment, oldCast.Image);

                if (string.IsNullOrEmpty(cast.Image))
                {
                    ModelState.AddModelError("Image", "Image was incorrect");
                    return View(cast);
                }

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
            Methods.DeleteImage("casts",_env.WebRootPath,cast.Image);
            _castService.Delete(cast);
            return RedirectToAction(nameof(Index));
        }
    }
}
