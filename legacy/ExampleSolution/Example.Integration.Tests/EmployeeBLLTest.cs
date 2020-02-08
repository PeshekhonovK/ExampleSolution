using Example.BLL;
using Example.DAL;
using NUnit.Framework;

namespace Example.Integration.Tests
{
    [TestFixture]
    public class EmployeeBLLTests
    {
        [Test]
        public void CreateEmployee()
        {
            //Arrange
            var repository = new Repository();

            var employeeBll = new EmployeeBLL(repository);

            var departmentBll = new DepartmentBLL(repository, employeeBll);

            var department = departmentBll.CreateNew("test");

            //Act
            employeeBll.Register("test", "test", "test", department, 1000);

            //Assert
            var result = repository.GetDepartmentById(department.Id);
        }

        [Test]
        public void MoveEmployee()
        {
            //Arrange
            var repository = new Repository();

            var employeeBll = new EmployeeBLL(repository);

            var departmentBll = new DepartmentBLL(repository, employeeBll);

            var department = departmentBll.CreateNew("test1");
            var department2 = departmentBll.CreateNew("test2");
            var employee = employeeBll.Register("test", "test", "test", department, 1000);

            //Act
            employeeBll.Move(employee, department2);

            //Assert
            var result = repository.GetDepartmentById(department2.Id);
        }
    }
}
