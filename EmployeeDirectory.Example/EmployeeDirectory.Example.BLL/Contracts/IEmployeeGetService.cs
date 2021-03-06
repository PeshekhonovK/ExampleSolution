using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.BLL.Contracts
{
    public interface IEmployeeGetService
    {
        Task<IEnumerable<Employee>> GetAsync();
        Task<Employee> GetAsync(IEmployeeIdentity employee);
    }
}