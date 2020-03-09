using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.BLL.Implementation
{
    public class EmployeeGetService : IEmployeeGetService
    {
        private IEmployeeDataAccess EmployeeDataAccess { get; }
        
        public EmployeeGetService(IEmployeeDataAccess employeeDataAccess)
        {
            this.EmployeeDataAccess = employeeDataAccess;
        }

        public Task<IEnumerable<Employee>> GetAsync()
        {
            return this.EmployeeDataAccess.GetAsync();
        }

        public Task<Employee> GetAsync(IEmployeeIdentity employee)
        {
            return this.EmployeeDataAccess.GetAsync(employee);
        }
    }
}