using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileApps.Models.Models;

namespace MobileApps.Models.Contracts.Services
{
    public interface ISyncService
    {
        Task Execute(List<Organization> organizations, List<string> languages);
    }
}
