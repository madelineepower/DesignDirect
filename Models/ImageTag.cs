using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class ImageTag
    {
        [Key]
        public int ImageTagId { get; set; }

        [Required]
        public int ImageId { get; set; }

        [Required]
        public int TagId { get; set; }

        public virtual Image Image { get; set; }

        public virtual Tag Tag { get; set; }
    }
}