using Microsoft.Practices.Unity;
using MobileApps.BL.StaticData;
using MobileApps.DAL;
using MobileApps.DependencyInjection;
using MobileApps.Models.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using static MobileApps.Models.Models.Objective;
using MobileApps.Models.Contracts.Services;

namespace MobileApps.Sync
{
    public static partial class DataSynchronizer
    {
        private static IUnityContainer _container;
        private static GlobalCampuses _data;
        public static void SyncronizeData()
        {
            _container = new DependencyInjectionRegister().GetCurrentContainer();
            _data = new GlobalCampuses();

            SyncronizeCampuses();
			SyncronizeEvents();
            SyncronizeSemesters();
            SyncronizeUsers();
			SyncronizePrograms();
            SyncronizeCountries();
            SyncronizeObjectives();
        }
        private static async void SyncronizeCampuses()
        {
            IList<Campus> CampusFromSQLiteDB = DependencyService.Get<ISqLite>().GetConnection().Table<Campus>().ToList();
            IList<Campus> CampusesFromAPI = await _container.Resolve<ICampusDataService>().GetCampusesFromCRMByOrganizationAsync(_data.Organizations, _data.Languages);
            IList<Campus> CampusesNotInSQLite = CampusesFromAPI.Except(CampusFromSQLiteDB, new CampusComparer()).ToList();
            if (CampusesNotInSQLite.Count == 0) return;
            await _container.Resolve<ICampusDataService>().AddCampusesToSQLiteDBAsync(CampusesNotInSQLite);
        }

		private static async void SyncronizeEvents()
		{
			IList<Event> EventsFromSQLiteDB = DependencyService.Get<ISqLite>().GetConnection().Table<Event>().ToList();
            IList<Event> EventsFromAPI = await _container.Resolve<IEventDataService>().GetEventsFromCRMByOrganizationAsync(_data.Organizations, _data.Languages);
			IList<Event> EventsNotInSQLite = EventsFromAPI.Except(EventsFromSQLiteDB, new EventComparer()).ToList();
			if (EventsNotInSQLite.Count == 0) return;
            await _container.Resolve<IEventDataService>().AddEventToSQLiteAsync(EventsNotInSQLite);
		}

		private static async void SyncronizeUsers()
		{
			IList<User> UsersFromSQLiteDB = DependencyService.Get<ISqLite>().GetConnection().Table<User>().ToList();
            IList<User> UsersFromAPI = await _container.Resolve<IUserDataService>().GetUsersFromCRMByOrganizationAsync(_data.Organizations, _data.Languages);
			IList<User> UsersNotInSQLite = UsersFromAPI.Except(UsersFromSQLiteDB, new UserComparer()).ToList();
			if (UsersNotInSQLite.Count == 0) return;
            await _container.Resolve<IUserDataService>().AddUserToSQLiteAsync(UsersNotInSQLite);
		}

		private static async void SyncronizeSemesters()
		{
			IList<Semester> SemesterFromSQLiteDB = DependencyService.Get<ISqLite>().GetConnection().Table<Semester>().ToList();
            IList<Semester> SemesterFromAPI = await _container.Resolve<ISemesterDataService>().GetSemestersFromCRMByOrganizationAsync(_data.Organizations, _data.Languages);
			IList<Semester> SemesterNotInSQLite = SemesterFromAPI.Except(SemesterFromSQLiteDB, new SemesterComparer()).ToList();
			if (SemesterNotInSQLite.Count == 0) return;
            await _container.Resolve<ISemesterDataService>().AddSemestersToSQLiteAsync(SemesterNotInSQLite);
		}

