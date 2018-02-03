using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using GarbageGrabber.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace GarbageGrabber
{
    public partial class Startup
    {

        ApplicationDbContext context = new ApplicationDbContext();
        






        private void CreateRolesAndUsers()
        {
            // ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";

                string userPWD = "Administrator01!";

                var chkUser = UserManager.Create(user, userPWD);
                //Add default User to Role Admin  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            

            

            // creating employee role    
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }

            //create employee user

            var employee = new ApplicationUser();
            employee.UserName = "employee@gmail.com";
            employee.Email = "employee@gmail.com";

            string user2PWD = "Employee01!";

            var chkUser2 = UserManager.Create(employee, user2PWD);

            //Add default User to Role Employee  
            if (chkUser2.Succeeded)
            {
                var result1 = UserManager.AddToRole(employee.Id, "Employee");

            }

            


            // creating Customer role    
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);

            }

            
            //create customer user

            var customer = new ApplicationUser();
            customer.UserName = "customer@gmail.com";
            customer.Email = "customer@gmail.com";

            string user3PWD = "Customer01!";

            var chkUser3 = UserManager.Create(customer, user3PWD);

            //Add default User to Role Customer  
            if (chkUser3.Succeeded)
            {
                var result1 = UserManager.AddToRole(customer.Id, "Customer");

            }
        }

        //It automatically creates three roles and three users to fill those roles, you can obv change the usernames and emails and whatever but it'll bind it all to the built in tables

        public void CreateSeedUsers()
        {

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var customers = context.Customers.ToList();
            var employees = context.Employees.ToList();

            foreach (Customer customer in customers)
            {

                var username = customer.FirstName + customer.LastName + "@gmail.com";
                string passWord = customer.FirstName + customer.LastName + "01!";
                ApplicationUser user = new ApplicationUser();
                user.UserName = username;
                user.Email = username;
                var seedUser = UserManager.Create(user, passWord);
                if (seedUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Customer");
                    customer.UserId = user.Id;
                    var today = DateTime.Now;
                    for (int i = 1; i <= 7; i++)
                    {
                        var dayOfWeek = today.AddDays(i);
                        var dayName = dayOfWeek.ToString("ddddd");
                        if (dayName == customer.PickUpDay)
                        {
                            customer.NextPickUp = dayOfWeek.ToString();
                            PickUp nextPickUp = new PickUp();
                            nextPickUp.UserId = customer.UserId;
                            nextPickUp.PickUpZip = customer.ZipCode;
                            nextPickUp.PickUpDate = dayOfWeek.ToString();
                            nextPickUp.PickUpAddress = customer.Address;
                            context.PickUps.Add(nextPickUp);
                            context.SaveChanges();
                        }
                        context.SaveChanges();
                    }
                }
            }
        


            foreach (Employee employee in employees)
            {

                var username = employee.FirstName + employee.LastName + "@gmail.com";
                string passWord = employee.FirstName + employee.LastName + "01!";
                ApplicationUser user = new ApplicationUser();
                user.UserName = username;
                user.Email = username;
                var seedUser = UserManager.Create(user, passWord);
                if (seedUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Employee");
                    employee.UserId = user.Id;
                    context.SaveChanges();
                }
            }



        }







        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}