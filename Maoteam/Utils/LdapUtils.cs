using System.Linq;

namespace MaoTeam.Utils
{
    public static class LdapUtils
    {
        private const char Separator = '.';

        public static string GetDnFromHostname(string hostname)
        {
            var parts = hostname.Split(Separator);
            var dnParts = parts.Select(_ => $"dc={_}");
            return string.Join(",", dnParts);
        }
    }
}
