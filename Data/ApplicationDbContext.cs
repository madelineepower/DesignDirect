using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DesignDirect.Models;

namespace DesignDirect.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<DesignDirect.Models.Ideaboard> Ideaboard { get; set; }

        public DbSet<DesignDirect.Models.Contractor> Contractor { get; set; }

        public DbSet<DesignDirect.Models.Image> Image { get; set; }

        public DbSet<DesignDirect.Models.Room> Room { get; set; }

        public DbSet<DesignDirect.Models.ContractorService> ContractorService { get; set; }

        public DbSet<DesignDirect.Models.ContractorTag> ContractorTag { get; set; }

        public DbSet<DesignDirect.Models.IdeaboardImage> IdeaboardImage { get; set; }

        public DbSet<DesignDirect.Models.ImageTag> ImageTag { get; set; }

        public DbSet<DesignDirect.Models.Service> Service { get; set; }

        public DbSet<DesignDirect.Models.Style> Style { get; set; }

        public DbSet<DesignDirect.Models.Tag> Tag { get; set; }
    }
}
