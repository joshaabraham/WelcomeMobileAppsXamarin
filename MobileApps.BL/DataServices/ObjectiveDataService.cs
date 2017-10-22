using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Services;
using MobileApps.Models.Contracts.Repository.SQLite;

namespace MobileApps.BL.DataServices
{
	public class ObjectiveDS : IObjectiveDataService
	{
		private readonly IObjectiveAPIRepository _objectiveAPIRepo;
		private readonly IObjectiveRespository _objectiveSQLiteRepo;

		public ObjectiveDS(IObjectiveAPIRepository objectiveAPIRepo,
									IObjectiveRespository objectiveSQLiteRepo)
		{
			_objectiveAPIRepo = objectiveAPIRepo;
			_objectiveSQLiteRepo = objectiveSQLiteRepo;
		}

		#region SQLite Methods
		/// <summary>
		/// Adds a list of Objectives to SQLite Database.
		/// </summary>
		/// <param name="request">A List of Objectives.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddObjectivesToSQLiteAsync(IList<Objective> objective)
		{
            await _objectiveSQLiteRepo.AddEntitiesAsync(objective);
		}

		/// <summary>
		/// Returns a list of Objectives from SQLite Database.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Objective>> GetObjectivesFromSQLiteByOrganizationAsync(Guid OrganisationID, String Language)
		{
            return await _objectiveSQLiteRepo.GetEntitiesByOrganizationIDAndLanguageAsync(OrganisationID, Language);
		}
		#endregion
		#region API Properties & Methods
		public List<Objective> Objectives { get; set; }

		/// <summary>
		/// Returns a list of Objectives from CRM.
		/// </summary>
		/// <param name="request">A List of Organizations(ie. Montreal, Austrailia, Maghreb, etc ... ) and Languages(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Objective>> GetObjectivesFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages)
		{
			try
			{
				Objectives = new List<Objective>();
				foreach (var currentOrganization in organizations)
				{
					foreach (var currentLanguage in languages)
					{
						List<Objective> currentObjectives = await _objectiveAPIRepo.GetObjectivesByOrganizationAsync(currentOrganization, currentLanguage);

						if (currentObjectives == null || currentObjectives.Count.Equals(0)) continue;
						currentObjectives = currentObjectives
							.Select(o => new Objective
							{
								VisitGoalID = o.VisitGoalID,
								MoreInfo = o.MoreInfo,
								Name = o.Name,
                                OrganizationId = currentOrganization.Id,
                                Language = currentLanguage
							})
							.Where(o => o.Name.Length > 1).ToList();

						Objectives.AddRange(currentObjectives);
					}
				}
				return Objectives;
			}
			catch
			{
				return new List<Objective>();
			}
		}
		#endregion
	}
}
