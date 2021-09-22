using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class Artefact : PropertyValueWithPath
	{
		[JsonPropertyName("links")]
		public List<Link> Links { get; set; }
	}
}
