using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace optometria.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string DocumentType { get; set; } = "CC";

        [MaxLength(30)]
        public string DocumentNumber { get; set; } = string.Empty;

        public DateOnly? BirthDate { get; set; }

        [MaxLength(150)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Country { get; set; } = "Colombia";

        [MaxLength(250)]
        public string EmergencyContact { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}".Trim();
    }

}
