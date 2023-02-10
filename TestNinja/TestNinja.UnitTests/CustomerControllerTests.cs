using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void GetCustomer_WhenIdIsZero_ReturnNotFound()
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(0);

            Assert.IsType<NotFound>(result);
        }

        [Fact]
        public void GetCustomer_WhenIsNotZero_ReturnOk()
        {
            var customerController = new CustomerController();

            var result = customerController.GetCustomer(1);

            Assert.IsType<Ok>(result);
        }
    }
}
