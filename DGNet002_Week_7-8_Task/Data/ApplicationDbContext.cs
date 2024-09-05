using DGNet002_Week_7_8_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace DGNet002_Week_7_8_Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Admin> admin {  get; set; }
        public DbSet<Portfolio> portfolios {  get; set; }
        public DbSet<Resume> resumes {  get; set; }
        public DbSet<Skill> skills {  get; set; }
        public DbSet<ContactDetail> contactDetails {  get; set; }
        public DbSet<ContactForm> contactForms {  get; set; }
    }
}
