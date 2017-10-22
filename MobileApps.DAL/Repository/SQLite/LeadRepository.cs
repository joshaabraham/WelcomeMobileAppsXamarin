using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite.Net.Async;
using MobileApps.Models.Models;
using MobileApps.DAL.Repository;
using MobileApps.Core.Helpers;
using MobileApps.Models.Contracts.Repository;
using MobileApps.DAL.Repository.SQLite;
using MobileApps.Models.Contracts.Repository.SQLite;

[assembly: Dependency(typeof(LeadRepository))]
namespace MobileApps.DAL.Repository.SQLite
{
    public class LeadRepository : ILeadRepository
    {
        private static readonly AsyncLock Locker = new AsyncLock();

        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

        public async Task<IList<Lead>> GetAllLeadsAsync()
        {
            try
            {
                using (await Locker.LockAsync())
                {
                    return await Database.Table<Lead>().ToListAsync();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        public async Task<IList<Lead>> GetLeadsByOrganizationAsync(Organization organizationId)
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<Lead>().Where(c => c.OrganizationId == organizationId.Id).ToListAsync();
            }
        }
        public async Task<IList<Lead>> GetLeadsByEmailAsync(string email)
        {
            // USING TRANSACTIONAL SAVING 
            using (await Locker.LockAsync())
            {
                return await Database.Table<Lead>().Where(c => c.Email.Equals(email)).ToListAsync();
            }
        }
        public async Task AddLeadsAsync(IList<Lead> leads)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(leads);
            }
        }

        public async Task<IList<Lead>> GetLeadsByOrganizationAndEmailAsync(Organization organizationId, string email)
        {
            using (await Locker.LockAsync())
            {

                return await Database.Table<Lead>().Where(c => c.OrganizationId == organizationId.Id &&  c.Email == email).ToListAsync();
            }
        }

        public async Task<IList<Lead>> GetLeadsByCrmAndEmailAsync(Guid activityID, string email)
        {
            return await Database.Table<Lead>().Where(c => c.ActivityId.Equals(activityID)).ToListAsync();
        }

        public async Task SaveLeadsByCrmAsync(Guid crm, IList<Lead> Leads)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(Leads);
            }
        }

        public async Task AddLeadAsync(Lead aLead)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAsync(aLead);
            }

        }

        public async void IsImportedAsync(Lead aLead)
        {
            customType hasSent = new customType();


            //using (await Locker.LockAsync())
            //{
            //    await Database.UpdateAsync(aLead);

            //    hasSent.hasSent = (Database.UpdateAsync(aLead).IsCompleted);
            //    hasSent.activityId = Database.
            //}

            //0return hasSent;

        }

        bool ILeadRepository.IsImportedAsync(Lead activityId)
        {
            throw new NotImplementedException();
        }
    }

    public class customType
    {
        public bool hasSent;
        public Guid activityId;
    }
}
