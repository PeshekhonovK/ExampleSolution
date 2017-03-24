using System;
using System.Collections.Generic;

namespace ExampleSolution.WPF.Models
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
