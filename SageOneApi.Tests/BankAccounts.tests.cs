﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			public void Test_Deserialization_GetAll()
			{
				string json = JsonTestFileReader.GetJson("GetAll_BankAccount.json");

				var bankAccounts = JsonDeserializer.DeserializeObjects<BankAccount>(json);			
			}
		}
	}
}
