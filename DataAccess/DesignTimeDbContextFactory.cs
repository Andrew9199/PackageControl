using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PackageControlDataContext>
{
    public PackageControlDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PackageControlDataContext>();
        optionsBuilder.UseSqlServer("Server=DESKTOP-SOMFH3C\\SQLEXPRESS;Database=PackageControlDB;User Id=sa;Password=sa;Encrypt=False");

        return new PackageControlDataContext(optionsBuilder.Options);
    }
}