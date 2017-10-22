using System;
using System.Linq;
using System.Collections.Generic;
using MobileApps.ViewModels;
using MobileApps.Views.Navigation;
using Xamarin.Forms;
using MobileApps.Views.Navigation.SubViews;

namespace MobileApps.Helpers
{
    public static class Navigation
    {
        private static IDictionary<StepOrder, string> ViewNavigationByStepOrder;

        static Navigation()
        {
            SetUpViewNavigationByStepOrder();
        }

        private static void SetUpViewNavigationByStepOrder()
        {
            ViewNavigationByStepOrder = new Dictionary<StepOrder, string>
            {
                {StepOrder.Language,            "LanguagePromptView" },
                {StepOrder.Settings,            "SettingsView" },
                {StepOrder.Email,               "EmailPromptView" },
                {StepOrder.Name,                "NamePromptView" },
                {StepOrder.Telephone,           "TelephonePromptView" },
                {StepOrder.Occupation,          "OccupationPromptView" },
                {StepOrder.Programs,            "ProgramsPromptView" },
                {StepOrder.Campus,              "CampusPromptView" },
                {StepOrder.Citizenship,         "CitizenshipPromptView" },
                {StepOrder.Country,             "CitizenShipCountryPromptView" },
                {StepOrder.Objective,           "ObjectivePromptView" },
                {StepOrder.Acknowledgement,     "AcknowledgementView" }
            };
        }

        static public void NavigateToNextPage(NavigationStateViewModel navigationState, bool isReturningStudent = false)
        {
            var primaryPage = App.Current.MainPage;
            if (primaryPage.Navigation == null) return;
            MasterPage Instance = (MasterPage)primaryPage.Navigation.NavigationStack.First();

            Type type = Type.GetType("MobileApps.Views.Navigation.SubViews." + GetNextView(navigationState.CurrentStep));
			if (type == null) return;
            View newContent = (View)Activator.CreateInstance(type);


            if(isReturningStudent)
                Instance.WelcomeBackExistingStudent(newContent);
            else
                Instance.UpdateView(newContent);
        }

		static public void NavigateToPageByViewNameExplicitly(string key)
		{
			var primaryPage = App.Current.MainPage;
			if (primaryPage.Navigation == null) return;
			MasterPage Instance = (MasterPage)primaryPage.Navigation.NavigationStack.First();

            Type type = Type.GetType("MobileApps.Views.Navigation.SubViews." + key);
			if (type == null) return;
			View newContent = (View)Activator.CreateInstance(type);

			Instance.UpdateView(newContent);
		}

        public static string GetNextView(StepOrder nextStep)
        {
            if (ViewNavigationByStepOrder.ContainsKey(nextStep))
                return ViewNavigationByStepOrder[nextStep];
            return "ErrorView";
        }
	}
}
