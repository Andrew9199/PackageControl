using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PackageControlDataContext>
{
    public PackageControlDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PackageControlDataContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-7BMEFPA\\SQLEXPRESS;Database=PackageControlDB;User Id=sa;Password=sa;Encrypt=False");

        return new PackageControlDataContext(optionsBuilder.Options);
    }
}