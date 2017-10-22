using System;
using System.Collections.Generic;

namespace MobileApps.Models.Models
{
    public class Country : BaseModel
    {

        private Guid _CountryID;
        private string _Name;


        public Guid CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }


        public Country(string name)
        {
            this.CountryID = new Guid();
            this.Name = name;
        }
        public Country()
        {

        }
    }
    public class NationalityComparer : IEqualityComparer<Country>
    {
        public bool Equals(Country x, Country y)
        {
            return (x.CountryID == y.CountryID);
        }

        public int GetHashCode(Country obj)
        {
            int hashCountryName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashCountryGuid = obj.CountryID.GetHashCode();
            return hashCountryName ^ hashCountryGuid;
        }
    }
}
