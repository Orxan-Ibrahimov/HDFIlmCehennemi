using HDF.EntityLayer.Concrete;
using HDF.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HDF.PresentationLayer.Backend.Areas.Admin.ViewModels.Account
{
    public class RegisterVM
    {
        public AppUser User { get; set; }
        [ValidateNever]
        public List<RoleVM> Roles { get; set; }
        public Role Role { get; set; }        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool Check { get; set; }
    }
}
