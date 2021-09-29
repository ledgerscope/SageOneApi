using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using SageOneApi.Tests.TestHelpers.SampleFiles;
using System;

namespace SageOneApi.Tests
{
	public class BankAccountssTests
	{
		[TestClass]
		public class UnitTests
		{
			[TestMethod]
			public void Test_Deserialization_BankAccounts()
			{
				string json = JsonTestFileReader.GetJson("BankAccounts.json");

				var finset = JsonDeserializer.DeserializeObjects<BankAccount>(json);
				
			}
		}
	}
}
