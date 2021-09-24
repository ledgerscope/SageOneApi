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
			public void TestDateTime_Parse()
			{
				Assert.ThrowsException<ArgumentNullException>(() => DateTime.Parse(null));

				Assert.ThrowsException<FormatException>(() => DateTime.Parse(""));
				Assert.ThrowsException<FormatException>(() => DateTime.Parse("     "));
				Assert.ThrowsException<FormatException>(() => DateTime.Parse("gin o'clock"));

				DateTime? b = DateTime.Parse("2021-09-24");
				Assert.AreEqual("24/09/2021", b.Value.ToString("dd/MM/yyyy"));
			}

			[TestMethod]
			public void Test_DaysOfChristmas()
			{
				string json = JsonTestFileReader.GetJson("DaysOfChristmas.json");
				var doc = JsonDeserializer.DeserializeObject<DaysOfChristmas>(json);

				Assert.AreEqual("24/12/2021", doc.ChristmasEve.Value.ToString("dd/MM/yyyy"));
				Assert.IsNull(doc.ChristmasDay);
				Assert.IsNull(doc.BoxingDay);
			}

			[TestMethod]
			public void Test_Deserialization_FinancialSettings()
			{
				string json = JsonTestFileReader.GetJson("FinancialSettings.json");

				FinancialSettings finset = JsonDeserializer.DeserializeObject<FinancialSettings>(json);
				Assert.IsNull(finset.AccountsStartDate);
				Assert.IsNull(finset.MtdAuthenticatedDate);
				Assert.AreEqual("31/12/2021", finset.YearEndDate.Value.ToString("dd/MM/yyyy"));
			}

			private class DaysOfChristmas
			{
				public DateTime? ChristmasEve { get; set; }
				public DateTime? ChristmasDay { get; set; }
				public DateTime? BoxingDay { get; set; }
			}
		}
	}
}
