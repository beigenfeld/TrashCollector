using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {

        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DayOfWeek PickupDay { get; set; }
        public DateTime PickupDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime NoPickupStartDate { get; set; }
        public DateTime NoPickupEndDate { get; set; }
        public DateTime SpecialPickup { get; set; }


        //customers/create



    }
}