using System.Threading.Tasks;
using EmployeeDirectory.Example.Domain;
using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.BLL.Contracts
{
    public interface IDepartmentGetService
    {
        Task ValidateAsync(IDepartmentContainer departmentContainer);
    }
}