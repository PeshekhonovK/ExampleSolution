using ExampleSolution.MVC.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExampleSolution.MVC.Models
{
    public class EditEmployeeModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-zА-Яа-я._-]+", ErrorMessage = "Wrong name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-zА-Яа-я._-]+", ErrorMessage = "Wrong name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"[A-Za-zА-Яа-я._-]+", ErrorMessage = "Wrong name")]
        public string MiddleName { get; set; }

        [Display(Name = "Salary")]
        [MinValue(MinValue = 0)]
        public decimal Salary { get; set; }

        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        public Guid CurrentDepartmentId { get; set; }

        public ICollection<Department> AvailableDepartments { get; set; }
    }
}