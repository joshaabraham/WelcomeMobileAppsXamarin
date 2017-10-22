namespace MobileApps.Core.Helpers
{
    public static class GlobalErrors
    {
        public enum SettingsError { OrganizationMandatory, OneCampusMandatory }
        public enum NameError { Empty, BadFormat }
        public enum TelephoneError { MinimumOnePhoneNumber, BadFormat }
        public enum ErrorType { NotSelected, DatabaseEmpty };
        public enum EmailError { Empty, BadFormat }
    }
}
