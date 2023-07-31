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
			public void Test_Deserialization_FinancialSettings()
			{
				string json = JsonTestFileReader.GetJson("SalesInvoices.json");

				var response = JsonDeserializer.DeserializeObject<GetAllResponse<SalesInvoice>>(json);
				var invoices = response.Items.FirstOrDefault();
				
				Assert.IsNull(invoices.TotalPaid);
				Assert.IsFalse(invoices.Sent);
				Assert.AreEqual(DateTime.Parse("2021-09-09T14:36:01Z"), invoices.CreatedAt.Value);
			}
		}
	}
}
