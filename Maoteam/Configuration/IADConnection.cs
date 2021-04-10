using LdapForNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maoteam.Configuration
{
    public interface IADConnection
    {
        ADConnectionOptions Options { get; }

        Task<LdapConnection> GetConnection();
    }
}
