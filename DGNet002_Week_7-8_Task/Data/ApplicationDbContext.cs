using DGNet002_Week_7_8_Task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Data
{
    public class ApplicationDbContext : IdentityDbContext<AdminUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
               
        public DbSet<Project> Projects {  get; set; }
        public DbSet<Resume> Resumes {  get; set; }
        public DbSet<Skill> Skills {  get; set; }
        public DbSet<ContactForm> ContactForms {  get; set; }
        public DbSet<Education> Educations {  get; set; }
        public DbSet<WorkExperience> Experiences {  get; set; }



      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Resume>()
                .HasOne(r => r.AdminUser)
                .WithOne(a => a.Resume)
                .HasForeignKey<Resume>(r => r.AdminUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Resume)
                .WithMany(r => r.Projects)
                .HasForeignKey(p => p.ResumeSectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Skill>()
                .HasOne(s => s.Resume)
                .WithMany(r => r.Skills)
                .HasForeignKey(s => s.ResumeSectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Education>()
                .HasOne(e => e.Resume)
                .WithMany(r => r.Educations)
                .HasForeignKey(e => e.ResumeSectionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkExperience>()
                .HasOne(w => w.Resume)
				.WithMany(r => r.Experiences)
                .HasForeignKey(w => w.ResumeSectionId)
                .OnDelete(DeleteBehavior.Cascade);


            Seed.SeedUser(modelBuilder);
        }*/
    }
}
