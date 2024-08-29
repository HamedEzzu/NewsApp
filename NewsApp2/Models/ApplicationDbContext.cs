using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsApp2.Models.Entities;

namespace NewsApp2.Models
{
    //public class DataContext : DbContext
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options
                                    , IServiceProvider serviceProvider) : base(options)
        {
            _serviceProvider = serviceProvider;
        }


        public DbSet<Contact> Contact { get; set; }
        public DbSet<Section> Sections { get; set; } //News يمكن الغاءه لأنه مضمن في
        public DbSet<News> News { get; set; }
        public DbSet<SiteInfo> SiteInfo { get; set; }
        public DbSet<SiteState> SiteState { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Section>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<News>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<SiteInfo>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<SiteState>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<UserProfile>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Employee>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Seed(_serviceProvider);


            modelBuilder.Entity<ApplicationUser>()
             .HasOne(a => a.UserProfile)
             .WithOne(b => b.ApplicationUser)
             .HasForeignKey<UserProfile>(b => b.UserId)
             .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<ApplicationUser>()
                        .HasOne(a => a.Employee)
                        .WithOne(b => b.ApplicationUser)
                        .HasForeignKey<Employee>(b => b.UserId)
                        .OnDelete(DeleteBehavior.Cascade);



        }

    }
}