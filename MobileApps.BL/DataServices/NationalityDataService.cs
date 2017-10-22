using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Services;
using MobileApps.Models.Contracts.Repository.SQLite;


namespace MobileApps.BL.DataServices
{
    public class NationalityDS : INationalityDataService
	{
		private readonly INationalityAPIRepository _citizenshipAPIRepo;
		private readonly INationalityRepository _citizenshipSQLiteRepo;

		public NationalityDS(INationalityAPIRepository citizenshipAPIRepo,
									  INationalityRepository citizenshipSQLiteRepo)
		{
			_citizenshipAPIRepo = citizenshipAPIRepo;
			_citizenshipSQLiteRepo = citizenshipSQLiteRepo;
		}

		#region SQLite Methods

		/// <summary>
		/// Adds a list of Countries to SQLite Database.
		/// </summary>
		/// <param name="request">A List of Countries.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddCountryInSQLiteAsync(IList<Country> citizenshipCountry)
		{
            await _citizenshipSQLiteRepo.AddEntitiesAsync(citizenshipCountry);
		}

		/// <summary>
		/// Returns a list of Countries from SQLite Database.
		/// </summary>
		/// <param name="request">N/A.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Country>> GetCountriesFromSQLiteAsync()
		{
            return await _citizenshipSQLiteRepo.GetAllEntitiesAsync();
		}
		#endregion
		#region API Properties & Methods
		public List<Country> Countries { get; set; }

		/// <summary>
		/// Returns a list of Countries from CRM.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<List<Country>> GetCountriesByOrganizationFromCRMAsync(Organization organization, string language)
		{
			return await _citizenshipAPIRepo.GetCountriesByOrganizationAsync(organization, language);
		}
		#endregion
	}
}
