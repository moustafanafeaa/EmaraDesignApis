
using EmaraDesignApis.Models;
using EmaraDesignWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmaraDesignWebApi.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ProjectImage>()
               .HasKey(pc => new { pc.ProjectId, pc.ImageId });

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<FinancialContract> financialContracts { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }


    }

}
