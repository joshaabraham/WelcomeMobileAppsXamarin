using System;
using Newtonsoft.Json;

namespace MobileApps.Models.Models
{
    public abstract class BaseModel
    {
		//Base Model
		[JsonProperty(PropertyName = "Name")]
		public string Name { get; set; }

		private string _langKey;
		public string Language
		{
			get { return _langKey; }
			set { _langKey = value; }
		}

		public Guid OrganizationId { get; set; }

	}
}
