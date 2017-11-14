using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RouteId { get; set; }
        public string RouteDate { get; set; }
        public string NumberOfStops { get; set; }
    }
}