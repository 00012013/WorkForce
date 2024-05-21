﻿using System.Collections.Generic;

namespace WorkForce.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<Employee> Employees { get; set; }
    }
}