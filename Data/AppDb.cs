using Microsoft.EntityFrameworkCore;
namespace CrmApi.Data;
public class AppDb(DbContextOptions<AppDb> options):DbContext(options) {
public DbSet<Segment> Segments => Set<Segment>();
public DbSet<Employee> Employees => Set<Employee>();
public DbSet<Portfolio> Portfolios => Set<Portfolio>();
public DbSet<Customer> Customers => Set<Customer>();
protected override void OnModelCreating(ModelBuilder b) {
b.Entity<Segment>().ToTable("Segments","dbo");
b.Entity<Segment>().HasKey(x=>x.SegmentCode);
b.Entity<Employee>().ToTable("Employees","dbo");
b.Entity<Employee>().HasKey(x=>x.EmployeeCode);
b.Entity<Portfolio>().ToTable("Portfolios","dbo");
b.Entity<Portfolio>().HasKey(x=>x.PortfolioCode);
b.Entity<Customer>().ToTable("Customers","dbo");
b.Entity<Customer>().HasKey(x=>x.CustomerCode);
}
}
