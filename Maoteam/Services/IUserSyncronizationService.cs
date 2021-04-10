using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maoteam.Services
{
    public interface IUserSynchronizationService
    {
        Task Sync();
    }
}
