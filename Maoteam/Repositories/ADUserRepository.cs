using Maoteam.Configuration;
using Maoteam.Models.AdUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maoteam.Repositories
{
    public class ADUserRepository
    {
        readonly IADConnection _connection;
        public ADUserRepository(IADConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = new List<User>();
            using var connection = await _connection.GetConnection();

            //var uri = new Uri(_connection.Options.DefaultDomain);
            //var scheme = uri.Scheme; // == "LDAP" or "LDAPS" usually
            //var domainHost = uri.Host;
            //var path = uri.AbsolutePath.TrimStart('/');

            var dn = string.Join(",", _connection.Options.Domain.Split(".").Select(part => $"dc={part}"));

            var entries = await connection.SearchAsync(dn, "(&(objectCategory=person)(objectClass=user)(sAMAccountName=*)(!(cn=*O*)))");

            foreach (var entry in entries)
            {
                var user = new User
                {
                    UserName = entry.DirectoryAttributes["samAccountName"]?.ToString()
                };
                users.Add(user);
            }

            return users;
        }
    }
}
