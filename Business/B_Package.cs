using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class B_Package
    {
        private readonly PackageControlDataContext _context;

        public B_Package(PackageControlDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea un nuevo Package y lo guarda en la base de datos.
        /// </summary>
        /// <param name="package">El objeto Package a guardar.</param>
        /// <returns>El paquete creado.</returns>
        public async Task<Package> CreatePackageAsync(Package package)
        {
            // Validar el paquete antes de guardarlo
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            // Asignar un nuevo ID de paquete si no está presente
            if (string.IsNullOrEmpty(package.PackageId))
            {
                package.PackageId = Guid.NewGuid().ToString();
            }

            // Agregar el paquete al DbContext
            _context.Packages.Add(package);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return package;
        }

        /// <summary>
        /// Obtiene un paquete por su ID.
        /// </summary>
        /// <param name="packageId">El ID del paquete.</param>
        /// <returns>El paquete encontrado o null si no existe.</returns>
        public async Task<Package?> GetPackageByIdAsync(string packageId)
        {
            return await _context.Packages
                .Include(p => p.ApplicationUser) // Incluir los datos del usuario asociado
                .FirstOrDefaultAsync(p => p.PackageId == packageId);
        }

        /// <summary>
        /// Obtiene todos los paquetes registrados.
        /// </summary>
        /// <returns>Una lista de todos los paquetes.</returns>
        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            return await _context.Packages
                .Include(p => p.ApplicationUser) // Incluir los datos del usuario asociado
                .ToListAsync();
        }

        /// <summary>
        /// Elimina un paquete por su ID.
        /// </summary>
        /// <param name="packageId">El ID del paquete a eliminar.</param>
        /// <returns>True si el paquete fue eliminado, false si no se encontró.</returns>
        public async Task<bool> DeletePackageAsync(string packageId)
        {
            var package = await _context.Packages.FindAsync(packageId);
            if (package == null)
            {
                return false;
            }

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Actualiza los detalles de un paquete existente.
        /// </summary>
        /// <param name="package">El paquete actualizado.</param>
        /// <returns>El paquete actualizado.</returns>
        public async Task<Package?> UpdatePackageAsync(Package package)
        {
            var existingPackage = await _context.Packages.FindAsync(package.PackageId);
            if (existingPackage == null)
            {
                return null; // No se encontró el paquete
            }

            // Actualizar los campos
            existingPackage.AddressNeighborhood = package.AddressNeighborhood;
            existingPackage.AddressParish = package.AddressParish;
            existingPackage.AddressMainStreet = package.AddressMainStreet;
            existingPackage.AddressSecondaryStreet = package.AddressSecondaryStreet;
            existingPackage.HouseNumber = package.HouseNumber;

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            return existingPackage;
        }
    }
}
