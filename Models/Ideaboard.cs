using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class Ideaboard
    {
        [Key]
        public int IdeaboardId {get; set;}

        [Required]
        public string Title {get; set;}

        [Required]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<IdeaboardImage> Images { get; set; }
    }
}