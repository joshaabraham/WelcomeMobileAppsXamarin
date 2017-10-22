﻿﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Services;
using MobileApps.Models.Contracts.Repository.SQLite;

namespace MobileApps.BL.DataServices
{
    public class SemesterDS : ISemesterDataService
    {
        private readonly ISemesterAPIRepository _semesterAPIRepo;
        private readonly ISemesterRepository _semesterSQLiteRepo;

        public SemesterDS(ISemesterAPIRepository semesterAPIRepo, 
                                   ISemesterRepository semesterSQLiteRepo)
        {
            _semesterAPIRepo = semesterAPIRepo;
            _semesterSQLiteRepo = semesterSQLiteRepo;
        }

		#region SQLite Methods
		/// <summary>
		/// Add a list of Semesters to SQLite Database.
		/// </summary>
		/// <param name="request">A List of Semesters.</param>
		/// <returns>Response Code and document information.</returns>
		public async Task AddSemestersToSQLiteAsync(IList<Semester> semesters)
		{
			await _semesterSQLiteRepo.AddSemesterAsync(semesters);
		}

		/// <summary>
		/// Returns a list of Semesters from SQLite Database.
		/// </summary>
		/// <param name="request">A List of Organizations(ie. Montreal, Austrailia, Maghreb, etc ... ) and Language(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Semester>> GetSemesterFromSQLiteByOrganizationAsync(String Organisation, String Language)
        {
            return await _semesterSQLiteRepo.GetSemesterByOrganizationAsync(Organisation, Language);
        }
		#endregion
		#region API Properties & Methods
		public List<Semester> Semesters { get; set; }

		/// <summary>
		/// Returns a list of Semesters from CRM.
		/// </summary>
		/// <param name="request">A List of Organizations(ie. Montreal, Austrailia, Maghreb, etc ... ) and Languages(ie. en, fr, es).</param>
		/// <returns>Response Code and document information.</returns>
		public async Task<IList<Semester>> GetSemestersFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> languages)
		{
			try
			{
				Semesters = new List<Semester>();
				foreach (var currentOrganization in organizations)
				{
					foreach (var currentLanguage in languages)
					{
						List<Semester> currentSemesters = await _semesterAPIRepo.GetSemestersByOrganizationAsync(currentOrganization, currentLanguage);

						if (currentSemesters == null || currentSemesters.Count.Equals(0)) continue;
						currentSemesters = currentSemesters
							.Select(o => new Semester
							{
								SemesterID = o.SemesterID,
								Name = o.Name
							})
							.Where(o => o.Name.Length > 1).ToList();

						Semesters.AddRange(currentSemesters);
					}
				}
				return Semesters;
			}
			catch
			{
				return new List<Semester>();
			}
		}
        #endregion
    }
}
