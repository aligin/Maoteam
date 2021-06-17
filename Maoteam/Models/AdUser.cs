using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaoTeam.Models
{
    public class AdUser
    {
        /// <summary>
        /// Example: petrenkoaa
        /// field: sAMAccountName
        /// </summary>
        public string SamAccountName { get; set; }

        /// <summary>
        /// Example: 
        /// field: objectSid
        /// </summary>
        public string ObjectSid { get; set; }

        /// <summary>
        /// Example: Петренко Александр Александрович
        /// field: cn
        /// </summary>
        public string Cn { get; set; }

        /// <summary>
        /// Example: CN=Петренко Александр Александрович,OU=staff,DC=monqlab,DC=com
        /// field: distinguishedName
        /// alternate: dn
        /// </summary>
        public string DistinguishedName { get; set; }

        /// <summary>
        /// Example: Петренко
        /// field: sn
        /// </summary>
        public string Sn { get; set; }

        /// <summary>
        /// Example: Александр
        /// field: givenName
        /// </summary>
        public string GivenName { get; set; }

        /// <summary>
        /// Example: 20210329175011.0Z
        /// field: whenCreated
        /// </summary>
        public DateTimeOffset WhenCreated { get; set; }

        /// <summary>
        /// Example: Петренко Александр Александрович
        /// field: displayName
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Example: Петренко Александр Александрович
        /// field: name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Example: GUID
        /// field: objectGUID
        /// </summary>
        public Guid ObjectGUID { get; set; }

        /// <summary>
        /// Example: 0
        /// field: badPwdCount
        /// </summary>
        public int BadPwdCount { get; set; }

        /// <summary>
        /// Example: 9223372036854775807
        /// field: accountExpires
        /// </summary>
        public long AccountExpires { get; set; }

        /// <summary>
        /// Example: petrenkoaa@monqlab.com
        /// field: userPrincipalName
        /// </summary>
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Example: [
        /// CN=jira-software-users,OU=JiraGroups,OU=structure,DC=monqlab,DC=com
        /// CN=vpnaccess,OU=structure,DC=monqlab,DC=com
        /// ]
        /// field: memberOf
        /// </summary>
        public IEnumerable<string> MemberOf { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Example: 132624228593287360
        /// field: lastLogon
        /// </summary>
        public DateTimeOffset LastLogon { get; set; }

        /// <summary>
        /// Example: +7(917)556-65-05
        /// field: telephoneNumber
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Example: user@example.com
        /// field: mail
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Example: 20210409083642.0Z
        /// field: whenChanged
        /// </summary>
        public DateTimeOffset WhenChanged { get; set; }
    }
}
