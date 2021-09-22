using System.Text.Json.Serialization;
using System;

namespace SageOneApi.Client.Models.Core
{
	/// <summary>Metadata about the user or business.</summary>
	/// <remarks>See also <seealso cref="SageOneAccountingEntity"/>, which is on a different URL endpoint.</remarks>
	public abstract class SageOneCoreEntity
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("displayed_as")]
		public string DisplayedAs { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime? UpdatedAt { get; set; }

		[JsonPropertyName("business_owner")]
		public bool BusinessOwner { get; set; }
	}
}
