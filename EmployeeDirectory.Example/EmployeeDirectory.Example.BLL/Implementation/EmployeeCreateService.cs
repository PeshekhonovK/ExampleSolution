using System.Threading.Tasks;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.Example.BLL.Implementation
{
    public class EmployeeCreateService : IEmployeeCreateService
    {
        private IEmployeeDataAccess EmployeeDataAccess { get; }
        private IDepartmentDataAccess DepartmentDataAccess { get; }
        
        public EmployeeCreateService(IEmployeeDataAccess employeeDataAccess, IDepartmentDataAccess departmentDataAccess)
        {
            this.EmployeeDataAccess = employeeDataAccess;
            this.DepartmentDataAccess = departmentDataAccess;
        }

        public async Task<Employee> CreateAsync(EmployeeUpdateModel employee)
        {
            var department = employee.DepartmentId.HasValue 
                ? await this.DepartmentDataAccess.GetByAsync(employee.DepartmentId.Value) 
                : null;
            
            return await this.EmployeeDataAccess.InsertAsync(employee, department);
        }
    }
}