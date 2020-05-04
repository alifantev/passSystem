using PassSystem.Domain.EmployeePasses;
using System.Data.Entity;

namespace PassSystem.Repositories.EmployeePasses.DbContexts
{
    public class EmployeePassDbContext : DbContext
    {
        public EmployeePassDbContext(string connectionString)
            :base(connectionString)
        {}
        
        public DbSet<EmployeePass> EmployeePasses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeePass>()
                .HasKey(x => x.Id)
                .ToTable("employeePasses")
                .HasRequired(e => e.Employee);
            
            base.OnModelCreating(modelBuilder);
        }
        
    }
}