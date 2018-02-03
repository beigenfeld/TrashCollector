using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarbageGrabber.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        public string RouteZipCode { get; set; }

    }
}