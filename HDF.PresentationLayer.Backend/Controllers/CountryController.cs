using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IWebHostEnvironment _env;

        public CountryController(ICountryService countryService, IWebHostEnvironment env)
        {
            _countryService = countryService;
            _env = env;
        }

        // GET: CountryController
        public ActionResult Index()
        {
           List<Country> countries = _countryService.GetList();

            if (countries == null) return NotFound();

            return View(countries);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            Country country = _countryService.GetById(id);
            if(country == null) return NotFound();

            return View(country);
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Country country)
        {
            try
            {
                if (country == null) return NotFound();

                if (!ModelState.IsValid) return View(country);

                if(!country.Photo.ContentType.Contains("image")) return View(country);
                if (country.Photo.Length / 1024 > 1000) return View(country);
                string environment = _env.WebRootPath;
                country.Image = Methods.RenderImage(country.Photo, country.ShortName, "countries", environment);

               if (string.IsNullOrEmpty(country.Image))
                {
                    ModelState.AddModelError("Image", "Image was incorrect");
                    return View(country);
                }
              
                _countryService.Insert(country);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _countryService.GetById(id);
            if (country == null) return NotFound();
            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Country country)
        {

            try
            {
                if (country.Id != id) return BadRequest();
                    
                if(!ModelState.IsValid) return View(country);

                Country oldCountry = _countryService.GetById(id);
                if (!country.Photo.ContentType.Contains("image")) return View(country);
                if (country.Photo.Length / 1024 > 1000) return View(country);
                string environment = _env.WebRootPath;
                country.Image = Methods.UpdateImage(country.Photo, country.ShortName, "countries", environment,oldCountry.Image);

                if (string.IsNullOrEmpty(country.Image))
                {
                    ModelState.AddModelError("Image", "Image was incorrect");
                    return View(country);
                }

                _countryService.Update(country);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(country);
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _countryService.GetById(id);
            if (country == null) return NotFound();
            Methods.DeleteImage("countries",_env.WebRootPath,country.Image);
            _countryService.Delete(country);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
