using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MobileApps.Core.Helpers;
using MobileApps.DAL.Repository.SQLite;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Models;
using SQLite.Net.Async;
using Xamarin.Forms;

[assembly: Dependency(typeof(PotentialStudentEventRepository))]
namespace MobileApps.DAL.Repository.SQLite
{
	public class PotentialStudentEventRepository : IPotentialStudentEventRepository
	{

		private static readonly AsyncLock Locker = new AsyncLock();
		private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();

		public async Task AddPotentialStudentEventAsync(IList<PotentialStudentEvent> potentialStudent)
		{
			using (await Locker.LockAsync())
			{
				await Database.InsertAllAsync(potentialStudent);
			}
		}

		public async Task AddPotentialStudentEventAsync(PotentialStudentEvent potentialStudent)
		{
			using (await Locker.LockAsync())
			{
				await Database.InsertAsync(potentialStudent);
			}
		}

		public async Task DeletePotentialStudentEventAsync(PotentialStudentEvent potentialStudent)
		{
			try
			{
				using (await Locker.LockAsync())
				{
					string query =
						"DELETE FROM PotentialStudentEvent WHERE FirstName ='"
						+ potentialStudent.FirstName + "' AND LastName ='" +
										  potentialStudent.LastName + "'";

					await Database.QueryAsync<PotentialStudentEvent>(query);
					Debug.WriteLine(potentialStudent.FirstName + "" + potentialStudent.LastName + " has been removed from SQLite Database");
				}
			}

			catch (Exception ex)
			{
				Debug.WriteLine("Student: " + potentialStudent.FirstName + " " +
								potentialStudent.LastName +
								" not deleted from SQLite Database. WARNING: Potential Duplicate.");
			}

		}

		public async Task<IList<PotentialStudentEvent>> GetPotentialStudentEventByOrganizationAsync(Organization organizationId)
		{
			using (await Locker.LockAsync())
			{
				return await Database.Table<PotentialStudentEvent>().ToListAsync();
			}
		}
	}
}
