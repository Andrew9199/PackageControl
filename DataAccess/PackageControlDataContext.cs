using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class PackageControlDataContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public PackageControlDataContext(DbContextOptions<PackageControlDataContext> options)
            : base(options)
        {
        }

        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de ApplicationUser
            modelBuilder.Entity<ApplicationUser>(applicationUser =>
            {
                applicationUser.Property(c => c.Id).IsRequired();
                applicationUser.Property(c => c.IdentificationType).IsRequired();
                applicationUser.Property(c => c.IdentificationNumber).IsRequired();
                applicationUser.Property(c => c.FirstName).IsRequired();
                applicationUser.Property(c => c.LastName).IsRequired();

                // Definimos la relación de uno a muchos
                applicationUser.HasMany(c => c.Packages)
                    .WithOne(p => p.ApplicationUser)
                    .HasForeignKey(p => p.ApplicationUserId); // Clave foránea
            });

            // Configuración de Package
            modelBuilder.Entity<Package>(package =>
            {
                package.HasKey(p => p.PackageId); // Clave primaria
                package.Property(p => p.AddressNeighborhood).IsRequired();
                package.Property(p => p.AddressParish).IsRequired();
                package.Property(p => p.AddressMainStreet).IsRequired();
                package.Property(p => p.AddressSecondaryStreet).IsRequired();
                package.Property(p => p.HouseNumber).IsRequired();

                // La relación con ApplicationUser ya está definida en ApplicationUser
                // No es necesario volver a configurarla aquí.
            });
        }
    }
}