using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client;
using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Tests.TestHelpers.SampleFiles;
using System;

namespace SageOneApi.Tests
{
	public class BusinessTests
	{
		[TestClass]
		public class UnitTests
		{
			[TestMethod]
			public void Test_Deserialization_GetAll()
			{
				string json = JsonTestFileReader.GetJson("GetAll_Business.json");

				var businesses = JsonDeserializer.DeserializeObjects<Business>(json);
			}
		}
	}
}
