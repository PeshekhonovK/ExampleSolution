using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.Domain.Models
{
    public class EmployeeIdentityModel : IEmployeeIdentity
    {
        public int Id { get; }

        public EmployeeIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}