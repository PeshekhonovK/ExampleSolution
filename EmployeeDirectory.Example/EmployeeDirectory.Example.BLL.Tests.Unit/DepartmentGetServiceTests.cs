using System;
using System.Threading.Tasks;
using AutoFixture;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.BLL.Implementation;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace EmployeeDirectory.Example.BLL.Tests.Unit
{
    [TestFixture]
    public class DepartmentGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_DepartmentExists_DoesNothing()
        {
            // Arrange
            var departmentContainer = new Mock<IDepartmentContainer>();

            var department = new Department();
            var departmentDataAccess = new Mock<IDepartmentDataAccess>();
            departmentDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync(department);

            var departmentGetService = new DepartmentGetService(departmentDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => departmentGetService.ValidateAsync(departmentContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_DepartmentNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var departmentContainer = new Mock<IDepartmentContainer>();
            departmentContainer.Setup(x => x.DepartmentId).Returns(id);

            var department = new Department();
            var departmentDataAccess = new Mock<IDepartmentDataAccess>();
            departmentDataAccess.Setup(x => x.GetByAsync(departmentContainer.Object)).ReturnsAsync((Department)null);

            var departmentGetService = new DepartmentGetService(departmentDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => departmentGetService.ValidateAsync(departmentContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Department not found by id {id}");
        }
    }
}