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
            return RedirectToAction("CustomerRegister", "Customer");
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





    }
}