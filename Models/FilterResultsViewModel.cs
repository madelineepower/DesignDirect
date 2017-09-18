using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DesignDirect.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DesignDirect.Models
{
    public class FilterResultsViewModel
    {
        public List<Image> Images { get; set; }
        public MultiSelectList Rooms { get; set; }
        public MultiSelectList Styles {get; set; }
        public List<int> FilterRoomIds  { get; set; }

        public List<int> FilterStyleIds {get; set; }

        public FilterResultsViewModel() {}
        public FilterResultsViewModel(ApplicationDbContext ctx)
        {
            List<Room> allRooms = ctx.Room.ToList();
            List<Style> allStyles = ctx.Style.ToList();
            this.Rooms = new MultiSelectList(allRooms, "RoomId", "Name");
            this.Styles = new MultiSelectList(allStyles, "StyleId", "Name");
        } 

    }
}