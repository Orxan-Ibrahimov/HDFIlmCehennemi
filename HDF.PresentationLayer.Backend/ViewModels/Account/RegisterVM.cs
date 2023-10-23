using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HDF.PresentationLayer.Backend.ViewModels.Account
{
    public class RegisterVM
    {
        public AppUser User { get; set; }
        [ValidateNever]
        public List<AppRole> Roles { get; set; }
        public AppRole Role { get; set; }
        [ValidateNever]
        public List<SelectListItem> RoleList { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool Check { get; set; }
    }
}
