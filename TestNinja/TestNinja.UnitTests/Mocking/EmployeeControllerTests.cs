using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _storage;
        private EmployeeController _employeeController;
        public EmployeeControllerTests()
        {
            _storage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_storage.Object);
        }

        [Fact]
        public void DeleteEmployee_WhenCalled_DeleteEntity()
        {
            _storage.Setup(s => s.DeleteEmployee(1));
            _employeeController.DeleteEmployee(1);
            _storage.Verify(s => s.DeleteEmployee(1));
        }

        [Fact]
        public void DeleteEmployee_WhenCalled_RedirectToEmplyeeList()
        {
            var result = _employeeController.DeleteEmployee(1) as RedirectResult;

            Assert.IsType<RedirectResult>(result);
            
        }
    }
}
