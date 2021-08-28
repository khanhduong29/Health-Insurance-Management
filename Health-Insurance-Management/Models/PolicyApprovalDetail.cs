using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Health_Insurance_Management.Models
{
    public class PolicyApprovalDetail
    {
        [Key]
        public int Id { get; set; }
        public int PolicyId { get; set; }
        [ForeignKey("PolicyId")]
        public Policy Policy { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Reason { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
    }
}