        private static async void SyncronizeCountries()
        {
            IList<Country> CountriesFromSQLiteDB = DependencyService.Get<ISqLite>().GetConnection().Table<Country>().ToList();
            IList<Country> CountriesFromAPI = await _container.Resolve<INationalityDataService>().GetCountriesByOrganizationFromCRMAsync(new Organization("Montreal"), "En");
            List<Country> CountriesNotInSQLite = CountriesFromAPI.Except(CountriesFromSQLiteDB, new NationalityComparer()).ToList();
            if (CountriesNotInSQLite.Count == 0) return;
            await _container.Resolve<INationalityDataService>().AddCountryInSQLiteAsync(CountriesNotInSQLite);
        }
        private static async void SyncronizePrograms()
        {
            IList<Program> ProgramsFromSQLiteDB = DependencyService.Get<ISqLite>().GetConnection().Table<Program>().ToList();

            IList<Program> MontrealProgramsFromAPI = await _container.Resolve<IProgramsDataService>().GetProgramsFromCRMByOrganizationAsync(_data.Organizations[0], _data.CampusesMontreal,  _data.Languages);
            IList<Program> ColombiaProgramsFromAPI = await _container.Resolve<IProgramsDataService>().GetProgramsFromCRMByOrganizationAsync(_data.Organizations[1], _data.CampusesColombia, _data.Languages);
            IList<Program> MexicoProgramsFromAPI = await _container.Resolve<IProgramsDataService>().GetProgramsFromCRMByOrganizationAsync(_data.Organizations[2], _data.CampusesMexico, _data.Languages);
            IList<Program> SpainProgramsFromAPI = await _container.Resolve<IProgramsDataService>().GetProgramsFromCRMByOrganizationAsync(_data.Organizations[3], _data.CampusesSpain, _data.Languages);
            IList<Program> MaghrebProgramsFromAPI = await _container.Resolve<IProgramsDataService>().GetProgramsFromCRMByOrganizationAsync(_data.Organizations[4], _data.CampusesMaghreb, _data.Languages);
            IList<Program> IndonesiaProgramsFromAPI = await _container.Resolve<IProgramsDataService>().GetProgramsFromCRMByOrganizationAsync(_data.Organizations[5], _data.CampusesIndonesia, _data.Languages);
            IList<Program> AustraliaProgramsFromAPI = await _container.Resolve<IProgramsDataService>().GetProgramsFromCRMByOrganizationAsync(_data.Organizations[6], _data.CampusesAustralia, _data.Languages);

            List<Program> ProgramsNotInSQLite = new List<Program>();
            ProgramsNotInSQLite.AddRange(MontrealProgramsFromAPI.Except(ProgramsFromSQLiteDB, new ProgramComparer()).ToList());
            ProgramsNotInSQLite.AddRange(ColombiaProgramsFromAPI.Except(ProgramsFromSQLiteDB, new ProgramComparer()).ToList());
            ProgramsNotInSQLite.AddRange(MexicoProgramsFromAPI.Except(ProgramsFromSQLiteDB, new ProgramComparer()).ToList());
            ProgramsNotInSQLite.AddRange(SpainProgramsFromAPI.Except(ProgramsFromSQLiteDB, new ProgramComparer()).ToList());
            ProgramsNotInSQLite.AddRange(MaghrebProgramsFromAPI.Except(ProgramsFromSQLiteDB, new ProgramComparer()).ToList());
            ProgramsNotInSQLite.AddRange(IndonesiaProgramsFromAPI.Except(ProgramsFromSQLiteDB, new ProgramComparer()).ToList());
            ProgramsNotInSQLite.AddRange(AustraliaProgramsFromAPI.Except(ProgramsFromSQLiteDB, new ProgramComparer()).ToList());

            if (ProgramsNotInSQLite.Count == 0) return;
            await _container.Resolve<IProgramsDataService>().AddProgramsToSQLiteAsync(ProgramsNotInSQLite);
        }
        private static async void SyncronizeObjectives()
        {
            IList<Objective> objectivesFromSQLiteDB = DependencyService.Get<ISqLite>().GetConnection().Table<Objective>().ToList();
            IList<Objective> objectivesFromAPI = await _container.Resolve<IObjectiveDataService>().GetObjectivesFromCRMByOrganizationAsync(_data.Organizations, _data.Languages);
            IList<Objective> objectivesNotInSQLite = objectivesFromAPI.Except(objectivesFromSQLiteDB, new ObjectiveComparer()).ToList();

            if (objectivesNotInSQLite.Count == 0) return;
            await _container.Resolve<IObjectiveDataService>().AddObjectivesToSQLiteAsync(objectivesNotInSQLite);
        }
    }
}
