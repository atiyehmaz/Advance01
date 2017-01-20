using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MvcAdvance01.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        static ApplicationDbContext ()
        {
            System.Data.Entity.Database.SetInitializer(new
            System.Data.Entity.MigrateDatabaseToLatestVersion<ApplicationDbContext,Migrations.Configuration>());
        }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Personel> Personels { get; set; }

       

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Utility.Years> Years { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Utility.Mount> Mounts { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Salary> Salaries { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.baseSalary> baseSalaries { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.CustomerType> CustomerTypes { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.ProductCategory> ProductCategories { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Models.PriceType> PriceTypes { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Areas.Administrator.Models.PostCategory> PostCategories { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Areas.Administrator.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Areas.Administrator.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Areas.Administrator.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<MvcAdvance01.Areas.Administrator.ViewModels.AdminViewModels> AdminViewModels { get; set; }

      
    }
}