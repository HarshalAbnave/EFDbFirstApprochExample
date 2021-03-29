using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using EFDbFirstApprochExample.Identity;

[assembly: OwinStartup(typeof(EFDbFirstApprochExample.Startup))]

namespace EFDbFirstApprochExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login") });
            this.CreateRolesAndusers();
        }

        public void CreateRolesAndusers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            ApplicationDbContext appDbContext = new ApplicationDbContext();
            ApplicationUserStore appUserStore = new ApplicationUserStore(appDbContext);
            ApplicationUserManager appUserManager = new ApplicationUserManager(appUserStore);

            if(!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if(appUserManager.FindByName("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPassword = "admin123";

                var chkUser = appUserManager.Create(user,userPassword);
                if(chkUser.Succeeded)
                {
                    appUserManager.AddToRole(user.Id, "Admin");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if (appUserManager.FindByName("manager") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                string userPassword = "manager123";

                var chkUser = appUserManager.Create(user, userPassword);
                if (chkUser.Succeeded)
                {
                    appUserManager.AddToRole(user.Id, "Manager");
                }
            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
