using MobileApps.Core.Helpers;
using MobileApps.DAL.Repository;
using MobileApps.Models.Contracts.Repository;
using MobileApps.Models.Models;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(OrganisationRepository))]
namespace MobileApps.DAL.Repository
{
    class OrganisationRepository : IOrganizationRepository
    {
        private static readonly AsyncLock Locker = new AsyncLock();

        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

        public async Task AddOrganizationesAsync(IList<Organization> organizations)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(organizations);
            }
        }

        public async Task<IList<Organization>> GetAllOrganizationesAsync()
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<Organization>().ToListAsync();
            }
        }

        public async Task<IList<Organization>> GetOrganizationesByNameAsync(string organization)
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<Organization>().Where(c => c.Name == organization).ToListAsync();
            }
        }
    }
}
