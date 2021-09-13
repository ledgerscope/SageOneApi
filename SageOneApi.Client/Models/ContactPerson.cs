using System;
using Newtonsoft.Json;

namespace SageOneApi.Client.Models
{
	public class ContactPerson : SageOneAccountingEntity
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("job_title")]
		public string JobTitle { get; set; }
		[JsonProperty("telephone")]
		public string Telephone { get; set; }
		[JsonProperty("mobile")]
		public string Mobile { get; set; }
		[JsonProperty("email")]
		public string Email { get; set; }
		[JsonProperty("fax")]
		public string Fax { get; set; }
		[JsonProperty("is_mail_contact")]
		public bool IsMailContact { get; set; }
		[JsonProperty("is_preferred_contact")]
		public bool IsPreferredContact { get; set; }
		[JsonProperty("address")]
		public Address Address { get; set; }
		[JsonProperty("deleted_at")]
		public DateTime? DeletedAt { get; set; }
	}
}
