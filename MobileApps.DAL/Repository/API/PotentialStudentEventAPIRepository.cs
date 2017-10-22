using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Models;

namespace MobileApps.DAL.Repository.API
{
	public class PotentialStudentEventAPIRepository : BaseAPIRepository, IPotentialStudentEventAPIRepository
	{
		public string Url { get; set; }
		public async Task<List<PotentialStudentEvent>> GetPotentialStudentEventByOrganizationAsync(Organization organization, string language, string CRMConnectionString = "kiosk.collegelasalle.com")
		{
			if (string.IsNullOrEmpty(organization?.Name)) return null;
			Url = "http://" + CRMConnectionString + "" + organization.Name +
				  "" + language;
			return await GetAsync<List<PotentialStudentEvent>>(Url);
		}

		public async Task<bool> PostLead(PotentialStudentEvent lead, string baseAddress, string actionUrl)
		{
			return await Post(lead, baseAddress, actionUrl);
		}




	}
}
