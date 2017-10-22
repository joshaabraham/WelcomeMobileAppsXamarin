using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Services;

namespace MobileApps.BL.DataServices
{
	public class InfoLeadDS : IInfoLeadDataService
	{
		private readonly IInfoLeadAPIRepository _infoLeadAPIRepo;

		public InfoLeadDS(IInfoLeadAPIRepository infoLeadAPIRepo)
		{
			_infoLeadAPIRepo = infoLeadAPIRepo;
		}

		#region API Properties & Methods
		public List<InfoLead> InfoLead { get; set; }

		/// <summary>
		/// Returns a list of Matched Leads From CRM.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and an email.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<List<InfoLead>> GetInfoLeadFromCRMByOrganizationAsync(Organization organization, string email, string CRMConnectionString = "kiosk.collegelasalle.com")
		{
            return await _infoLeadAPIRepo.GetInfoLeadByOrganizationAsync(organization, email, CRMConnectionString);
		}
		#endregion
	}
}
