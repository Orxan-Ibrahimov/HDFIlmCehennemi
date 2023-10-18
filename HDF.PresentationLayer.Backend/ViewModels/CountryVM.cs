using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HDF.PresentationLayer.Backend.ViewModels
{
    public class CountryVM
    {
        public Country Country { get; set; }
        [ValidateNever]
        public string Image { get; set; }
    }
}
