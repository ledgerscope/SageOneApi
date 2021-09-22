using System;
using System.Text.Json.Serialization;

namespace SageOneApi.Client.Models
{
	public class ContactPerson : SageOneAccountingEntity
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("job_title")]
		public string JobTitle { get; set; }
		[JsonPropertyName("telephone")]
		public string Telephone { get; set; }
		[JsonPropertyName("mobile")]
		public string Mobile { get; set; }
		[JsonPropertyName("email")]
		public string Email { get; set; }
		[JsonPropertyName("fax")]
		public string Fax { get; set; }
		[JsonPropertyName("is_mail_contact")]
		public bool IsMailContact { get; set; }
		[JsonPropertyName("is_preferred_contact")]
		public bool IsPreferredContact { get; set; }
		[JsonPropertyName("address")]
		public Address Address { get; set; }
		[JsonPropertyName("deleted_at")]
		public DateTime? DeletedAt { get; set; }
	}
}
