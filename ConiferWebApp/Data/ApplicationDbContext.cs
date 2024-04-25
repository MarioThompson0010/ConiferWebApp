//using BlazorApp1.Models.Clients;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelsProject;

namespace ConiferWebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : DbContext
    {
        IConfiguration Configuration { get; set; }

        public virtual DbSet<MyZone> MyZones { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            :this(options)            
        {
            this.Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MyZone>(entity => {
                entity.HasNoKey();
                //entity.ToTable("MyZone");
            });

            base.OnModelCreating(builder);
        }
    }
}
