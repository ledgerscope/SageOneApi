using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using SageOneApi.Tests.TestHelpers.SampleFiles;
using System;
using System.Linq;

namespace SageOneApi.Tests
{
	public class SalesInvoicesTests
	{
		[TestClass]
		public class UnitTests
		{
            [TestMethod]
            public void Test_Deserialization_GetAll()
            {
                string json = JsonTestFileReader.GetJson("GetAll_SalesInvoice.json");

                GetAllResponse<SalesInvoice> response = JsonDeserializer.DeserializeObjects<SalesInvoice>(json);

                SalesInvoice[] items = response.Items;
                Assert.AreEqual(1, items.Length);

                SalesInvoice item = items[0];
                Assert.AreEqual("722548a1a599461796bbfc4a6b8b0ae2", item.Id);
                Assert.AreEqual("SI-1", item.DisplayedAs);
                Assert.AreEqual("/sales_invoices/722548a1a599461796bbfc4a6b8b0ae2", item.Path);
                Assert.AreEqual("2015-02-19 00:00:00Z", item.Date.ToString("u"));
                Assert.AreEqual("2021-09-09 14:36:01Z", item.CreatedAt.GetValueOrDefault().ToUniversalTime().ToString("u"));
                Assert.IsNull(item.TotalPaid);
                Assert.IsFalse(item.Sent);
                Assert.AreEqual(DateTime.Parse("2021-09-09T14:36:01Z"), item.CreatedAt.Value);
            }
        }
	}
}
