using PassSystem.Domain.EmployeePasses;
using System.Data.Entity;

namespace PassSystem.Repositories.EmployeePasses.DbContexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(string connectionString)
            :base(connectionString)
        { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(x => x.Id)
                .ToTable("employees");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
