using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.DAL.Repository.API;
using MobileApps.DAL.Repository.SQLite;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Services;
using MobileApps.Models.Contracts.Repository.SQLite;

namespace MobileApps.BL.DataServices
{
	public class PotentialStudentDS : IPotentialStudentDataService
	{
		private readonly IPotentialStudentAPIRepository _potentialStudentAPIRepo;
		private readonly IPotentialStudentRepository _potentialStudentSQLiteRepo;

		public PotentialStudentDS(PotentialStudentAPIRepository potentialStudentAPIRepo,
										   PotentialStudentRepository potentialStudentSQLiteRepo)
		{
			_potentialStudentAPIRepo = potentialStudentAPIRepo;
			_potentialStudentSQLiteRepo = potentialStudentSQLiteRepo;
		}

		#region SQLite Methods

		/// <summary>
		/// Add a list of Potential Students to SQLite Database.
		/// </summary>
		/// <param name="request">A List of Potential Students.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddPotentialStudentToSQLiteAsync(IList<PotentialStudent> potentialStudent)
		{
			await _potentialStudentSQLiteRepo.AddPotentialStudentAsync(potentialStudent);
		}

		/// <summary>
		/// Add a Potential Student to SQLite Database.
		/// </summary>
		/// <param name="request">A Potential Student.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddPotentialStudentToSQLiteAsync(PotentialStudent potentialStudent)
		{
			await _potentialStudentSQLiteRepo.AddPotentialStudentAsync(potentialStudent);
		}

		/// <summary>
		/// Returns a list of Objectives from CRM.
		/// </summary>
		/// <param name="request">A List of Organizations(ie. Montreal, Austrailia, Maghreb, etc ... ) and Languages(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<PotentialStudent>> GetPotentialStudentFromSQLiteByOrganizationAsync(Organization organizationId)
		{
			return await _potentialStudentSQLiteRepo.GetPotentialStudentByOrganizationAsync(organizationId);
		}

		#endregion
		#region API Properties & Methods
		public List<PotentialStudent> PotentialStudent { get; set; }

		/// <summary>
		/// Posts a potential student to CRM and returns a boolean based on successful POST.
		/// </summary>
		/// <param name="request">A potential student, base address(ie.http://kiosk.lasallecollege.com/CRMData.svc/) and a URL action (ie. RegisterLead?ApiKey=xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<bool> AddPotentialStudentToCRM(PotentialStudent lead, string baseAddress, string actionUrl)
		{
			return await _potentialStudentAPIRepo.PostLead(lead, baseAddress, actionUrl);
		}
		#endregion

	}
}
