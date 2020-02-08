using Example.BLL;
using Ninject;
using System;

namespace Example.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new BLLModule());

            var departmentBLL = kernel.Get<IDepartmentBLL>();
            var employeeBLL = kernel.Get<IEmployeeBLL>();

            var source = departmentBLL.CreateNew("source");
            var employee = employeeBLL.Register("test", "test", "test", source, 1000);

            var target = departmentBLL.CreateNew("target");
            departmentBLL.MoveAllEmployeesTo(source, target);

            Console.WriteLine(employee.Department.Name);
        }
    }
}
