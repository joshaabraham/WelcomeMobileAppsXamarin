using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;
using MobileApps.DAL.Repository.API;
using MobileApps.DAL.Repository.SQLite;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Services;
using MobileApps.Models.Contracts.Repository.SQLite;

namespace MobileApps.BL.DataServices
{
	public class PotentialStudentEventDS : IPotentialStudentEventDataService
	{
		private readonly IPotentialStudentEventAPIRepository _potentialStudentEventAPIRepo;
		private readonly IPotentialStudentEventRepository _potentialStudentEventSQLiteRepo;

		public PotentialStudentEventDS(PotentialStudentEventAPIRepository potentialStudentEventAPIRepo,
										   PotentialStudentEventRepository potentialStudentEventSQLiteRepo)
		{
			_potentialStudentEventAPIRepo = potentialStudentEventAPIRepo;
			_potentialStudentEventSQLiteRepo = potentialStudentEventSQLiteRepo;
		}

		#region SQLite Methods

		/// <summary>
		/// Adds a potential students for Event to SQLite Database.
		/// </summary>
		/// <param name="request">A PotentialStudentEvent.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddPotentialStudentEventToSQLiteAsync(PotentialStudentEvent potentialStudent)
		{
			await _potentialStudentEventSQLiteRepo.AddPotentialStudentEventAsync(potentialStudent);
		}

		/// <summary>
		/// Adds a list of potential student for Event to SQLite Database.
		/// </summary>
		/// <param name="request">A list of PotentialStudentEvent.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddPotentialStudentEventToSQLiteAsync(IList<PotentialStudentEvent> potentialStudent)
		{
			await _potentialStudentEventSQLiteRepo.AddPotentialStudentEventAsync(potentialStudent);
		}

		/// <summary>
		/// Return all potential students for Event from SQLite Database.
		/// </summary>
		/// <param name="request">A potential student event, base address(ie.http://kiosk.lasallecollege.com/CRMData.svc/) and a URL action (ie. RegisterLead?ApiKey=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<PotentialStudentEvent>> GetPotentialStudentEventFromSQLiteByOrganizationAsync(Organization organizationId)
		{
			return await _potentialStudentEventSQLiteRepo.GetPotentialStudentEventByOrganizationAsync(organizationId);
		}
		#endregion
		#region API Properties & Methods
		public List<PotentialStudentEvent> PotentialStudent { get; set; }

		/// <summary>
		/// Posts a potential student for Event to CRM and returns a boolean based on successful POST.
		/// </summary>
		/// <param name="request">A potential student event, base address(ie.http://kiosk.lasallecollege.com/CRMData.svc/) and a URL action (ie. RegisterLead/Event?ApiKey=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<bool> AddPotentialStudentToCRM(PotentialStudentEvent lead, string baseAddress, string actionUrl)
		{
			return await _potentialStudentEventAPIRepo.PostLead(lead, baseAddress, actionUrl);
		}
		#endregion
	}
}
