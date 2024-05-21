using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkForce.Controllers.DTO
{
    public class EmployeeDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int DepartmentId { get; set; }
    }
}