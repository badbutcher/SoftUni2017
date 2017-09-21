﻿namespace _003.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Employee()
        {
            this.Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}