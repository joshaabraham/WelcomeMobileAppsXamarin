using System;
namespace MobileApps.DAL
{
    public interface IPreferenceRetriever
    {
        string GetOrganizationChosen();
        string GetLanguageOne();
        string GetLanguageTwo();
        string GetLanguageThree();
        string GetCRMURL();
        string GetRefreshData();
        string GetLogoChosen();
        string GetQueueName();
        bool GetEventModeStatus();

        void retriveData();
    }
}
