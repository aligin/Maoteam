using LdapForNet;
using System.Threading.Tasks;

namespace Maoteam.Configuration
{
    public interface IADConnection
    {
        ADConnectionOptions Options { get; }
        Task<LdapConnection> GetConnection(string username, string password);
        Task<LdapConnection> GetRootUserConnection();
    }
}
