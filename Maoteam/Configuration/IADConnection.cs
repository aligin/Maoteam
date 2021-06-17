using LdapForNet;
using System.Threading.Tasks;

namespace MaoTeam.Configuration
{
    public interface IAdConnection
    {
        AdConnectionOptions Options { get; }
        Task<LdapConnection> GetConnection(string username, string password);
        Task<LdapConnection> GetRootUserConnection();
    }
}
