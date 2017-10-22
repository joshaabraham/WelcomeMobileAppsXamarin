using MobileApps.Core.Helpers;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Models;
using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps.DAL.Repository.SQLite
{
    public class InfoLeadRepository : IInfoLeadRepository
    {
        private static readonly AsyncLock Locker = new AsyncLock();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

        public async Task AddInfoLeadAsync(IList<InfoLead> infoLead)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(infoLead);
            }
        }
    }
}
