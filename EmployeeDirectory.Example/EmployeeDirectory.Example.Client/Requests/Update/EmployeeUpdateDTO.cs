using EmployeeDirectory.Example.Client.Requests.Create;

namespace EmployeeDirectory.Example.Client.Requests.Update
{
    public class EmployeeUpdateDTO : EmployeeCreateDTO
    {
        public int Id { get; set; }
    }
}