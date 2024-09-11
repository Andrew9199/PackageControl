using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string IdentificationType { get; set; }

        [PersonalData]
        public string IdentificationNumber { get; set; }

        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        // Relationships
        public ICollection<Package> Packages { get; set; }
    }
}