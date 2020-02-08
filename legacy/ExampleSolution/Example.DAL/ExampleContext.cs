using Example.Domain;
using System.Data.Entity;

namespace Example.DAL
{
    internal class ExampleContext : DbContext
    {
        public ExampleContext() : base("ExampleContextConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ExampleContext>());
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
    }
}
