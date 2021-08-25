using System;
using System.Linq;

namespace MaoTeam.ViewModels.Auth
{
    public class AuthResponseViewModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
    }
}
