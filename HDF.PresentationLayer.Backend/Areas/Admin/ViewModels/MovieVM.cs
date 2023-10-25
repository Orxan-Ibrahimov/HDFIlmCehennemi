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
        public List<Category> Categories { get; set; }
        [ValidateNever]
        public List<Country> Countries { get; set; }
        [ValidateNever]       
        public List<SelectListItem> CountryList { get; set; }
        [ValidateNever]
        public List<Kind> Kinds { get; set; }
        [ValidateNever]
        public List<Cast> Casts { get; set; }
        [ValidateNever]
        public List<Language> Languages { get; set; }
        [ValidateNever]
        public string Image { get; set; }
        [ValidateNever]
        public List<Movie> Movies { get; set; }
        public int[]? _categories { get; set; }
        public int[]? _kinds { get; set; }       
        public int[]? _languages { get; set; }
    }
}
