using LdapForNet;
using Maoteam.Configuration;
using Maoteam.Models;
using Maoteam.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Maoteam.Services
{
    public class ADUserService
    {
        readonly IADConnection _connection;

        public ADUserService(IADConnection connection)
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

        string DnFromDomain(string domain)
        {
            return string.Join(",", domain.Split(".").Select(part => $"dc={part}"));
        }

        public async Task<AdUser?> GetIdentity(string username, string password)
        {
            using var ldapConnection = await _connection.GetConnection(username, password);

            var dn = DnFromDomain(_connection.Options.Domain);

            var entries = await ldapConnection.SearchAsync(dn, $"(&(objectCategory=person)(objectClass=user)(sAMAccountName={username}))");

            if (entries.Count == 0)
                return null;

            var firstEntry = entries.First();

            return new AdUser
            {
                SamAccountName = firstEntry.DirectoryAttributes["sAMAccountName"].GetValue<string>(),
                ObjectSid = LdapSidConverter.ParseFromBytes(firstEntry.DirectoryAttributes["ObjectSID"].GetValue<byte[]>())
            };
        }
    }
}
