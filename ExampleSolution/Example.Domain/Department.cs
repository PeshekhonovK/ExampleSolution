using System;
using System.Collections.Generic;

namespace Example.Domain
{
    public class Department
    {
        public Guid Id { get; set; }

        public string Name { get; }

        public ICollection<Employee> Employees { get; } = new List<Employee>();

        public Department(string name)
        {
            this.Name = name;
        }
    }
}
