using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDirect.Models
{
    public class Image
    {
        [Key]
        public int ImageId {get; set;}
        public string Description {get; set;}

        [Required]
        public string Source {get; set;}

        [Required]
        public int RoomId {get; set;}

        public Room Room {get; set;}

        [Required]
        public int StyleId {get; set;}

        public Style Style {get; set;}

        public ICollection<IdeaboardImage> Ideaboards { get; set; }
        public ICollection<ImageTag> Tags { get; set; }
    }
}