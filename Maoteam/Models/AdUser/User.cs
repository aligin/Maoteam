using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Maoteam.Models.AdUser
{
    public class User: IdentityUser<Guid>
    {
        public Guid Uid { get; set; }

        ///// <summary>
        ///// Пользовательский email.
        ///// </summary>
        //public string Email { get; set; }

        ///// <summary>
        ///// Имя аккаунта (уникальное).
        ///// </summary>
        //public string UserName { get; set; }

        /// <summary>
        /// Имя отображаемое (формируется с имени и фамилии).
        /// </summary>
        public string DisplayName
        {
            get
            {
                return String.Format("{0} {1} {2}", Surname, GivenName, MiddleName);
            }
        }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Адрес сотрудника.
        /// </summary>
        //public Address Address { get; set; }

        #region Telephones
        /// <summary>
        /// Телефоны личные.
        /// </summary>
        //public Telephone PrivateTelephone { get; set; } = new Telephone();

        /// <summary>
        /// Ip телефоны.
        /// </summary>
        //public Telephone IpTelephone { get; set; } = new Telephone();

        /// <summary>
        /// Рабочие телефоны.
        /// </summary>
        //public Telephone WorkingTelephone { get; set; } = new Telephone();
        #endregion

        /// <summary>
        /// Должность.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Относительный путь к файлу с фотографией.
        /// </summary>
        public string PhotoFile { get; set; }

        /// <summary>
        /// Отдел.
        /// </summary>
        //public Department Department { get; set; }

        /// <summary>
        /// Дата создания аккаунта.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// True - если пользователь заблокирован.
        /// </summary>
        public bool IsBlocked { get; set; } = false;

        /// <summary>
        /// Группы безопасности, в которых участвует пользователь.
        /// </summary>
        //public IList<string> Groups { get; set; } = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
        }
    }
}
