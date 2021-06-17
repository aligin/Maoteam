using LdapForNet;
using MaoTeam.Configuration;
using MaoTeam.Models;
using MaoTeam.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MaoTeam.Services
{
    public class AdUserService
    {
        readonly IAdConnection _connection;

        public AdUserService(IAdConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            try
            {
                using var connection = await _connection.GetConnection(username, password);

                return true;
            }
            catch (LdapInvalidCredentialsException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<AdUser?> GetIdentity(string username, string password)
        {
            using var ldapConnection = await _connection.GetConnection(username, password);

            var dn = LdapUtils.GetDnFromHostname(_connection.Options.Domain);

            var entries = await ldapConnection.SearchAsync(dn, $"(&(objectCategory=person)(objectClass=user)(sAMAccountName={username}))");

            if (entries.Count == 0)
                return null;

            var firstEntry = entries.First();

            return UsersFactory.CreateAdUser(firstEntry);
        }
    }
}
