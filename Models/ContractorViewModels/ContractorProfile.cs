using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DesignDirect.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DesignDirect.Models.ContractorViewModels
{
    public class ContractorProfile
    {
        public Contractor Contractor {get; set;}

        public List<Service> Services {get; set;}

        public ContractorProfile(ApplicationDbContext ctx, int? id)
        {
            var contractorServices = ctx.ContractorService.Where(c => c.ContractorId == id).Select(c => c.ServiceId).ToList();
            var allServices = ctx.Service.ToList();
            this.Services = (from s in allServices
                            from c in contractorServices
                            where s.ServiceId == c
                            select s).ToList();
        }
    }
}