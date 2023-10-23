using System.ComponentModel.DataAnnotations;

namespace HDF.PresentationLayer.Backend.ViewModels.Account
{
    public class LoginVM
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool Check { get; set; }
    }
}
