using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client;
using SageOneApi.Tests.TestHelpers.SampleFiles;
using System;

namespace SageOneApi.Tests
{
	public class DeserializationDateTests
	{
		[TestClass]
		public class UnitTests
		{
			[TestMethod]
			public void TestDateTime_Parse()
			{
				// by default this doesn't work, but with our custom deserializer we have custom DateTime handlers so that it does (see tests later in this class)
				Assert.ThrowsException<ArgumentNullException>(() => DateTime.Parse(null));
				Assert.ThrowsException<FormatException>(() => DateTime.Parse(""));
				Assert.ThrowsException<FormatException>(() => DateTime.Parse("     "));

				// this is never going to work
				Assert.ThrowsException<FormatException>(() => DateTime.Parse("gin o'clock"));

				Assert.AreEqual("2015-02-19 00:00:00Z", DateTime.Parse("2015-02-19").ToString("u"));

				DateTime? a = DateTime.Parse("2021-09-24");
				Assert.AreEqual("24/09/2021", a.Value.ToString("dd/MM/yyyy"));

				DateTime? b = DateTime.Parse("2021-09-09T14:36:01Z");

				// This test would work during summer time (BST), because it shows as local time
				// Assert.AreEqual("2021-09-09 15:36:01Z", b.Value.ToString("u"));

				// This test would work during winter time (GMT), because it shows as local time
				// Assert.AreEqual("2021-09-09 14:36:01Z", b.Value.ToString("u"));

				// This test works all of the time, because it shows as universal time (UTC/GMT)
				Assert.AreEqual("xxx 2021-09-09 14:36:01Z", b.Value.ToUniversalTime().ToString("u"));
			}

			[TestMethod]
			public void Test_DaysOfChristmas()
			{
				string json = JsonTestFileReader.GetJson("DatesTestData.json");
				var doc = JsonDeserializer.DeserializeObject<DaysOfChristmas>(json);

				Assert.IsTrue(doc.FinishForChristmas.HasValue);
				Assert.AreEqual("2021-12-23 15:30:00Z", doc.FinishForChristmas.Value.ToString("u"));

				Assert.IsTrue(doc.ChristmasEve.HasValue);
				Assert.IsTrue(doc.FinishForChristmas.HasValue);

				Assert.AreEqual("2021-12-24 00:00:00Z", doc.ChristmasEve.Value.ToString("u"));
				Assert.IsNull(doc.ChristmasDay);
				Assert.IsNull(doc.BoxingDay);
				Assert.IsNull(doc.NewYearsDay);
			}

			private class DaysOfChristmas
			{
				public DateTime? FinishForChristmas { get; set; }
				public DateTime? ChristmasEve { get; set; }
				public DateTime? ChristmasDay { get; set; }
				public DateTime? BoxingDay { get; set; }
				public DateTime? NewYearsDay { get; set; }

			}
		}
	}
}
