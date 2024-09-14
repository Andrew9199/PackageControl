using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class B_Package
    {
        private readonly PackageControlDataContext _context;

        public B_Package(PackageControlDataContext context)
        {
            _context = context;
        }

        public List<Package> GetPackages()
        {
            return _context.Packages
                .Include(p => p.ApplicationUser)
                .OrderBy(p => p.PackageId)
                .ToList();
        }

        public Package GetPackageById(string packageId)
        {
            return _context.Packages
                .Include(p => p.ApplicationUser)
                .FirstOrDefault(p => p.PackageId == packageId);
        }

        public void CreatePackage(Package package)
        {
            _context.Packages.Add(package);
            _context.SaveChanges();
        }

        public void UpdatePackage(Package package)
        {
            _context.Packages.Update(package);
            _context.SaveChanges();
        }

        public void DeletePackage(string packageId)
        {
            var package = _context.Packages.FirstOrDefault(p => p.PackageId == packageId);
            if (package != null)
            {
                _context.Packages.Remove(package);
                _context.SaveChanges();
            }
        }
    }
}