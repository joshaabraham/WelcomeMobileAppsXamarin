using System;
using Foundation;
using MobileApps.DAL;
using MobileApps.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(PreferenceRetriever))]
namespace MobileApps.iOS
{
    public class PreferenceRetriever : IPreferenceRetriever
    {
        static NSDictionary prefsDictionary= new NSDictionary(NSBundle.MainBundle.PathForResource("Settings.bundle/Root.plist", null));

        public static string OrganizationChosen{ get; private set; }
        public static string LanguageOne{ get; private set; }
        public static string LanguageTwo{ get; private set; }
        public static string LanguageThree{ get; private set; }
        public static string CRMURL{ get; private set; }
        public static string refreshData{ get; private set; }

        public string GetCRMURL()
        {
			string propertyValue = NSUserDefaults.StandardUserDefaults.StringForKey("CRMURLKey");
            if (string.IsNullOrEmpty(propertyValue)) propertyValue = "kiosk.collegelasalle.com";
            return propertyValue;
        }

        public string GetLanguageOne()
        {
            string propertyValue = NSUserDefaults.StandardUserDefaults.StringForKey("languageOneKey");
            if (string.IsNullOrEmpty(propertyValue)) propertyValue = "En";
            return propertyValue;
        }

        public string GetLanguageThree()
        {
			string propertyValue = NSUserDefaults.StandardUserDefaults.StringForKey("languageThreeKey");
            if (string.IsNullOrEmpty(propertyValue)) propertyValue = "Es";
            return propertyValue;
        }

        public string GetLanguageTwo()
        {
			string propertyValue = NSUserDefaults.StandardUserDefaults.StringForKey("languageTwoKey");
            if (string.IsNullOrEmpty(propertyValue)) propertyValue = "Fr";
            return propertyValue;
        }

        public string GetOrganizationChosen()
        {
            string propertyValue = NSUserDefaults.StandardUserDefaults.StringForKey("chosenOrganizationKey");
            if (string.IsNullOrEmpty(propertyValue)) propertyValue = "Montreal";
            return propertyValue;
        }

		public string GetLogoChosen()
		{
            string propertyValue = NSUserDefaults.StandardUserDefaults.StringForKey("logoChosenKey");
            if (string.IsNullOrEmpty(propertyValue)) propertyValue = "WelcomeBackgroundImageMontreal";
            return propertyValue;
        }

        public string GetRefreshData()
        {
			return NSUserDefaults.StandardUserDefaults.StringForKey("enabled_refreshData");
        }

		public bool GetEventModeStatus()
		{
            bool propertyValue = NSUserDefaults.StandardUserDefaults.BoolForKey("enabled_eventMode");
            return propertyValue;
        }
		public string GetQueueName()
		{
			string propertyValue = NSUserDefaults.StandardUserDefaults.StringForKey("QueueOptionsKey");
			if (string.IsNullOrEmpty(propertyValue)) propertyValue = "Walk-In - Montreal";
			return propertyValue;
		}

        public void retriveData()
        {
            var prefSpecifierArray = prefsDictionary["PreferenceSpecifiers"] as NSArray;
            foreach (var prefItem in NSArray.FromArray<NSDictionary>(prefSpecifierArray))
            {
                var key = (NSString)prefItem["Key"];
                if (key == null) continue;

                var val = prefItem["DefaultValue"];
                switch (key.ToString())
                {
                    case "organizationChosenKey":
                        OrganizationChosen = val.ToString();
                        break;
					case "languageOneKey":
                        LanguageOne = val.ToString();
                        break;
				    case "languageTwoKey":
                        LanguageTwo = val.ToString();
                        break;
                    case "languageThreeKey":
                        LanguageThree = val.ToString();
                        break;
                    case "CRMURLKey":
                        CRMURL = val.ToString();
                        break;
                    case "enabled_refreshData":
                        refreshData = val.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
