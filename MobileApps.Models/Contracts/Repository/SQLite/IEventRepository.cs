using MobileApps.Models.Models;
using MobileApps.DAL.Repository.SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace MobileApps.Models.Contracts.Repository.SQLite
{
    public interface IEventRepository : IBaseRepo<Event>
    {
	}
}
