using MaoTeam.Configuration;
using MaoTeam.Models;
using MaoTeam.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaoTeam.Services
{
    public class AdAdminUserService
    {
        readonly IAdConnection _connection;

        public AdAdminUserService(IAdConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<AdUser>> GetAll()
        {
            var users = new List<AdUser>();

            using var ldapConnection = await _connection.GetRootUserConnection();

            var dn = LdapUtils.GetDnFromHostname(_connection.Options.Domain);

            var entries = await ldapConnection.SearchAsync(dn, "(&(objectCategory=person)(objectClass=user)(sAMAccountName=*))");

            foreach (var entry in entries)
            {
                var user = UsersFactory.CreateAdUser(entry);
                users.Add(user);
            }

            return users;
        }
    }
}
