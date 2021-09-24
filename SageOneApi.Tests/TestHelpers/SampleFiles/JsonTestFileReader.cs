using System;
using System.IO;
using System.Reflection;

namespace SageOneApi.Tests.TestHelpers.SampleFiles
{
	internal static class JsonTestFileReader
	{
		internal static string GetJson(string fileName)
		{
			var assembly = Assembly.GetExecutingAssembly();
			var resourcePath = $"{typeof(JsonTestFileReader).Namespace}.{fileName}";

			string json;
			using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
			{
				if (stream is null)
				{
					throw new FileNotFoundException($"Embedded json file not found: {resourcePath}");
				}

				using (StreamReader reader = new StreamReader(stream))
				{
					json = reader.ReadToEnd();
				}
			}
			return json;
		}
	}
}
