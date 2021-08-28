using Health_Insurance_Management.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Health_Insurance_Management.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public Policy GetPolicy { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public DateTime JoinDate { get; set; }
        public double Salary { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeePhone { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}