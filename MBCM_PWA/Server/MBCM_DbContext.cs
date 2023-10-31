using Microsoft.EntityFrameworkCore;
using MBCM_PWA.Client.Shared.Models;

namespace MBCM_PWA.Client.Shared
{
    public class MBCM_DbContext : DbContext
    {
        public MBCM_DbContext(DbContextOptions<MBCM_DbContext> options) : base(options)
        {
        }

        public DbSet<Project> tblProject { get; set; }/*
        public DbSet<User> tblUser { get; set; }
        public DbSet<Review> tblReview { get; set; }
        public DbSet<UserProjects> tblUserProject { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Project>()
                .HasOne(p => p.Owner)
                .WithMany(u => u.OwnedProjects)
                .HasForeignKey(p => p.prjOwnerID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerID);

            modelBuilder.Entity<UserProjects>()
                .HasKey(up => new { up.userID, up.projectID });

            modelBuilder.Entity<UserProjects>()
                .HasOne(up => up.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(up => up.userID);

            modelBuilder.Entity<UserProjects>()
                .HasOne(up => up.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(up => up.projectID);*/
        }
    }
}
