using Microsoft.AspNetCore.Identity;
using System;

namespace MaoTeam.Models.LocalUsers
{
    public class User : IdentityUser<string>
    {
        /// <summary>
        /// Имя отображаемое (формируется с имени и фамилии).
        /// </summary>
        public string DisplayName => $"{LastName} {FirstName} {MiddleName}";

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        //public DateTimeOffset? BirthDate { get; set; }

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
        /// Отдел.
        /// </summary>
        //public Department Department { get; set; }

        /// <summary>
        /// Дата создания аккаунта.
        /// </summary>
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Дата изменения аккаунта.
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Количество неудачных попыток входа
        /// </summary>
        public int FailedLoginAppempts { get; set; }

        /// <summary>
        /// Время последнего захода в систему
        /// </summary>
        public DateTimeOffset? LastLogon { get; set; }


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
