using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Health_Insurance_Management.Models
{
    public class HospitalInfo
    {
        [Key]
        public int HospitalId { get; set; }
        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string HospitalPhone { get; set; }
        [Required]
        public string HospitalAddress { get; set; }
        public string HospitalURL { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}