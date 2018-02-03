namespace GarbageGrabber.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GarbageGrabber.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GarbageGrabber.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //var user = new ApplicationUser();
            //user.UserName = "admin@gmail.com";
            //user.Email = "admin@gmail.com";

            //string userPWD = "Administrator01!";

            //var chkUser = UserManager.Create(user, userPWD);

            ////Add default User to Role Admin  
            //if (chkUser.Succeeded)
            //{
            //    var result1 = UserManager.AddToRole(user.Id, "Admin");
            //}

            context.Customers.AddOrUpdate(
                c => c.Id,
                new Customer { Id = 1, Role = "Customer", FirstName = "Brian", LastName = "Eigenfeld", Address = "1611 S 64th St", City = "West Allis", State = "Wisconsin", ZipCode = "53214", PickUpDay = "Saturday"},
                new Customer { Id = 2, Role = "Customer", FirstName = "David", LastName = "Eigenfeld", Address = "N91 W16761 Laurel Lane", City = "Menomonee Falls", State = "Wisconsin", ZipCode = "53051", PickUpDay = "Sunday" },
                new Customer { Id = 3, Role = "Customer", FirstName = "Jay", LastName = "Guzzetta", Address = "1608 S 64th St", City = "West Allis", State = "Wisconsin", ZipCode = "53214", PickUpDay = "Wednesday" },
                new Customer { Id = 4, Role = "Customer", FirstName = "Brian", LastName = "Bob", Address = "1243 N 10th St", City = "Milwaukee",State = "Wisconsin", ZipCode = "53205", PickUpDay = "Thursday"}
                );

            context.Employees.AddOrUpdate(
                e => e.Id,
                new Employee {Id=1, FirstName = "Uma", LastName = "Bob", Route = "53214"},
                new Employee {Id=2, FirstName = "Joe", LastName = "Bob", Route = "53051" },
                new Employee {Id=3, FirstName = "BillyBo", LastName = "Bob", Route = "53205"}
                );

            context.Routes.AddOrUpdate(

            );
        }
    }
}
