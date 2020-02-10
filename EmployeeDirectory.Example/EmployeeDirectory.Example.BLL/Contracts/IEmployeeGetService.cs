using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;

namespace EmployeeDirectory.Example.BLL.Contracts
{
    public interface IEmployeeGetService
    {
        Task<IEnumerable<Employee>> GetAsync();
        Task<Employee> GetAsync(int employeeId);
    }
}