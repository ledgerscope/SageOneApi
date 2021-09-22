using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using System;

namespace SageOneApi.Client
{
	public partial class SageOneApiClientTransferHandler
	{
		[TestClass]
		public class UnitTests
		{
			[TestMethod]
			public void Test_deserialization()
			{
				// https://api.accounting.sage.com/v3.1/sales_invoices?page=1&attributes=date&sort=date:asc&items_per_page=1
				string json = @"
{
  `$total`: 2,
  `$page`: 1,
  `$next`: `/sales_invoices?page=2&items_per_page=1&attributes=date&sort=date:asc`,
  `$back`: null,
  `$itemsPerPage`: 1,
  `$items`: [
    {
      `id`: `722548a1a599461796bbfc4a6b8b0ae2`,
      `displayed_as`: `SI-1`,
      `$path`: `/sales_invoices/722548a1a599461796bbfc4a6b8b0ae2`,
      `date`: `2015-02-19`,
      `created_at`: `2021-09-09T14:36:01Z`
    }
  ]
}".Replace('`', '"');

				//Newtonsoft.Json.JsonConvert.DefaultSettings = () 
				//	=> new Newtonsoft.Json.JsonSerializerSettings()
				//	{
				//		DateFormatString = 
				//		DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
				//		DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local,
				//		DateParseHandling = Newtonsoft.Json.DateParseHandling.DateTimeOffset
				//	};


				//var settings = new Newtonsoft.Json.JsonSerializerSettings()
				//{
				//	DateFormatString = "yyyy-MM-dd"
				//	// DateFormatHandling = Newtonsoft.Json.DateFormatHandling.
				//};

				//GetAllResponse<SalesInvoice> response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAllResponse<SalesInvoice>>(json, settings);


				// GetAllResponse<SalesInvoice> response = Newtonsoft.Json.JsonConvert.DeserializeObject<GetAllResponse<SalesInvoice>>(json);


				GetAllResponse<SalesInvoice> response = System.Text.Json.JsonSerializer.Deserialize<GetAllResponse<SalesInvoice>>(json);


				SalesInvoice[] items = response.Items;
				Assert.AreEqual(1, items.Length);

				SalesInvoice item = items[0];
				Assert.AreEqual("722548a1a599461796bbfc4a6b8b0ae2", item.Id);
				Assert.AreEqual("SI-1", item.DisplayedAs);
				Assert.AreEqual("/sales_invoices/722548a1a599461796bbfc4a6b8b0ae2", item.Path);

				Assert.AreEqual("2021-09-09 14:36:01Z", item.CreatedAt.GetValueOrDefault().ToString("u"));

				Assert.AreEqual("2015-02-19 00:00:00Z", DateTime.Parse("2015-02-19").ToString("u"));

				Assert.AreEqual("2015-02-19 00:00:00Z", item.Date.ToString("u"));

			}
		}
	}
}
