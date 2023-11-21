using System.Data.Entity;

namespace RecruitmentSystem.Models
{
    public class VacancyDbContext : DbContext
    {
        public VacancyDbContext() : base("HireIN")
        {            
        }

        public DbSet<Vacancy> vacancies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}