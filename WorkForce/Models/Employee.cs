using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkForce.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public Employee() { }
    }
}