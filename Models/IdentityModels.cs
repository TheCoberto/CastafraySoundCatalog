using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CastafraySoundCatalog.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
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
        //private ApplicationDbContext(string connectionString)
        //    : base(connectionString, throwIfV1Schema: false)
        //{
        //}

        //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        //{
        //    public ApplicationDbContext CreateDbContext(string[] args)
        //    {
        //        var secretClient = new SecretClient(new Uri("https://contentconnectionstring.vault.azure.net/"), new DefaultAzureCredential());
        //        var secret = secretClient.GetSecret("ConnectionString");

        //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //        optionsBuilder.UseSqlServer(secret.Value.Value); // replace with your actual DB provider if not using SQL Server

        //        return new ApplicationDbContext(optionsBuilder.Options);
        //    }
        //}

        //public static async Task<ApplicationDbContext> CreateAsync()
        //{
        //    var secretClient = new SecretClient(new Uri("https://contentconnectionstring.vault.azure.net/"), new DefaultAzureCredential());
        //    var secret = await secretClient.GetSecretAsync("ConnectionString");
        //    return new ApplicationDbContext(secret.Value.Value);
        //}
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}