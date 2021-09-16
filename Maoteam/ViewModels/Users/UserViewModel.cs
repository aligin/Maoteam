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
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Имя аккаунта (уникальное).
        /// </summary>
        public string UserName { get; set; } = default!;

        /// <summary>
        /// Полное имя пользователя.
        /// </summary>
        public string DisplayName { get; set; } = default!;

        /// <summary>
        /// Мобильный номер пользователя.
        /// </summary>
        public string PhoneNumber { get; set; } = default!;

        /// <summary>
        /// Дата создания аккаунта.
        /// </summary>
        public string CreatedAt { get; set; } = default!;

    }
}
