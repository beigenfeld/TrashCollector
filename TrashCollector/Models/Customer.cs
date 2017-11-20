using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrashCollector.Models
{
    public class Customer
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public ApplicationUser User { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PickupDay { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime? NoPickupStartDate { get; set; }
        public DateTime? NoPickupEndDate { get; set; }
        public DateTime? SpecialPickup { get; set; }


        //customers/create



    }
}