using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HDF.PresentationLayer.Backend.Areas.Admin.ViewModels
{
    public class SeasonVM
    {
        public Movie? Movie { get; set; }
        public Season Season { get; set; }
        public List<Movie>? Movies { get; set; }
        public List<SelectListItem>? MovieList { get; set; }
    }
}
