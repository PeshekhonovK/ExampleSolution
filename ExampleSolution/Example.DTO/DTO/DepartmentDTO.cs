using Example.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Example.DTO
{
    [DataContract]
    public class DepartmentDTO
    {
        [DataMember]
        public Guid Id { get; set; } = Guid.Empty;

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ICollection<EmployeeDTO> Employees { get; set; } = new List<EmployeeDTO>();

        public DepartmentDTO MapFromModel(Department department)
        {
            var employees = department.Employees.Select(x => new EmployeeDTO().MapFromModel(x)).ToList();

            this.Id = department.Id;
            this.Name = department.Name;

            this.Employees = employees;

            return this;
        }

        public Department MapToModel()
        {
            var department = new Department(this.Name) { Id = this.Id };
            ((List<Employee>)department.Employees).AddRange(this.Employees.Select(x => x.MapToModel(department)));

            return department;
        }
    }
}
