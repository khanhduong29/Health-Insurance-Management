using Health_Insurance_Management.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Health_Insurance_Management.Models
{
    public class CompanyDetail
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyAddress { get; set; }
        [Required]
        public string CompanyPhone { get; set; }
        public string CompanyURL { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}