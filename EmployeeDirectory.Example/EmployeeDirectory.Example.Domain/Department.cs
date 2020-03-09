using System;
using EmployeeDirectory.Example.Domain.Contracts;

namespace EmployeeDirectory.Example.Domain
{
    public class Department
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Department Parent { get; set; }
    }
}