using LdapForNet;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using static LdapForNet.Native.Native;

namespace MaoTeam.Configuration
{
    public class DefaultAdConnection : IAdConnection
    {
        public AdConnectionOptions Options { get; }

        public DefaultAdConnection(IOptions<AdConnectionOptions> options)
        {
            Options = options.Value;
        }

        public Task<LdapConnection> GetRootUserConnection()
        {
            return GetConnection(Options.User, Options.Password);
        }

        public async Task<LdapConnection> GetConnection(string username, string password)
        {
            var connection = new LdapConnection();
            connection.Connect(Options.Host, Options.Port);

            var email = MakeEmailFromUsername(username);

            await connection.BindAsync(LdapAuthMechanism.SIMPLE, email, password);

            return connection;
        }

        string MakeEmailFromUsername(string username)
        {
            if (username.Contains("@"))
                return username;
            else
                return $"{username}@{Options.Domain}";
        }
    }
}
