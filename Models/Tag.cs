using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class Tag
    {
        [Key]
        public int TagId {get; set;}

        [Required]
        public string Name {get; set;}

        public ICollection<ImageTag> Images { get; set; }
    }
}