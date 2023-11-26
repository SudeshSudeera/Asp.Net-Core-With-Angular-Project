using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData( 
                new {id = "1", Name = "Administrator", NormalizedName = "ADMINISTRATOR", RoleName = "Administrator", Handle = "administrator", RoleIcon = "/uploads/roles/icons/default/role.png", IsActive = true },
                new {id = "2", Name = "Customer", NormalizedName = "CUSTOMER", RoleName = "customer", Handle = "customer", RoleIcon = "/uploads/roles/icons/default/role.png", IsActive = true }
            );
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<TokenModel> Tokens { get; set; }
        public DbSet<ActivityModel> Activities { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<TwoFactorCodeModel> TwoFactorCodes { get; set; }

    }
}
