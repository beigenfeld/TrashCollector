using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageGrabber.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Display(Name = "Pick Up Day")]
        public string PickUpDay { get; set; }
        public string UserId { get; set; }
        // string userId = User.Identity.GetUserId();
        public string NextPickUp { get; set; }
        public string RescheduleThisPickUp { get; set; }
        public int Balance { get; set; }
    }
}