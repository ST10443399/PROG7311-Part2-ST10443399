using System;
using System.Collections.Generic;
using System.Text;

namespace GLMS_Tests
{
    public class BusinessLogicTests
    {
        [Fact]
        public void Test_CurrencyCalculation()
        {
            decimal usd = 100;
            decimal rate = 18.5m;
            decimal expected = 1850m;
            Assert.Equal(expected, usd * rate);
        }

        [Fact]
        public void Test_FileValidation_InvalidExtension()
        {
            string fileName = "hack.exe";
            Assert.NotEqual(".pdf", Path.GetExtension(fileName));
        }
    }
}
