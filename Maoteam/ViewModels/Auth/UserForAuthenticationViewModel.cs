using System.ComponentModel.DataAnnotations;

namespace MaoTeam.ViewModels.Auth
{
    public class UserForAuthenticationViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
