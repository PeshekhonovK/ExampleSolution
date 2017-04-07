using ExampleSolution.MVC.ExampleService;
using ExampleSolution.MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ExampleSolution.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Employee(Guid? employeeId, Guid departmentId)
        {
            using (var service = new ExampleServiceClient())
            {
                var employee = employeeId.HasValue ? new Employee().MapFrom(service.GetEmployee(employeeId.Value)) : null;

                var model = new EditEmployeeModel
                {
                    Id = employeeId ?? Guid.Empty,
                    FirstName = employee?.FirstName,
                    LastName = employee?.LastName,
                    MiddleName = employee?.MiddleName,
                    DepartmentId = departmentId,
                    AvailableDepartments = service.GetDepartments().Select(x => new Department().MapFrom(x)).ToArray(),
                    CurrentDepartmentId = departmentId
                };

                return this.View(model);
            }
        }

        [HttpPost]
        public ActionResult Save(EditEmployeeModel employee)
        {
            using (var service = new ExampleServiceClient())
            {
                var dto = new EmployeeDTO
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName
                };

                service.SaveEmployee(dto, service.GetDepartmentById(employee.DepartmentId));
            }

            return this.RedirectToAction("EmployeeList", "Departments", new { departmentId = employee.CurrentDepartmentId });
        }
    }
}