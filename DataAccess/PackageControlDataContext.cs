using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Entities;

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
            // Datos semilla para el rol
            var adminRoleId = "073401da-110e-4962-afdd-2a966d1f0d7b";
            var adminUserId = "9f19a2b2-73a1-4fb1-9529-dca5b147151a";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            // Datos semilla para el usuario
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "9f19a2b2-73a1-4fb1-9529-dca5b147151a",
                UserName = "Alex",
                NormalizedUserName = "ALEX",
                Email = "alex@gmail.com",
                NormalizedEmail = "ALEX@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEJCYB5eaPrSlWSpmizKppE/ThMBll4zUfiqKorrlTqIJESDY0dD5e75HSOUimnzpmQ==",
                //Contraseña: @Aa123
                SecurityStamp = "3MDBYHN34YWQIJOD6LHXCBAZ33SQOASS",
                ConcurrencyStamp = "72956ea5-a815-4093-b409-31b3f225680f",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                FirstName = "Alex",
                LastName = "Will",
                IdentificationNumber = "1999999999",
                IdentificationType = "Cedula"
            });


            // Relación usuario-rol
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });
        }
    }
}