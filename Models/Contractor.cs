using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class Contractor
    {
        [Key]
        public int ContractorId {get; set;}

        [Required]
        public virtual ApplicationUser User {get; set;}

        [Required]
        public string City {get; set;}
        
        [Required]
        public string State {get; set;}

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber {get; set;}

        public string Website {get; set;}

        [Display(Name = "Company Name")]
        public string CompanyName {get; set;}

        [StringLength(250)]
        public string Description {get; set;}

        public virtual ICollection<ContractorService> Services { get; set; }

    }
}