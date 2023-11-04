using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HDF.PresentationLayer.Backend.Areas.Admin.ViewModels
{
    public class EpisodeVM
    {        
        public Episode Episode { get; set; }
        [ValidateNever]
        public List<Season>? Seasons { get; set; }
        [ValidateNever]
        public List<SelectListItem>? SeasonList { get; set; }
        [ValidateNever]
        public string EpisodeImage { get; set; }
    }
}
