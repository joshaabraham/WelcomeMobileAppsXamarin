using System.Collections.Generic;

namespace MobileApps.Core.Helpers
{
    public class ViewLocator
    {
        #region Dictionary With All Views
        static Dictionary<string, string> UIPath = new Dictionary<string, string>
        {
            { "previousView","LanguagePromptViewModel"},
            { "currentView","EmailPromptViewModel"},
            { "nextView","NamePromptViewModel"},
            { "notActive","TelephonePromptViewModel"},
            { "notActive","OccupationPromptViewModel"},
            { "notActive","CitizenshipPromptViewModel"},
            { "notActive","ObjectivePromptViewModel"},
            { "notActive","InstitutionPromptViewModelModel"},
            { "notActive","QuebecPromptViewModelModel"},
            { "notActive","AcknowledgementViewModel"}
        };
        #endregion

        public Dictionary<string,string> retriveViews(string currentView, string state)
        {
            // IDENTIFY CURRENT VIEW

            //RESORT LIST APPROPRIATELY
            resortByNameState(state);

            return UIPath;
        }

        public void resortByNameState(string state)
        {
            // LOGIC TO RESORT THE DICTIONARY 
          //  UIPath["previousView"] = "LanguagePromptView";
        }

        public void resortByEmailState(string state) { }
        public void resortByTelephoneState(string state) { }
        public void resortByOccupationState(string state) { }
        public void resortByInstitutionState(string state) { }
        public void resortByCountryState(string state) { }
        public void resortByCitizenshipState(string state) { }
        public void resortByObjectiveState(string state) { }
        public void resortByInQuebecState(string state) { }
        public void resortByLeadExistsState(string state) { }
        public void resortByLanguageState(string state) { }
    
    }
}
