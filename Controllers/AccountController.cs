using System.Web.Mvc;
using EFDbFirstApprochExample.ViewModels;
using EFDbFirstApprochExample.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using System.Web;

namespace EFDbFirstApprochExample.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View( new RegisterViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext();
                ApplicationUserStore userStore = new ApplicationUserStore(dbContext);
                ApplicationUserManager userManager = new ApplicationUserManager(userStore);
                string passwordHash = Crypto.HashPassword(registerViewModel.Password);
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    Email = registerViewModel.Email,
                    PasswordHash = passwordHash,
                    UserName = registerViewModel.Username,
                    Address = registerViewModel.Address,
                    City = registerViewModel.City,
                    Birthday = registerViewModel.DateOfBirth,
                    PhoneNumber = registerViewModel.Mobile
                };
                IdentityResult result = userManager.Create(applicationUser);
                if(result.Succeeded)
                {
                    userManager.AddToRole(applicationUser.Id, "Customer");
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(applicationUser, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Data");
                return View();
            }
           
        }

        public ActionResult Login()
        {
            return View( new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginView)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ApplicationUserStore userStore = new ApplicationUserStore(dbContext);
            ApplicationUserManager userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(loginView.Username, loginView.Password);
            if(user != null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties(), userIdentity);

                if(userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
               
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid UserName or Password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}