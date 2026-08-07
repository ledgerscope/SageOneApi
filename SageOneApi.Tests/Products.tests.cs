using Microsoft.VisualStudio.TestTools.UnitTesting;
using SageOneApi.Client;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using SageOneApi.Tests.TestHelpers.SampleFiles;
using System;
using System.Linq;

namespace SageOneApi.Tests
{
    public class ProductsTests
    {
        [TestClass]
        public class UnitTests
        {
            [TestMethod]
            public void Test_Deserialization_GetAll()
            {
                string json = JsonTestFileReader.GetJson("GetAll_Product.json");

                GetAllResponse<Product> response = JsonDeserializer.DeserializeObjects<Product>(json);

                Product[] items = response.Items;
                Assert.AreEqual(3, items.Length);

                Product itemOne = items[0];
                Assert.IsNull(itemOne.Active);

                Product itemTwo = items[1];
                Assert.IsTrue(itemTwo.Active);

                Product itemThree = items[2];
                Assert.IsFalse(itemThree.Active);
            }
        }
    }
}
