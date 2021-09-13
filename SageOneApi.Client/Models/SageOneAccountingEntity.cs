using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models
{
	/// <summary>Accounting data items.</summary>
	public abstract class SageOneAccountingEntity
	{
		[JsonProperty("$path")]
		public string Path { get; set; }
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }
		[JsonProperty("updated_at")]
		public DateTime? UpdatedAt { get; set; }
	}
}
