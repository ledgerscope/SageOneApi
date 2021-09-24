using SageOneApi.Client.Responses;
using System.Text.Json;

namespace SageOneApi.Client
{
#if DEBUG
	public // for testing
#else
	internal
#endif
	static class JsonDeserializer
	{
		public static T DeserializeObject<T>(string json)
		{
			return JsonSerializer.Deserialize<T>(json);
		}

		public static GetAllResponse<T> DeserializeObjects<T>(string json)
		{
			return JsonSerializer.Deserialize<GetAllResponse<T>>(json);
		}
	}
}
