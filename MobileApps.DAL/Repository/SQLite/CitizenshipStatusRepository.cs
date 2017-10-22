
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite.Net.Async;
using Xamarin.Forms;
using MobileApps.Core.Helpers;
using MobileApps.Models.Contracts.Repository;
using MobileApps.DAL.Repository;
using MobileApps.Models.Models;
using MobileApps.DAL.Repository.API;

[assembly: Dependency(typeof(CitizenshipStatusRepository))]
namespace MobileApps.DAL.Repository.SQLite
{
    public class CitizenshipStatusRepository : ICitizenshipStatusRepository
    {
        private static readonly AsyncLock Locker = new AsyncLock();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

        public async Task AddCitizenshipStatusAsync(IList<CitizenshipStatus> citizenshipStatus)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(citizenshipStatus);
            }

        }

        public async Task<IList<CitizenshipStatus>> GetAllCitizenshipStatusAsync()
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<CitizenshipStatus>().ToListAsync();
            }
        }

        public async Task<IList<CitizenshipStatus>> GetCitizenshipStatusByOrganizationAsync(Organization organizationId)
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<CitizenshipStatus>().Where(c => c.OrganizationId == organizationId.Id).ToListAsync();
            }
        }

        public Task<IList<CitizenshipStatus>> GetCitizenshipStatusByOrganizationAsync(string Organisation, string Language)
        {
            throw new NotImplementedException();
        }
    }
}
