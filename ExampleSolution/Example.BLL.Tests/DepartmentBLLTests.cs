using Example.DAL;
using Example.Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;

namespace Example.BLL.Tests
{
    [TestFixture]
    public class DepartmentBLLTests
    {
        [Test]
        public void MoveAllEmployeesTo_SameDepartments_ThrowsError()
        {
            //Arrange
            var department = new Department("test");

            var repository = new Mock<IRepository>();

            var bll = new DepartmentBLL(repository.Object, new EmployeeBLL(repository.Object));

            //Act, Assert
            new Action(() => bll.MoveAllEmployeesTo(department, department)).ShouldThrow<ArgumentException>();
        }
    }
}
