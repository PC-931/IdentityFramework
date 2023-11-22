using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecruitmentSystem.Models
{
    public class ApplicantDbContext : DbContext
    {
        public ApplicantDbContext() : base("HireIN")
        {
        }

        public DbSet<Applicant> applicants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}