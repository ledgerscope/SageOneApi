using System.Text.Json.Serialization;
using System;

namespace SageOneApi.Client.Models
{
	/// <summary>Accounting data items.</summary>
	public abstract class SageOneAccountingEntity
	{
		[JsonPropertyName("$path")]
		public string Path { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("displayed_as")]
		public string DisplayedAs { get; set; }

		[JsonPropertyName("created_at")]
		public DateTime? CreatedAt { get; set; }

		[JsonPropertyName("updated_at")]
		public DateTime? UpdatedAt { get; set; }
		
		[JsonPropertyName("deleted_at")]
		public DateTime? DeletedAt { get; set; }
	}
}
