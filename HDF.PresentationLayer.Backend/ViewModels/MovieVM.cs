using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HDF.PresentationLayer.Backend.ViewModels
{
    public class MovieVM
    {
        
        public Movie Movie { get; set; }
        [ValidateNever]
        public List<SelectListItem> FilmOrSerieList { get; set; }
        [ValidateNever]
        public List<FilmOrSerie> FilmOrSeries { get; set; }
        public List<Category> Categories { get; set; }
        [ValidateNever]
        public List<Country> Countries { get; set; }
        [ValidateNever]       
        public List<SelectListItem> CountryList { get; set; }
        [ValidateNever]
        public List<Movie> Movies { get; set; }
        public int[] categories { get; set; }
    }
}
