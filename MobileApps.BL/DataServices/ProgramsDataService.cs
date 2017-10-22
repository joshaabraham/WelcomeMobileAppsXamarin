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
    public class ProgramsDS : IProgramsDataService
    {
        private readonly IProgramsAPIRepository _programsAPIRepo;
        private readonly IProgramsRepository _programsSQLiteRepo;

        public ProgramsDS(IProgramsAPIRepository programsAPIRepo,
                                   IProgramsRepository programsSQLiteRepo)
        {
            _programsAPIRepo = programsAPIRepo;
            _programsSQLiteRepo = programsSQLiteRepo;
        }

        #region SQLite Methods

        /// <summary>
        /// Adds a list of Programs to SQLite Database.
        /// </summary>
        /// <param name="request">A List of Programs.</param>
        /// <returns>Response Code and document information.</returns>
        public async Task AddProgramsToSQLiteAsync(IList<Program> programs)
        {
            await _programsSQLiteRepo.AddProgramsAsync(programs);
        }

        /// <summary>
        /// Returns a list of Programs from SQLite Database.
        /// </summary>
        /// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ).</param>
        /// <returns>Response Code and document information.</returns>
        public async Task<IList<Program>> GetProgramsFromSQLiteByOrganizationAsync(Organization organization, Campus campus, string languages)
        {
            return await _programsSQLiteRepo.GetProgramsByCampusAndOrganization(organization, campus,languages);
        }

        #endregion
        #region API Properties & Methods
        public List<Program> Programs { get; set; }

        /// <summary>
        /// Returns a list of Programs from CRM.
        /// </summary>
        /// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ), A Campus name(ie. e-learning, Interdec, etc ...) and a Language(ie. en, fr, es).</param>
        /// <returns>Response Code and document information.</returns>
        public async Task<IList<Program>> GetProgramsFromCRMByOrganizationAsync(Organization organizations, string campus, string languages, string CRMConnectionString = "kiosk.collegelasalle.com")
        {
            return await _programsAPIRepo.GetProgramsByOrganizationAsync(organizations, campus, languages, CRMConnectionString);
        }

        /// <summary>
        /// Returns a list of Programs from CRM.
        /// </summary>
        /// <param name="request">An Organization(ie. Montreal, Austrailia, Maghreb, etc ... ), A Campus name(ie. e-learning, Interdec, etc ...) and a Language(ie. en, fr, es).</param>
        /// <returns>Response Code and document information.</returns>
        public async Task<IList<Program>> GetProgramsFromCRMByOrganizationAsync(IList<Organization> organizations, IList<string> campus, IList<string> languages, string CRMConnectionString = "kiosk.collegelasalle.com")
        {
            try
            {
                Programs = new List<Program>();
                foreach (var currentOrganization in organizations)
                {
                    foreach (var currentCampus in campus)
                    {
                        foreach (var currentLang in languages)
                        {
                            List<Program> currentPrograms =
                            await _programsAPIRepo.GetProgramsByOrganizationAsync(currentOrganization, currentCampus, currentLang);
                            if (currentPrograms == null || currentPrograms.Count.Equals(0)) continue;
                            currentPrograms = currentPrograms
                                .Select(p => new Program
                                {
                                    ProgramId = p.ProgramId,
                                    Name = p.Name,
                                    OrganisationId = currentOrganization.Id,
                                    Campus = p.Campus,
                                    CampusCode = p.CampusCode
                                }).ToList();
                            Programs.AddRange(currentPrograms);
                        }
                    }
                }

                return Programs;
            }
            catch (Exception ex)
            {

                return new List<Program>();
            }
        }

        public async Task<IList<Program>> GetProgramsFromCRMByOrganizationAsync(Organization organization, IList<string> campusCode, IList<string> languages, string CRMConnectionString = "kiosk.collegelasalle.com")
        {
			try
			{
				Programs = new List<Program>();

				foreach (var currentCampus in campusCode)
				{
					foreach (var currentLang in languages)
					{
						List<Program> currentPrograms =
						await _programsAPIRepo.GetProgramsByOrganizationAsync(organization, currentCampus, currentLang);
						if (currentPrograms == null || currentPrograms.Count.Equals(0)) continue;
						currentPrograms = currentPrograms
							.Select(p => new Program
							{
								ProgramId = p.ProgramId,
								Name = p.Name,
								OrganisationId = organization.Id,
								CampusKey = IdentifyCampus(currentCampus, organization.Name),
								Language = currentLang
							}).ToList();
						Programs.AddRange(currentPrograms);
					}
				}
				return Programs;
			}
			catch (Exception ex)
			{
				return new List<Program>();
			}
        }

		#endregion
		#region Business Logic - Application Based 

		private string IdentifyCampus(string currentCampus, string organizationName)
		{
			if (organizationName == "Montreal")
			{
				return IdentifyCampusesMontreal(currentCampus);
			}
			if (organizationName == "Colombia")
			{
				if (currentCampus == "Barranquilla") return "LCI Barranquilla";
				if (currentCampus == "Bogota") return "LCI Bogotá";
			}
			if (organizationName == "Mexico")
			{
				if (currentCampus == "Monterrey") return "LCI Monterrey";
			}
			if (organizationName == "Spain")
			{
				if (currentCampus == "Barcelona") return "LCI Barcelona";
			}
			if (organizationName == "Maghreb")
			{
				return IdentifyCampusesMaghreb(currentCampus);
			}
			if (organizationName == "Indonesia")
			{
				if (currentCampus == "Jakarta") return "LaSalle College | Jakarta";
				if (currentCampus == "Surabaya") return "LaSalle College | Surabaya";
			}
			if (organizationName == "Australia")
			{
				return IdentityCampusesAustralia(currentCampus);
			}
			return "";
		}

		private static string IdentityCampusesAustralia(string currentCampus)
		{
			switch (currentCampus)
			{
				case "AODM": return "Academy of Design Australia";
				case "FEBrisbane": return "Fusion English Brisbane";
				case "FEMelbourne": return "Fusion English Melbourne";
				default: return "";
			}
		}

		// Campus Name Identification Methods
		private static string IdentifyCampusesMaghreb(string currentCampus)
		{
			switch (currentCampus)
			{
				case "casablanca":
					return "Collège LaSalle | Casablanca";
				case "Marrakech":
					return "Collège LaSalle | Marrakech";
				case "Rabat":
					return "Collège LaSalle | Rabat";
				case "Tanger":
					return "Collège LaSalle | Tanger";
				case "Tunisie":
					return "Collège LaSalle | Tunis";
				default:
					return "";
			}
		}
		private string IdentifyCampusesMontreal(string currentCampus)
		{
			switch (currentCampus)
			{
				case "CSLI":
					return "Canadian Second Language Institute (CSLI)";
				case "elarning":
					return "E-learning";
				case "interdeclaval":
					return "Inter-Dec College | Laval";
				case "interdec":
					return "Inter-Dec College | Montréal";
				case "lasalle":
					return "LaSalle College | Montréal";
				case "TO":
					return "LaSalle College Toronto School of Design";
				case "LCIV":
					return "LaSalle College Vancouver";
				case "cilm":
					return "Montreal International Language Centre (MILC)";
				default:
					return "";
			}
		}
        #endregion
    }
}
