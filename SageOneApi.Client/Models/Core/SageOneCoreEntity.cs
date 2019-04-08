using Newtonsoft.Json;
using System;

namespace SageOneApi.Client.Models.Core
{
    public abstract class SageOneCoreEntity
    {
	    [JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("displayed_as")]
		public string DisplayedAs { get; set; }
		[JsonProperty("created_at")]
		public DateTime? CreatedAt { get; set; }
		[JsonProperty("updated_at")]
		public DateTime? UpdatedAt { get; set; }
		[JsonProperty("business_owner")]
		public bool BusinessOwner { get; set; }
    }
}
