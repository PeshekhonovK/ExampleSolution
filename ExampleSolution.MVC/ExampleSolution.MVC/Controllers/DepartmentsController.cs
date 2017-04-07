using ExampleSolution.MVC.ExampleService;
using ExampleSolution.MVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ExampleSolution.MVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public ActionResult Departments()
        {
            using (var service = new ExampleServiceClient())
            {
                return this.View(service.GetDepartments().Select(x => new Department().MapFrom(x)).ToArray());
            }
        }

        public ActionResult EmployeeList(Guid departmentId)
        {
            using (var service = new ExampleServiceClient())
            {
                return this.View(new Department().MapFrom(service.GetDepartmentById(departmentId)));
            }
        }
    }
}