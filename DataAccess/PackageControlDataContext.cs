using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PackageControlDataContext : IdentityDbContext
    {
        public PackageControlDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
