using Microsoft.Practices.Unity;
using MobileApps.DAL;
using MobileApps.DependencyInjection;
using MobileApps.Models.Contracts.Repository.API;
using MobileApps.Models.Contracts.Repository.SQLite;
using MobileApps.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Plugin.Connectivity;
using MobileApps.ViewModels;
using System.Diagnostics;

namespace MobileApps.Sync
{
    public static partial class DataSynchronizer
    {
        public static async void SyncronizePotentialStudents()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (!isConnected) return;

            IList<PotentialStudent> potentialStudentsFromSQLiteDB = GetSQLitePotentialStudents();
            foreach (PotentialStudent Student in potentialStudentsFromSQLiteDB)
            {
                if (Student.EnteredInCRM)return;

                bool IsSuccessfulPOST = false;
                string CRMURL = "http://" + MainViewModel.Instance.KioskApp.SettingsVm.CRMURL + "";
                IsSuccessfulPOST = await _container.Resolve<IPotentialStudentAPIRepository>().PostLead(
                Student, CRMURL, "");
            
                Student.EnteredInCRM = IsSuccessfulPOST;

                if (Student.EnteredInCRM)
                    await _container.Resolve<IPotentialStudentRepository>().DeletePotentialStudentAsync(Student);
            }
        }

        private static IList<PotentialStudent> GetSQLitePotentialStudents()
        {
            IUnityContainer _currentUnityContainer = new DependencyInjectionRegister().GetCurrentContainer();

            var db = DependencyService.Get<ISqLite>().GetConnection();
            List<PotentialStudent> result = new List<PotentialStudent>();
            try
            {
                result = db.Table<PotentialStudent>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            return result;
        }

        public static async void SyncronizePotentialStudentsForEvent()
        {
            var isConnected = CrossConnectivity.Current.IsConnected;
            if (!isConnected) return;

            IList<PotentialStudentEvent> potentialStudentsFromSQLiteDB = GetSQLitePotentialStudentsEvent();
            foreach (PotentialStudentEvent Student in potentialStudentsFromSQLiteDB)
            {
                if (Student.EnteredInCRM) return;

                bool IsSuccessfulPOST = false;
                string CRMURL = "http://" + MainViewModel.Instance.KioskApp.SettingsVm.CRMURL + "";
                IsSuccessfulPOST = await _container.Resolve<IPotentialStudentEventAPIRepository>().PostLead(
                Student, CRMURL, "");

                Student.EnteredInCRM = IsSuccessfulPOST;

                if (Student.EnteredInCRM)
                    try
                    {
                        await _container.Resolve<IPotentialStudentEventRepository>().DeletePotentialStudentEventAsync(Student);
                    }
                    catch(Exception ex) 
                {
                    Debug.WriteLine("Error Deleting Lead in Database");
                }
            }
        }

		private static IList<PotentialStudentEvent> GetSQLitePotentialStudentsEvent()
		{
			IUnityContainer _currentUnityContainer = new DependencyInjectionRegister().GetCurrentContainer();

			var db = DependencyService.Get<ISqLite>().GetConnection();

			List<PotentialStudentEvent> result = new List<PotentialStudentEvent>();
			try
			{
				result = db.Table<PotentialStudentEvent>().ToList();
			}
			catch (Exception ex)
			{
                throw new Exception(ex.InnerException.Message);
			}

			return result;
		}
    }
}
