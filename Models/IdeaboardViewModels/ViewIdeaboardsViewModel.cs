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
    public class ViewIdeaboardsViewModel
    {
       public List<Ideaboard> Ideaboards {get; set;}

       public List<Contractor> MatchingContractors {get; set;}

       public List<Service> Services {get; set;}  

    }
}