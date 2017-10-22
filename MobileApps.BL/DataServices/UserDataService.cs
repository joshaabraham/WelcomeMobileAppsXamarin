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
    public class UserDS : IUserDataService
    {
        private readonly IUserAPIRepository _userAPIRepo;
        private readonly IUserRepository _userSQLiteRepo;

        public UserDS(IUserAPIRepository userAPIRepo,
                               IUserRepository userSQLiteRepo)
        {
            _userAPIRepo = userAPIRepo;
            _userSQLiteRepo = userSQLiteRepo;
        }

		#region SQLite Methods
		
        /// <summary>
		/// Adds a list of Users to SQLite Database.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddUserToSQLiteAsync(IList<User> users)
		{
            await _userSQLiteRepo.AddEntitiesAsync(users);
		}

        /// <summary>
		/// Returns a list of Users from SQLite Database.
		/// </summary>
		/// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ) and a Language(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
        public async Task<IList<User>> GetUserFromSQLiteByOrganizationAsync(Organization Organisation, String Language)
        {
            return await _userSQLiteRepo.GetEntitiesByOrganizationIDAndLanguageAsync(Organisation.Id, Language);
        }

		#endregion
		#region API Properties & Methods
		public List<User> Users { get; set; }

		/// <summary>
		/// Returns a list of Users from CRM.
		/// </summary>
		/// <param name="request">A List of Organizations(ie. Montreal, Austrailia, Maghreb, etc ... ) and Languages(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<User>> GetUsersFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages)
		{
			try
			{
				Users = new List<User>();
				foreach (var currentOrganization in organizations)
				{
					foreach (var currentLanguage in languages)
					{
						List<User> currentUsers = await _userAPIRepo.GetUsersByOrganizationAsync(currentOrganization, currentLanguage);

						if (currentUsers == null || currentUsers.Count.Equals(0)) continue;
                        currentUsers = currentUsers
                            .Select(o => new User
                            {
                                UserID = o.UserID,
                                DirectorName = o.Name,
                                Language = currentLanguage,
                                OrganizationId = currentOrganization.Id
							})
							.Where(o => o.Name.Length > 1).ToList();

						Users.AddRange(currentUsers);
					}
				}

				return Users;
			}
			catch
			{
				return new List<User>();
			}
		}
		#endregion
	}
}
