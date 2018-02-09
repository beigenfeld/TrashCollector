using GarbageGrabber.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarbageGrabber.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        //GET
        public ActionResult CreateProfile(Customer customer, bool OverloadFiller = false)
        {

            if (ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
               
                customer.UserId = currentUserId;
            }


            //FirstName=model.FirstName, LastName=model.LastName, Address=model.Address, City=model.City, State=model.State, ZipCode=model.ZipCode, PickUpDay=model.PickUpDay

            return View(customer);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile([Bind(Include = "FirstName, LastName, Address, City, State, ZipCode, PickUpDay, UserId")] Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return View("MyPickUp");
        }

        public ActionResult CreateProfile2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile2([Bind(Include = "FirstName, LastName, Address, City, State, ZipCode, PickUpDay")] Customer customer)
        {
            customer.Role = "Customer";
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Register", "Account");
        }

        public ActionResult NotAnEmployee()
        {
            return View();
        }

        public ActionResult MyPickUp()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Customers.Where(c => c.UserId == currentUserId).FirstOrDefault();

            if (currentUser.NextPickUp == null)
            {
                return RedirectToAction("Create", "PickUps");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ChangePickUpDay()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePickUpDay([Bind(Include = "PickUpDay")] Customer customer)
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Customers.Where(c => c.UserId == currentUserId).FirstOrDefault();
            currentUser.PickUpDay = customer.PickUpDay;
            db.SaveChanges(); 
            return View("NewPickUpDay");
        }

        public ActionResult NewPickUpDay()
        {
            return View();
        }

        public ActionResult CalculateNextPickUp()
        {
            var today = DateTime.Now;

            return View("MyPickUp");
        }


        public ActionResult CustomerRegister(Customer customer)
        {
            
            return View();
        }

        public ActionResult ChangeThisPickUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeThisPickUp ([Bind(Include ="UserId, RescheduleThisPickUp")] PickUp rescheduledPickup)
        {
            var currentUser = User.Identity;
            var currentUserId = currentUser.GetUserId();
            var currentCustomer = db.Customers.Where(c => c.UserId == currentUserId).FirstOrDefault();
            var currentPickUpDate = currentCustomer.NextPickUp;
            var thisPickUp = db.PickUps.Where(p => p.UserId == currentUserId).Where(p => p.PickUpDate == currentPickUpDate).FirstOrDefault();

            var today = DateTime.Now;
            for (int i = 1; i <= 7; i++)
            {
                var dayOfWeek = today.AddDays(i);
                var dayName = dayOfWeek.ToString("ddddd");

                if (dayName == rescheduledPickup.RescheduleThisPickUp)
                {
                    thisPickUp.PickUpDate = dayOfWeek.ToString();
                    currentCustomer.NextPickUp = dayOfWeek.ToString();
                    db.SaveChanges();
                }
            }
                    return View("MyPickUp");
            
        }

        public ActionResult MakePayment()
        {
            return View();
        }

        public ActionResult CheckBalance()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Customers.Where(c => c.UserId == currentUserId).FirstOrDefault();
            var userPickUps = db.PickUps.Where(p => p.UserId == currentUser.UserId && p.PickUpPerformed == true).ToList();
            var balanceDue = "";
            foreach (var pickUp in userPickUps)
            {
                balanceDue += pickUp.Cost;
            }
            return View(balanceDue);
        }

    }
}