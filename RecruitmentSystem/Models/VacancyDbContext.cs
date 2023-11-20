using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecruitmentSystem.Models
{
    public class VacancyDbContext : DbContext
    {
        public VacancyDbContext() : base("NewDB")
        {            
        }

        public DbSet<Vacancy> vacancies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}