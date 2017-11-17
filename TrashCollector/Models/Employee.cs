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
        public DateTime RouteDate { get; set; }
        public int NumberOfStops { get; set; }
    }
}