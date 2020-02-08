using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Example.Domain
{
    [Table("Departments")]
    public class DepartmentEntity
    {
        [Key]
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();

        public DepartmentEntity MapToEntity(Department department)
        {
            this.Id = department.Id;
            this.Name = department.Name;

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
