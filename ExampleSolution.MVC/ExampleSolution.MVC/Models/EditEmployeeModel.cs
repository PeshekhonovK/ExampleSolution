using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExampleSolution.MVC.Models
{
    public class EditEmployeeModel
    {
        public Guid Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        public decimal Salary { get; set; }

        public Guid DepartmentId { get; set; }

        public Guid CurrentDepartmentId { get; set; }

        public ICollection<Department> AvailableDepartments { get; set; }
    }
}