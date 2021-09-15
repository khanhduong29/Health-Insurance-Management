using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Health_Insurance_Management.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual int EmloyeeId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName): base(roleName) { }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ConnectionString", throwIfV1Schema: false)
        {
        }
        public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HospitalInfo> HospitalInfos { get; set; }
        public virtual DbSet<Policy> Policies { get; set; }
        public virtual DbSet<PolicyApprovalDetail> PolicyApprovalDetails { get; set; }
        public virtual DbSet<PolicyOnEmployee> PolicyOnEmployees { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}