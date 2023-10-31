using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using MBCM_PWA.Client.Shared.Models;

namespace MBCM_PWA.Client.Shared
{
    public class MBCM_DbContext : DbContext
    {
        public MBCM_DbContext(DbContextOptions<MBCM_DbContext> options) : base(options)
        {
        }

        // Define DbSet properties for each of your model classes
        public DbSet<Project> tblProjects { get; set; }
        public DbSet<User> tblUsers { get; set; }
        public DbSet<Review> tblReviews { get; set; }
        public DbSet<UserProjects> tblUserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.OwnedProjects)
                .HasForeignKey(p => p.prjOwnerID);
        }
    }
}