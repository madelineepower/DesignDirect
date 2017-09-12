using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class IdeaboardImage
    {
        [Key]
        public int ImageboardImageId { get; set; }

        [Required]
        public int ImageId { get; set; }

        [Required]
        public int IdeaboardId { get; set; }

        public virtual Image Image { get; set; }

        public virtual Ideaboard Ideaboard { get; set; }
    }
}