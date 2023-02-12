using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    public class ProductTests
    {
        [Fact]
        public void GetPrice_GoldCustomer_Applay30PercentDiscount()
        {
            var product = new Product(){ ListPrice = 100};
            var result = product.GetPrice(new Customer() { IsGold = true });
           
            Assert.Equal(70, result);
        }
    }
}
