using HDF.EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace HDF.PresentationLayer.Backend.ViewModels.Account
{
    public class LoginVM
    {
        public List<string>? Messages { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
