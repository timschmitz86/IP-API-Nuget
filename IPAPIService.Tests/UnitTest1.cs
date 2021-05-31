using System;
using Xunit;
using IPAPIService;
using System.Globalization;
using System.Diagnostics;

namespace IPAPIService.Tests
{
    public class UnitTestSingleCalls
    {
        [Fact]
        public async void CheckSingleCall()
        {
            RegionInfo US =new RegionInfo((await IP_API.IPAPIService.GetLanguageIPAPI("8.8.8.8")).countryCode);
            RegionInfo refUS = new RegionInfo("US");
            Debug.WriteLine(US.Name+ " vs " + refUS.Name);
            Assert.True(US.Name == refUS.Name, "Region is correct");
        }

        [Fact]
        public async void CheckSingleCallNeg()
        {
            var result = await IP_API.IPAPIService.GetLanguageIPAPI("555.555.555.555");
            Assert.True(string.IsNullOrEmpty(result?.country), "Format is wrong");
        }
    }
}
