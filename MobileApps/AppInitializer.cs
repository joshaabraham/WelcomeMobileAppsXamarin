using System;
using Microsoft.Practices.Unity;
using MobileApps.DAL;
using MobileApps.Models.Models;
using SQLite.Net;
using MobileApps.DependencyInjection;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace MobileApps
{
	public class AppInitializer
	{
		private IUnityContainer _container;

		public void Initialize()
		{
			_container = new DependencyInjectionRegister().GetCurrentContainer();
			SQLiteConnection db = DependencyService.Get<ISqLite>().GetConnection();

			Device.StartTimer(TimeSpan.FromMinutes(5), () => { Sync.DataSynchronizer.SyncronizePotentialStudents(); return true; });
			Device.StartTimer(TimeSpan.FromHours(1), () => { Sync.DataSynchronizer.SyncronizePotentialStudentsForEvent(); return true; });

			#region SQLDB TABLE CREATION
			db.CreateTable<Campus>();
			db.CreateTable<Program>();
			db.CreateTable<Country>();
			db.CreateTable<Objective>();
			db.CreateTable<Event>();
			db.CreateTable<User>();
			db.CreateTable<Semester>();
			db.DropTable<PotentialStudent>();
			db.CreateTable<PotentialStudent>();
			db.DropTable<PotentialStudentEvent>();
			db.CreateTable<PotentialStudentEvent>();
			#endregion

			var isConnected = CrossConnectivity.Current.IsConnected;
			if (isConnected)
				Sync.DataSynchronizer.SyncronizeData();
		}
	}
}
