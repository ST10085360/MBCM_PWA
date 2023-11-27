using Microsoft.EntityFrameworkCore;
using MBCM_PWA.Client.Shared.Models;

namespace MBCM_PWA.Client.Shared
{
    public class MBCM_DbContext : DbContext
    {
        public MBCM_DbContext(DbContextOptions<MBCM_DbContext> options) : base(options)
        {
        }

        public DbSet<Project> tblProject { get; set; }
        public DbSet<User> tblUser { get; set; }
        public DbSet<UserCredentials> tblUserCredentials { get; set; }
        public DbSet<Review> tblReview { get; set; }
        public DbSet<UserProjects> tblUserProject { get; set; }
        public DbSet<Models.ProjectRequest> tblRequest { get; set; }
        public DbSet<SuggestedProject> tblProjectSuggestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProjectRequest>()
                .Property(p => p.RequestID)
                .ValueGeneratedOnAdd(); // This line configures RequestID as auto-generated

            // Define foreign key relationship between tblUser and tblUserCredentials
            modelBuilder.Entity<UserCredentials>()
                .HasOne(uc => uc.User)
                .WithOne(u => u.UserCredentials)
                .HasForeignKey<UserCredentials>(uc => uc.UserID);

            modelBuilder.Entity<SuggestedProject>().HasNoKey();
            
            modelBuilder.Entity<SuggestedProject>().HasKey(p => p.ProjectID);
            // Rest of your configurations...
        }
    }
}
