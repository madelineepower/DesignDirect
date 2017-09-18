using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DesignDirect.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public string Name {get; set;}

        public bool isSelected {get; set;}

    }
}