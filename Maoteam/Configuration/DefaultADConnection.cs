using LdapForNet;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using static LdapForNet.Native.Native;

namespace Maoteam.Configuration
{
    public class DefaultADConnection : IADConnection
    {
        public ADConnectionOptions Options { get; }

        public DefaultADConnection(IOptions<ADConnectionOptions> options)
        {
            Options = options.Value;
        }

        public async Task<LdapConnection> GetConnection()
        {
            var connection = new LdapConnection();
            connection.Connect(Options.Host, Options.Port);
            await connection.BindAsync(LdapAuthMechanism.SIMPLE, Options.User, Options.Password);

            return connection;
        }
    }
}
