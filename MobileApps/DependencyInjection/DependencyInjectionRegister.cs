using Microsoft.Practices.Unity;
using MobileApps.Models.Models;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Contracts.Services;
using MobileApps.DAL.Repository.API;
using MobileApps.DAL.Repository.SQLite;
using MobileApps.BL.DataServices;

namespace MobileApps.DependencyInjection
{
    public class DependencyInjectionRegister : IDependencyInjectionRegister
    {
        private IUnityContainer _container;

        public DependencyInjectionRegister()
        {
            _container = new UnityContainer();
            SetUpContainer();
        }

        public IUnityContainer GetCurrentContainer()
        {
            return _container;
        }

        private void SetUpContainer()
        {
            RegisterCampuses();
            RegisterPrograms();
            RegisterInfoLead();
            RegisterObjectives();
            RegisterCountries();
            RegisterEvents();
            RegisterUsers();
            RegisterSemesters();
			RegisterPotentialStudents();
			RegisterPotentialStudentsEvent();
        }

        private void RegisterInfoLead()
        {
            //INFO LEAD
            _container.RegisterType<InfoLead>();
            _container.RegisterType<IInfoLeadAPIRepository, InfoLeadAPIRepository>();
          //  _container.RegisterType<IInfoLeadRepository, InfoLeadRepository>();
            _container.RegisterType<IInfoLeadDataService, InfoLeadDS>();
        }

        private void RegisterPotentialStudents()
        {
            //POTENTIAL STUDENT
            _container.RegisterType<PotentialStudent>();
            _container.RegisterType<IPotentialStudentAPIRepository, PotentialStudentAPIRepository>();
            _container.RegisterType<IPotentialStudentRepository, PotentialStudentRepository>();
            _container.RegisterType<IPotentialStudentDataService, PotentialStudentDS>();
        }

		private void RegisterPotentialStudentsEvent()
		{
			//POTENTIAL STUDENT
			_container.RegisterType<PotentialStudentEvent>();
			_container.RegisterType<IPotentialStudentEventAPIRepository, PotentialStudentEventAPIRepository>();
			_container.RegisterType<IPotentialStudentEventRepository, PotentialStudentEventRepository>();
			_container.RegisterType<IPotentialStudentEventDataService, PotentialStudentEventDS>();
		}

        private void RegisterCountries()
        {
            //COUNTRY
            _container.RegisterType<CitizenShipCountry>();
            _container.RegisterType<INationalityAPIRepository, NationalityAPIRepository>();
            _container.RegisterType<INationalityRepository, NationalityRepository>();
            _container.RegisterType<INationalityDataService, NationalityDS>();
        }

        private void RegisterObjectives()
        {
            //OBJECTIVE
            _container.RegisterType<Objective>();
            _container.RegisterType<IObjectiveAPIRepository, ObjectiveAPIRepository>();
            _container.RegisterType<IObjectiveRespository, ObjectiveRepository>();
            _container.RegisterType<IObjectiveDataService, ObjectiveDS>();
        }

        private void RegisterPrograms()
        {
            //PROGRAMS
            _container.RegisterType<Program>();
            _container.RegisterType<IProgramsAPIRepository, ProgramsAPIRepository>();
            _container.RegisterType<IProgramsRepository, ProgramsRepository>();
            _container.RegisterType<IProgramsDataService, ProgramsDS>();
        }

		private void RegisterUsers()
		{
			//USERS
			_container.RegisterType<User>();
			_container.RegisterType<IUserAPIRepository, UserAPIRepository>();
			_container.RegisterType<IUserRepository, UserRepository>();
			_container.RegisterType<IUserDataService, UserDS>();
		}


		private void RegisterSemesters()
		{
			//SEMESTERS
			_container.RegisterType<Semester>();
			_container.RegisterType<ISemesterAPIRepository, SemesterAPIRepository>();
			_container.RegisterType<ISemesterRepository, SemesterRepository>();
			_container.RegisterType<ISemesterDataService, SemesterDS>();
		}
		
        private void RegisterCampuses()
        {
            //CAMPUS
            _container.RegisterType<Campus>();
            _container.RegisterType<ICampusAPIRepository, CampusAPIRepository>();
            _container.RegisterType<ICampusRepository, CampusRepository>();
            _container.RegisterType<ICampusDataService, CampusDS>();
        }

		private void RegisterEvents()
		{
			//CAMPUS
			_container.RegisterType<Event>();
			_container.RegisterType<IEventAPIRepository, EventAPIRepository>();
			_container.RegisterType<IEventRepository, EventRepository>();
			_container.RegisterType<IEventDataService, EventDS>();
		}
    }
}