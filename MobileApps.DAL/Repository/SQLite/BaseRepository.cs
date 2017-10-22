using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Core.Helpers;
using MobileApps.Models.Models;
using SQLite.Net.Async;
using Xamarin.Forms;

namespace MobileApps.DAL.Repository.SQLite
{
    public class BaseRepository<T> where T : BaseModel
    {
        public BaseRepository()
        {
        }

        private static readonly AsyncLock Locker = new AsyncLock();
        private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

        public async Task AddEntitiesAsync(IList<T> obj)
        {
            using (await Locker.LockAsync())
            {
                await Database.InsertAllAsync(obj);
            }
        }

        public async Task<IList<T>> GetAllEntitiesAsync()
        {
            return await Database.Table<T>().ToListAsync();
        }

        public async Task<IList<T>> GetEntitiesByOrganizationAndLanguageAsync(String Organisation, String Language)
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<T>()
                                     .Where(
                                         e => e.Name == Organisation &&
                                         e.Language == Language)
                                     .ToListAsync();
            }
        }

        public async Task<IList<T>> GetEntitiesByOrganizationIDAndLanguageAsync(Guid OrganisationID, string Language)
        {
            using (await Locker.LockAsync())
            {
                return await Database.Table<T>()
                                     .Where(
                                         e => e.OrganizationId == OrganisationID &&
                                         e.Language == Language)
                                     .ToListAsync();
            }

        }
    }
}
