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
    }
}