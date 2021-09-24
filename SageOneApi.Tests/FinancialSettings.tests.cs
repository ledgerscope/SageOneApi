using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client;
using SageOneApi.Client.Models;
using SageOneApi.Tests.TestHelpers.SampleFiles;

namespace SageOneApi.Tests
{
	public class FinancialSettingsTests
	{
		[TestClass]
		public class UnitTests
		{
			[TestMethod]
			public void Test_Deserialization_FinancialSettings()
			{
				string json = JsonTestFileReader.GetJson("FinancialSettings.json");

				FinancialSettings finset = JsonDeserializer.DeserializeObject<FinancialSettings>(json);
			}
		}
	}
}
