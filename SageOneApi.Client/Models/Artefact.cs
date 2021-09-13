using Newtonsoft.Json;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
	public class Artefact : PropertyValueWithPath
	{
		[JsonProperty("links")]
		public List<Link> Links { get; set; }
	}
}
