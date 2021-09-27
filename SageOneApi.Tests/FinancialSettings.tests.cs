using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client;
using SageOneApi.Client.Models;
using SageOneApi.Tests.TestHelpers.SampleFiles;
using System;

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
				Assert.IsNull(finset.AccountsStartDate);
				Assert.IsNull(finset.MtdAuthenticatedDate);
				Assert.AreEqual("31/12/2021", finset.YearEndDate.Value.ToString("dd/MM/yyyy"));
			}
		}
	}
}
