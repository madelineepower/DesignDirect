using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class ContractorTag
    {
        [Key]
        public int ContractorTagId { get; set; }

        [Required]
        public int ContractorId { get; set; }

        [Required]
        public int TagId { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual Tag Tag { get; set; }
    }
}