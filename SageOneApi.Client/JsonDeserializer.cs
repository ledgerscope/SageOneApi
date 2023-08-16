using System;
using SageOneApi.Client.Responses;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.IO;

namespace SageOneApi.Client
{
#if DEBUG
	public // for testing
#else
	internal
#endif
	static class JsonDeserializer
	{
		private static readonly SourceGenerationContext _sourceGenerationContext = new SourceGenerationContext(getOptions());

        private static JsonSerializerOptions getOptions()
		{
			var options = new JsonSerializerOptions(JsonSerializerDefaults.General);

			options.NumberHandling = JsonNumberHandling.AllowReadingFromString;
			
			options.Converters.Add(new NullableDateTimeConverter());

			return options;
		}

		public static T DeserializeObject<T>(string json)
		{
			return JsonSerializer.Deserialize(json, (JsonTypeInfo<T>)_sourceGenerationContext.GetTypeInfo(typeof(T)));
		}

        public static T DeserializeObject<T>(Stream stream)
        {
            return JsonSerializer.Deserialize(stream, (JsonTypeInfo<T>)_sourceGenerationContext.GetTypeInfo(typeof(T)));
        }

        public static GetAllResponse<T> DeserializeObjects<T>(string json)
		{
			return JsonSerializer.Deserialize(json, (JsonTypeInfo<GetAllResponse<T>>)_sourceGenerationContext.GetTypeInfo(typeof(GetAllResponse<T>)));
        }

		private class NullableDateTimeConverter : JsonConverter<DateTime?>
		{
			public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				var sval = reader.GetString();
				if (string.IsNullOrWhiteSpace(sval))
					return null;
				else
					return DateTime.Parse(sval);
			}

			public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
			{
				writer.WriteStringValue(value.HasValue ? value.ToString() : null);
			}
		}
	}
}
