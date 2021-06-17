namespace MaoTeam.Utils
{
    public static class LdapAttributesExtended
    {
        /// <summary>
        /// Example: 20210329175011.0Z
        /// field: whenCreated
        /// </summary>
        public const string WhenCreated = "whenCreated";

        /// <summary>
        /// Example: 0
        /// field: badPwdCount
        /// </summary>
        public const string BadPwdCount = "badPwdCount";

        /// <summary>
        /// Example: 9223372036854775807
        /// field: accountExpires
        /// </summary>
        public const string AccountExpires = "accountExpires";

        /// <summary>
        /// Example: 132624228593287360
        /// field: lastLogon
        /// </summary>
        public const string LastLogonTimestamp = "lastLogonTimestamp";
    }
}
