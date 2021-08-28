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
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public CompanyDetail Company { get; set; }
        [Required]
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public double Amount { get; set; }
        [Required]
        public double Emi { get; set; }
        [Required]
        public string MedicalId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
       

    }
}