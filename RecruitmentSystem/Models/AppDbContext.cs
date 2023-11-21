using System.Data.Entity;

namespace RecruitmentSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("HireIN")
        {            
        }

        public DbSet<Vacancy> vacancies { get; set; }
        public DbSet<Applicant> applicants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}