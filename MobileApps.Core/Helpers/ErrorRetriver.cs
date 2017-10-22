using static MobileApps.Core.Helpers.GlobalErrors;

namespace MobileApps.Core.Helpers
{
    public static class ErrorRetriver
    {
        public static string IdentifySettingsViewError(SettingsError errorType)
        {
            if (errorType == SettingsError.OrganizationMandatory)
                return "An organization must be selected";
            if (errorType == SettingsError.OneCampusMandatory)
                return "Atleast one campus must be selected";
            return "";
        }

        /*
        public static string IdentifyNameViewError(NameError errorType, string Language)
        {
            if (errorType == NameError.Empty)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.NamePageError1;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.NamePageError1;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.NamePageError1;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.NamePageError1;
                    default:
                        return ValidationMessages.ValidationMessagesEN.NamePageError1;
                }
            }
            if (errorType == NameError.BadFormat)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.NamePageError2;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.NamePageError2;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.NamePageError2;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.NamePageError2;
                    default:
                        return ValidationMessages.ValidationMessagesEN.NamePageError2;
                }
            }
            return "";
        }

        public static string IdentifyTelephoneViewError(TelephoneError errorType, string Language)
        {
            if (errorType == TelephoneError.MinimumOnePhoneNumber)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.TelephonePageError1;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.TelephonePageError1;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.TelephonePageError1;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.TelephonePageError1;
                    default:
                        return ValidationMessages.ValidationMessagesEN.TelephonePageError1;
                }
            }
            if (errorType == TelephoneError.BadFormat)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.TelephonePageError2;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.TelephonePageError2;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.TelephonePageError2;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.TelephonePageError2;
                    default:
                        return ValidationMessages.ValidationMessagesEN.TelephonePageError2;
                }
            }
            return "";
        }

        public static string IdentifyCampusViewError(ErrorType errorType, string Language)
        {
            if (errorType == ErrorType.NotSelected)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.CampusPageError1;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.CampusPageError1;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.CampusPageError1;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.CampusPageError1;
                    default:
                        return ValidationMessages.ValidationMessagesEN.CampusPageError1;
                }
            }
            if (errorType == ErrorType.DatabaseEmpty)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.CampusPageError2;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.CampusPageError2;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.CampusPageError2;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.CampusPageError2;
                    default:
                        return ValidationMessages.ValidationMessagesEN.CampusPageError2;
                }
            }
            return "";
        }

        public static string IdentifyProgramsViewError(ErrorType errorType, string Language)
        {
            if (errorType == ErrorType.NotSelected)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.ProgramsPageError1;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.ProgramsPageError1;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.ProgramsPageError1;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.ProgramsPageError1;
                    default:
                        return ValidationMessages.ValidationMessagesEN.ProgramsPageError1;
                }
            }
            if (errorType == ErrorType.DatabaseEmpty)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.ProgramsPageError2;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.ProgramsPageError2;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.ProgramsPageError2;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.ProgramsPageError2;
                    default:
                        return ValidationMessages.ValidationMessagesEN.ProgramsPageError2;
                }
            }
            return "";
        }

        public static string IdentifyEmailyViewError(EmailError errorType, string Language)
        {
            if (errorType == EmailError.Empty)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.EmailPageError1;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.EmailPageError1;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.EmailPageError1;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.EmailPageError1;
                    default:
                        return ValidationMessages.ValidationMessagesEN.EmailPageError1;
                }
            }
            if (errorType == EmailError.BadFormat)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.EmailPageError2;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.EmailPageError2;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.EmailPageError2;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.EmailPageError2;
                    default:
                        return ValidationMessages.ValidationMessagesEN.EmailPageError2;
                }
            }
            return "";
        }

        public static string IdentifyCountryViewError(ErrorType errorType, string Language)
        {
            if (errorType == ErrorType.NotSelected)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.CitizenshipPageError1;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.CitizenshipPageError1;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.CitizenshipPageError1;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.CitizenshipPageError1;
                    default:
                        return ValidationMessages.ValidationMessagesEN.CitizenshipPageError1;
                }
            }
            if (errorType == ErrorType.DatabaseEmpty)
            {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.CitizenshipPageError2;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.CitizenshipPageError2;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.CitizenshipPageError2;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.CitizenshipPageError2;
                    default:
                        return ValidationMessages.ValidationMessagesEN.CitizenshipPageError2;
                }
            }
            return "";
        }

        public static string IdentifyObjectivesViewError(string Language)
        {
                switch (Language)
                {
                    case "Fr":
                        return ValidationMessages.ValidationMessagesFR.ObjectivePageError1;
                    case "Es":
                        return ValidationMessages.ValidationMessagesES.ObjectivePageError1;
                    case "Ca":
                        return ValidationMessages.ValidationMessagesCA.ObjectivePageError1;
                    case "Id":
                        return ValidationMessages.ValidationMessagesID.ObjectivePageError1;
                    default:
                        return ValidationMessages.ValidationMessagesEN.ObjectivePageError1;
                }         
        }
        */
    }
}
