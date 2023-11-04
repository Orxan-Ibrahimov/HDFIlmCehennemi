using HDF.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace HDF.PresentationLayer.Backend.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
