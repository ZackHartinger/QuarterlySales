using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace QuarterlySales.Models
{
	public class QuarterlySalesContext : IdentityDbContext<User>
	{
		public QuarterlySalesContext(DbContextOptions<QuarterlySalesContext> options) : base(options) { }

		public DbSet<Employee> Employees { get; set; } = null!;

		public DbSet<Sale> Sales { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Employee>().HasData(
				new Employee
				{
					EmployeeId = 1,
					FirstName = "Joyce",
					LastName = "Valdez",
					DOB = new DateTime(1956, 12, 10),
					HireDate = new DateTime(1995, 1, 1),
					ManagerId = 0
				});
		}       
    }
}
