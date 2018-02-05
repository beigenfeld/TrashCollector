using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageGrabber.Models
{
    public class PickUp
    {
        public int Id { get; set; }

        
        public string UserId { get; set; }
        public string PickUpDate { get; set; }
        public string PickUpAddress { get; set; }
        public string PickUpZip { get; set; }
        public bool PickUpPerformed { get; set; }
        public string Cost { get; set; }
        [Display(Name = "Reschedule This Pick-Up")]
        public string RescheduleThisPickUp { get; set; }

    }
}