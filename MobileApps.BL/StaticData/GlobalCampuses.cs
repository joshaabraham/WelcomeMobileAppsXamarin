using MobileApps.Models.Models;
using System;
using System.Collections.Generic;

namespace MobileApps.BL.StaticData
{
    public class GlobalCampuses
    {
        #region Static Properties
        public IList<Organization> Organizations = new List<Organization>()
            {
                new Organization(new Guid(""),"Montreal"),
                new Organization(new Guid(""),"Colombia"),
                new Organization(new Guid(""),"Mexico"),
                new Organization(new Guid(""),"Spain"),
                new Organization(new Guid(""),"Maghreb"),
                new Organization(new Guid(""),"Indonesia"),
                new Organization(new Guid(""),"Australia")
            };

        #region Campuses 
        public IList<string> CampusesMontreal = new List<string>()
        {
            "CSLI",          "elarning",    "interdeclaval",
            "interdec",      "lasalle",     "TO",
            "LCIV",          "cilm"
        };

        public IList<string> CampusesColombia = new List<string>()
        {
            "Barranquilla",  "Bogota"
    };
        public IList<string> CampusesMexico = new List<string>() { "Monterrey" };
        public IList<string> CampusesSpain = new List<string>() { "Barcelona" };
        public IList<string> CampusesMaghreb = new List<string>()
        {
            "casablanca", "Marrakech",
            "Rabat",      "Tanger",
            "Tunisie"
    };
        public IList<string> CampusesIndonesia = new List<string>()
        {
            "Jakarta", "Surabaya",
    };

        public IList<string> CampusesAustralia = new List<string>()
            {
            "AODM",
            "FEBrisbane",
            "FEMelbourne"
            };
        public IList<string> CampusesTurkey = new List<string>()
            {
            "elearning",
            "istanbul"
            };
        #endregion

        public IList<string> Languages = new List<string>() { "en", "fr", "es" };

        #endregion
    }
}
