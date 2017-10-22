using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Contracts.Services;

namespace MobileApps.BL.DataServices
{
	public class CampusDS : ICampusDataService
	{
		private readonly ICampusAPIRepository _campusAPIRepo;
		private readonly ICampusRepository _campusSQLRepo;

		public CampusDS(ICampusAPIRepository campusAPIRepo,
								 ICampusRepository campusSQLRepo)
		{
			_campusAPIRepo = campusAPIRepo;
			_campusSQLRepo = campusSQLRepo;
		}

		#region SQLite Methods
		/// <summary>
		/// Adds a list of Campuses to SQLite Database.
		/// </summary>
		/// <param name="request">A list of Campuses. </param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddCampusesToSQLiteDBAsync(IList<Campus> campuses)
		{
            await _campusSQLRepo.AddEntitiesAsync(campuses);
		}

		/// <summary>
		/// Returns a list of Campuses from SQLite Database.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es). </param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Campus>> GetCampusesFromSQLiteDBByOrganizationAsync(Organization organisation, string language)
		{
            return await _campusSQLRepo.GetEntitiesByOrganizationIDAndLanguageAsync(organisation.Id, language);
		}
		#endregion
		#region API Properties & Methods
		public List<Campus> Campuses { get; set; }

		/// <summary>
		/// Returns a list of Campuses From CRM.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es). </param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Campus>> GetCampusesFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages)
		{
			try
			{
				Campuses = new List<Campus>();
				foreach (var currentOrganization in organizations)
				{
					foreach (var currentLanguage in languages)
					{
						List<Campus> currentCampuses =
							await _campusAPIRepo.GetCampusesByOrganizationAsync(currentOrganization, currentLanguage);
						if (currentCampuses == null || currentCampuses.Count.Equals(0)) continue;
						currentCampuses = currentCampuses
							.Select(c => new Campus
							{
								CampusId = c.CampusId,
								Name = c.Name,
								OrganizationId = currentOrganization.Id,
								Language = currentLanguage
							}).ToList();
						Campuses.AddRange(currentCampuses);
					}
				}
				return Campuses;
			}

			catch (Exception ex)
			{
				Debug.WriteLine("Could not retrive Campuses from API: " + ex.Message);
				return new List<Campus>();
			}
		}
		#endregion
	}
}
