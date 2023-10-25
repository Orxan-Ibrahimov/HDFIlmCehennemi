using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Controllers
{
    [Area("admin")]
    public class KindController : Controller
    {
        private readonly IKindService _kindService;

        public KindController(IKindService kindService)
        {
            _kindService = kindService;
        }

        // GET: KindController
        public ActionResult Index()
        {
            List<Kind> kinds = _kindService.GetList();
            if(kinds == null) return NotFound();
            return View(kinds);
        }

        // GET: KindController/Details/5
        public ActionResult Details(int id)
        {
            Kind kind = _kindService.GetById(id);
            if(kind == null) return NotFound();            
            return View(kind);
        }

        // GET: KindController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KindController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kind kind)
        {
            try
            {
                if (kind == null) return NotFound();
                if (!ModelState.IsValid) return View(kind);
                _kindService.Insert(kind);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KindController/Edit/5
        public ActionResult Edit(int id)
        {
            Kind kind = _kindService.GetById(id);
            if (kind == null) return NotFound();
            return View(kind);
        }

        // POST: KindController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kind kind)
        {
            try
            {
                if (kind.Id != id) return BadRequest();
                if (!ModelState.IsValid) return View(kind);
                _kindService.Update(kind);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KindController/Delete/5
        public ActionResult Delete(int id)
        {
            Kind kind = _kindService.GetById(id);
            if (kind == null) return NotFound();
            _kindService.Delete(kind);
            return RedirectToAction(nameof(Index));
        }
    }
}
