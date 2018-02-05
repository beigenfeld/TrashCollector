using GarbageGrabber.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarbageGrabber.Controllers
{
    public class PickUpsController : Controller
    {
        ApplicationDbContext db = new Models.ApplicationDbContext();
        

        // GET: PickUps
        public ActionResult PickUpIndex()
        {
            List<PickUp> pickUp = db.PickUps.ToList();
            return View(pickUp);
        }

        // GET: PickUps/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PickUps/Create
        public ActionResult Create()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Customers.Where(c => c.UserId == currentUserId).FirstOrDefault();
            var today = DateTime.Now;
            for (int i = 1; i <= 7; i++)
            {
                var dayOfWeek = today.AddDays(i);
                var dayName = dayOfWeek.ToString("ddddd");
                if (dayName == currentUser.PickUpDay)
                {
                    currentUser.NextPickUp = dayOfWeek.ToString();
                    PickUp nextPickUp = new PickUp();
                    nextPickUp.UserId = currentUser.UserId;
                    nextPickUp.PickUpZip = currentUser.ZipCode;
                    nextPickUp.PickUpDate = dayOfWeek.ToString();
                    nextPickUp.PickUpAddress = currentUser.Address;
                    db.PickUps.Add(nextPickUp);
                    db.SaveChanges();
                    return RedirectToAction("MyPickUp", "Customers");
                }
            }
            return RedirectToAction("MyPickUp","Customers");
        }

        // POST: PickUps/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PickUps/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PickUps/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PickUp model)
        {
            try
            {
                // TODO: Add update logic here
                PickUp performed = db.PickUps.Where(u => u.Id == id).FirstOrDefault();
                performed.PickUpPerformed = model.PickUpPerformed;
                db.Entry(performed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PickUpIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: PickUps/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PickUps/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult MyPickUps()
        {
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Employees.Where(c => c.UserId == currentUserId).FirstOrDefault();
            var myPickUpList = new List<PickUp>();
            foreach(var item in db.PickUps)
            {
                if (currentUser.Route == item.PickUpZip)
                {
                    myPickUpList.Add(item);
                }
            }
            return View(myPickUpList);
        }

        public ActionResult RouteMap()
        {
            var pickUpsList = db.PickUps.ToList();
            return View(pickUpsList);
        }

        public ActionResult ChangeThisPickUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeThisPickup([Bind(Include= "RescheduleThisPickUp")] Customer customer)
        {

            var currentUserId = User.Identity.GetUserId();
            customer.UserId = currentUserId;
            var thisPickUp = db.PickUps.Where(c => c.UserId == currentUserId).FirstOrDefault();
            db.SaveChanges();
            return RedirectToAction("MyPickUp","Customers");
        }


    }
}
