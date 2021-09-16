using System;

namespace MaoTeam.ViewModels.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }

        /// <summary>
        /// Пользовательский email.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Имя аккаунта (уникальное).
        /// </summary>
        public string UserName { get; set; } = default!;
    }
}
