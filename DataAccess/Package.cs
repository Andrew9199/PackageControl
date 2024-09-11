using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Package
    {
        public string PackageId { get; set; }
        public string AddressNeighborhood { get; set; }
        public string AddressParish { get; set; }
        public string AddressMainStreet { get; set; }
        public string AddressSecondaryStreet { get; set; }
        public string HouseNumber { get; set; }

        // Foreign Key
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
