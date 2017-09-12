using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class ContractorService
    {
        [Key]
        public int ContractorServiceId { get; set; }

        [Required]
        public int ContractorId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual Service Service { get; set; }
    }
}