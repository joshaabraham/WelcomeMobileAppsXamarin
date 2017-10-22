using MobileApps.Core.Helpers;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Models;
using SQLite.Net.Async;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApps.DAL.Repository.SQLite
{
    public class ProgramsRepository : IProgramsRepository
	{
		private static readonly AsyncLock Locker = new AsyncLock();
		private SQLiteAsyncConnection Database { get; } = DependencyService.Get<ISqLite>().GetAsyncConnection();



		public async Task AddProgramsAsync(IList<Program> programs)
		{
			using (await Locker.LockAsync())
			{
				await Database.InsertAllAsync(programs);
			}
		}

		public async Task<IList<Program>> GetProgramsByCampusAndOrganization(Organization organization, Campus campus, string language)
		{
			using (await Locker.LockAsync())
			{
				return await Database.Table<Program>().Where(c => c.OrganisationId == organization.Id && c.CampusKey == campus.Name && c.Language == language).ToListAsync();
			}

		}

		public async Task<IList<Program>> GetProgramsByOrganizationAsync(Organization organizationId)
		{
			using (await Locker.LockAsync())
			{
				return await Database.Table<Program>().Where(c => c.OrganisationId == organizationId.Id).ToListAsync();
			}
		}




	}
}
