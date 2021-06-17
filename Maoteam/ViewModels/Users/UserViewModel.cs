using System;

namespace MaoTeam.ViewModels.Users
{
    public class UserViewModel
    {
        public Guid Uid { get; set; }

        /// <summary>
        /// Пользовательский email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Имя аккаунта (уникальное).
        /// </summary>
        public string UserName { get; set; }
    }
}
