using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileApps.Core.Helpers;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace MobileApps.DAL.Repository.SQLite
{
    public class SemesterRepository : ISemesterRepository 
    {
		private static readonly AsyncLock Locker = new AsyncLock();
		private SQLiteConnection Database { get; } = DependencyService.Get<ISqLite>().GetConnection();
		public async Task AddSemesterAsync(IList<Semester> obj)
		{
			using (await Locker.LockAsync())
			{
			     Database.InsertAll(obj);
			}
		}

		public async Task<IList<Semester>> GetSemesterByOrganizationAsync(String Organisation, String Language)
		{
			using (await Locker.LockAsync())
			{
                return  (Database.Table<Semester>()).ToList();
			}
		}
    }
}
