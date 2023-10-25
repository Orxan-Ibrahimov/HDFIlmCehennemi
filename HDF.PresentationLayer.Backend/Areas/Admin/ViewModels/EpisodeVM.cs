using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HDF.PresentationLayer.Backend.ViewModels
{
    public class EpisodeVM
    {
        public Episode Episode { get; set; }
        [ValidateNever]
        public List<Movie> Movies { get; set; }
        [ValidateNever]
        public List<SelectListItem> MovieList { get; set; }
        [ValidateNever]
        public string EpisodeImage { get; set; }
    }
}
