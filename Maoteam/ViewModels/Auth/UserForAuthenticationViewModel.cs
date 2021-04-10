using System.ComponentModel.DataAnnotations;

namespace Maoteam.ViewModels.Auth
{
    public class UserForAuthenticationViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
