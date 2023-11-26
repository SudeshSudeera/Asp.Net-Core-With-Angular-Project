using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelService
{
    public class ApplicationUser : IdentityUser
    {
        public string Notes { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ProfilePic { get; set; }
        public string BirthDay { get; set; }
        public bool IsProfileComplete { get; set; }
        public bool Terms { get; set; }
        public bool IsEmployee { get; set; }
        public string UserRole { get; set; }
        public DateTime AccountCreatedOn { get; set; }
        public bool RememberMe { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AddressModel> UserAddresses { get; set; }
    }
}
