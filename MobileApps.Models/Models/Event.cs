using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileApps.Models.Models
{
    public class Event : BaseModel
    {
        private Guid _EventID;
        private string _Name;

		[JsonProperty(PropertyName = "ID")]
        public Guid EventID
        {
            get { return _EventID; }
            set { _EventID = value; }
        }

		[JsonProperty(PropertyName = "Value")]
        public string EventName
        {
            get { return Name; }
            set { Name = value; }
        }
    }

	public class EventComparer : IEqualityComparer<Event>
	{
		public bool Equals(Event x, Event y)
		{
			return (x.EventID == y.EventID);
		}

		public int GetHashCode(Event obj)
		{
			int hashEventName = obj.Name == null ? 0 : obj.Name.GetHashCode();
			int hashEventGuid = obj.EventID.GetHashCode();
			return hashEventName ^ hashEventGuid;
		}
	}
}
