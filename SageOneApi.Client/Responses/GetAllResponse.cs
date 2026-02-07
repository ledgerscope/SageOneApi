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
		public string? Next { get; set; }

		[JsonPropertyName("$back")]
		public string Back { get; set; }

		[JsonPropertyName("$itemsPerPage")]
		public int ItemsPerPage { get; set; }

		[JsonPropertyName("$items")]
		public T[] Items { get; set; }
	}
}
