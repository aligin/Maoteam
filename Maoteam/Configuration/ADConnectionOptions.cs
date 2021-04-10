namespace Maoteam.Configuration
{
    public class ADConnectionOptions
    {
        public string Host { get; set; }

        public int Port { get; set; }
        public string User { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the default domain.
        /// </summary>
        /// <example>example.com</example>
        public string Domain { get; set; }
    }
}
