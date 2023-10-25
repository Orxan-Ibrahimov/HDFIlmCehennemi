using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HDF.PresentationLayer.Backend.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LanguageController : Controller
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: LanguageController
        public ActionResult Index()
        {
            List <Language> languages = _languageService.GetList();
            if(languages == null) return NotFound();
            return View(languages);
        }

        // GET: LanguageController/Details/5
        public ActionResult Details(int id)
        {
            Language language = _languageService.GetById(id);
            if(language == null) return NotFound();
            return View(language);
        }

        // GET: LanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Language language)
        {
            try
            {
                if(language == null) return NotFound();
                if(!ModelState.IsValid) return View(language);
                _languageService.Insert(language);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            Language language = _languageService.GetById(id);
            if(language == null) return NotFound();
            return View(language);
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Language language)
        {
            try
            {
                if (language.Id != id) return BadRequest();
                if (!ModelState.IsValid) return View(language);
                _languageService.Update(language);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            Language language = _languageService.GetById(id);
            if(language == null) return NotFound();
            _languageService.Delete(language);
            return RedirectToAction(nameof(Index));
        }       
    }
}
