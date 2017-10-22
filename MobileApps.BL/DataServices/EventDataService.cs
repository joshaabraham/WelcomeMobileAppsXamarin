using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Services;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.DAL.Repository.SQLite;

namespace MobileApps.BL.DataServices
{
	public class EventDS : BaseRepository<Event>, IEventDataService
	{
		private readonly IEventAPIRepository _eventAPIRepo;
		private readonly IEventRepository _eventSQLiteRepo;

		public EventDS(IEventAPIRepository eventAPIRepo,
								IEventRepository eventSQLiteRepo)
		{
			_eventAPIRepo = eventAPIRepo;
			_eventSQLiteRepo = eventSQLiteRepo;
		}

		#region SQLite Methods
		/// <summary>
		/// Adds a list of Events to SQLite Database.
		/// </summary>
		/// <param name="request">A list of Events. </param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddEventToSQLiteAsync(IList<Event> events)
		{
            await _eventSQLiteRepo.AddEntitiesAsync(events);
		}

		/// <summary>
		/// Returns a list of Events from SQLite Database.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
        public async Task<IList<Event>> GetEventFromSQLiteByOrganizationAsync(Organization Organisation, String Language)
		{
            return await _eventSQLiteRepo.GetEntitiesByOrganizationIDAndLanguageAsync(Organisation.Id, Language);
		}
		#endregion
		#region API Properties & Methods
		public List<Event> Events { get; set; }

		/// <summary>
		/// Returns a list of Events from CRM.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Event>> GetEventsFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages)
		{
			try
			{
				Events = new List<Event>();
				foreach (var currentOrganization in organizations)
				{
					foreach (var currentLanguage in languages)
					{
						List<Event> currentEvents = await _eventAPIRepo.GetEventsByOrganizationAsync(currentOrganization, currentLanguage);

						if (currentEvents == null || currentEvents.Count.Equals(0)) continue;
						currentEvents = currentEvents
							.Select(o => new Event
							{
								EventID = o.EventID,
                                EventName = o.EventName,
                                OrganizationId = currentOrganization.Id,
                                Language = currentLanguage,
								Name = o.Name
							})
							.Where(o => o.Name.Length > 1).ToList();

						Events.AddRange(currentEvents);
					}
				}

				return Events;
			}
			catch
			{
				return new List<Event>();
			}
		}
		#endregion
	}
}
