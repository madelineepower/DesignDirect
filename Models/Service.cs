using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class Service
    {
        [Key]
        public int ServiceId {get; set;}
        
        [Required]
        public string Name {get; set;}
    }
}