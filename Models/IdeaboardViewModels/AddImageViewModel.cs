using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DesignDirect.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignDirect.Models.IdeaboardViewModels
{
    public class AddImageViewModel
    {
        public Image Image {get; set;}
        public List<SelectListItem> IdeaboardId {get; set;}

        [Display(Name="Image Tags")]
        public MultiSelectList Tags { get; private set; }
        public List<int> SelectedTags { get; set; }
        public int chosenIdeaboard {get; set;}

        public ApplicationUser User {get; set;}

        public AddImageViewModel() {}
        public AddImageViewModel(ApplicationDbContext ctx, ApplicationUser user)
        {
            this.IdeaboardId = ctx.Ideaboard.Where(o => o.User.Id == user.Id)
                                    .OrderBy(l => l.Title)
                                    .AsEnumerable()
                                    .Select(li => new SelectListItem
                                    {
                                        Text = li.Title,
                                        Value = li.IdeaboardId.ToString()
                                    }).ToList();

            this.IdeaboardId.Insert(0, new SelectListItem
            {
                Text = "Choose an Ideaboard...",
                Value = "0"
            });

            List<Tag> allTags = ctx.Tag.OrderBy(s => s.Name).ToList();
            this.Tags = new MultiSelectList(allTags, "TagId", "Name");
        }
    }
}