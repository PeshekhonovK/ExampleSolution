using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Models;

namespace EmployeeDirectory.Example.BLL.Contracts
{
    public interface IEmployeeCreateService
    {
        Task<Employee> CreateAsync(EmployeeUpdateModel employee);
    }
}