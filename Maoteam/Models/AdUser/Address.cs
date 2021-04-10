namespace Maoteam.Models.AdUser
{
    /// <summary>
    /// Адрес сотрудника.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Страна.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Регион.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Конечный адрес (улица, дом/кв.).
        /// </summary>
        public string HomeAddress { get; set; }
    }
}
