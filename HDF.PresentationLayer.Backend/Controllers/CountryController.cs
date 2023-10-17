using HDF.BusinessLayer.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace HDF.PresentationLayer.Backend.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
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

            _countryService.Delete(country);
            return RedirectToAction(nameof(Index));
        }
       
    }
}
