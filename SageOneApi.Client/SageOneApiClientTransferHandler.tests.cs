using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using System;
using System.IO;
using System.Reflection;

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
				string json = getEmbeddedJson("SalesInvoices.json");

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

			private string getEmbeddedJson(string fileName)
			{
				var assembly = Assembly.GetExecutingAssembly();
				var resourcePath = $"{typeof(TestHelpers.SampleFiles.Namespacer).Namespace}.{fileName}";

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
}
