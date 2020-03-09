using System;
using System.Threading.Tasks;
using AutoFixture;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.BLL.Implementation;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace EmployeeDirectory.Example.BLL.Tests.Unit
{
    public class EmployeeCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_DepartmentValidationSucceed_CreatesEmployee()
        {
            // Arrange
            var employee = new EmployeeUpdateModel();
            var expected = new Employee();
            
            var departmentGetService = new Mock<IDepartmentGetService>();
            departmentGetService.Setup(x => x.ValidateAsync(employee));

            var employeeDataAccess = new Mock<IEmployeeDataAccess>();
            employeeDataAccess.Setup(x => x.InsertAsync(employee)).ReturnsAsync(expected);

            var employeeGetService = new EmployeeCreateService(employeeDataAccess.Object, departmentGetService.Object);
            
            // Act
            var result = await employeeGetService.CreateAsync(employee);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_DepartmentValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var employee = new EmployeeUpdateModel();
            var expected = fixture.Create<string>();
            
            var departmentGetService = new Mock<IDepartmentGetService>();
            departmentGetService
                .Setup(x => x.ValidateAsync(employee))
                .Throws(new InvalidOperationException(expected));

            var employeeDataAccess = new Mock<IEmployeeDataAccess>();

            var employeeGetService = new EmployeeCreateService(employeeDataAccess.Object, departmentGetService.Object);
            
            // Act
            var action = new Func<Task>(() => employeeGetService.CreateAsync(employee));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            employeeDataAccess.Verify(x => x.InsertAsync(employee), Times.Never);
        }
    }
}