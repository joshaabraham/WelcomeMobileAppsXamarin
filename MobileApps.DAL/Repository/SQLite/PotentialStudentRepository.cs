using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;
using MobileApps.Core.Helpers;
using Xamarin.Forms;
using SQLite.Net.Async;
using MobileApps.Models.Contracts.Repository.SQLite;
using System;
using System.Diagnostics;
using MobileApps.DAL.Repository.SQLite;

[assembly: Dependency(typeof(PotentialStudentRepository))]
namespace MobileApps.DAL.Repository.SQLite
{
	public class PotentialStudentRepository : IPotentialStudentRepository
	{

		private static readonly AsyncLock Locker = new AsyncLock();
		private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

		public async Task AddPotentialStudentAsync(IList<PotentialStudent> potentialStudent)
		{
			using (await Locker.LockAsync())
			{
				await Database.InsertAllAsync(potentialStudent);
			}
		}

		public async Task AddPotentialStudentAsync(PotentialStudent potentialStudent)
		{
			using (await Locker.LockAsync())
			{
				await Database.InsertAsync(potentialStudent);
			}
		}

		public async Task DeletePotentialStudentAsync(PotentialStudent potentialStudent)
		{
			try
			{
				using (await Locker.LockAsync())
				{
					// ADD LOGIC TO HANDLE SQL INJECTION
					string query =
						"DELETE FROM PotentialStudent WHERE FirstName ='"
						+ potentialStudent.FirstName + "' AND LastName ='" +
										  potentialStudent.LastName +
						"' AND VisitGoalID =" + potentialStudent.VisitGoalID;
					await Database.QueryAsync<PotentialStudent>(query);
				}
			}

			catch (Exception ex)
			{
				Debug.WriteLine("Student: " + potentialStudent.FirstName + " " +
								potentialStudent.LastName +
								" not deleted from SQLite Database. WARNING: Potential Duplicate.");
			}

		}

		public async Task<IList<PotentialStudent>> GetPotentialStudentByOrganizationAsync(Organization organizationId)
		{
			using (await Locker.LockAsync())
			{
				return await Database.Table<PotentialStudent>().Where(c => c.OrganizationId == organizationId.Id).ToListAsync();
			}
		}
	}
}
