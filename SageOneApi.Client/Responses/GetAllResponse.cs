using System.Text.Json.Serialization;

namespace SageOneApi.Client.Responses
{
	public class GetAllResponse<T>
	{
		[JsonPropertyName("$total")]
		public int Total { get; set; }

		[JsonPropertyName("$page")]
		public int Page { get; set; }

		[JsonPropertyName("$next")]
		public object Next { get; set; }

		[JsonPropertyName("$back")]
		public object Back { get; set; }

		[JsonPropertyName("$itemsPerPage")]
		public int ItemsPerPage { get; set; }

		[JsonPropertyName("$items")]
		public T[] Items { get; set; }
	}
}
