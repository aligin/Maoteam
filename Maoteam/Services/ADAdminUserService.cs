using LdapForNet;
using Maoteam.Configuration;
using Maoteam.Models;
using Maoteam.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Maoteam.Services
{
    public class ADAdminUserService
    {
        readonly IADConnection _connection;

        public ADAdminUserService(IADConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<AdUser>> GetAll()
        {
            var users = new List<AdUser>();

            using var _ldapConnection = await _connection.GetRootUserConnection();

            //var uri = new Uri(_connection.Options.DefaultDomain);
            //var scheme = uri.Scheme; // == "LDAP" or "LDAPS" usually
            //var domainHost = uri.Host;
            //var path = uri.AbsolutePath.TrimStart('/');

            var dn = DnFromDomain(_connection.Options.Domain);

            var entries = await _ldapConnection.SearchAsync(dn, "(&(objectCategory=person)(objectClass=user)(sAMAccountName=*)(!(cn=*O*)))");

            foreach (var entry in entries)
            {
                var user = new AdUser
                {
                    SamAccountName = entry.DirectoryAttributes["sAMAccountName"].GetValue<string>(),
                    ObjectSid = LdapSidConverter.ParseFromBytes(entry.DirectoryAttributes["ObjectSID"].GetValue<byte[]>())
                };
                users.Add(user);
            }

            return users;
        }

        string DnFromDomain(string domain)
        {
            return string.Join(",", domain.Split(".").Select(part => $"dc={part}"));
        }
    }
}
