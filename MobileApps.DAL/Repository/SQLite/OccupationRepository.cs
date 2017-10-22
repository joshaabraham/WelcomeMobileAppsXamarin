using MobileApps.Core.Helpers;
using MobileApps.Models.Contracts.Repository;
using MobileApps.Models.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps.DAL.Repository.SQLite
{
    class OccupationRepository : IOccupationRepository
    {
        private static readonly AsyncLock Locker = new AsyncLock();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();
        public async Task AddOccupationsAsync(IList<Occupation> organisation)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(organisation);
            }
        }
        public async Task<IList<Occupation>> GetOccupationsByOrganizationAsync(String Organisation, String Language)
        {
            using (await Locker.LockAsync())
            {
                throw new NotImplementedException();
               // return await Database.Table<Occupation>().Where(c => c.OrganizationId == organizationId).ToListAsync();
            }
        }
    }
}
